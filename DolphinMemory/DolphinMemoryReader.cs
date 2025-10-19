using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Dolphin.Memory.Access;

namespace DolphinMemory
{
    public class DolphinMemoryReader : IDisposable
    {
        #region PInvoke
        const uint PROCESS_VM_READ = 0x0010;
        const uint PROCESS_VM_WRITE = 0x0020;

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);


        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesRead);


        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int dwSize,
            out IntPtr lpNumberOfBytesWritten);
        #endregion

        private IntPtr _hProcess = IntPtr.Zero;

        private Dolphin.Memory.Access.Dolphin _dolphin;

        public DolphinMemoryReader(Process dolProcess)
        {
            _dolphin = new Dolphin.Memory.Access.Dolphin(dolProcess);
            _hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_VM_WRITE, false, dolProcess.Id);
        }

        public byte[] ReadBytes(long address, int count)
        {
            byte[] buffer;
            IntPtr hostAddress;

            if (!BitConverter.IsLittleEndian)
            {
                long startAddress = address - (address % 4);

                int byteCount = (int)(count + (address - startAddress));
                if (byteCount % 4 != 0)
                    byteCount += 4 - (byteCount % 4);

                buffer = new byte[byteCount];
                if (_dolphin.TryGetAddress(startAddress, out hostAddress))
                {
                    if (ReadProcessMemory(_hProcess, hostAddress, buffer, byteCount, out IntPtr bytesRead))
                    {
                        // Fix endianness
                        byte[] copy = (byte[])buffer.Clone();
                        for (int i = 0; i < bytesRead; i++)
                            copy[i] = buffer[((i / 4) * 4) + (3 - (i % 4))];

                        buffer = new byte[count];
                        int startIndex = (int)(address - startAddress);
                        for (int i = 0; i < count; i++)
                            buffer[i] = copy[startIndex + i];
                    }
                    else throw new Win32Exception("ReadProcessMemory failed.");
                }
                return buffer;
            }

            buffer = new byte[count];
            if(_dolphin.TryGetAddress(address, out hostAddress))
            {
                if (!ReadProcessMemory(_hProcess, hostAddress, buffer, count, out _))
                    throw new Win32Exception("ReadProcessMemory failed.");
            }
            return buffer;
        }

        public uint ReadUInt32(long address)
        {
            byte[] bytes = ReadBytes(address, 4);
            if(BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes);
        }

        public long[] SearchBytesInRange(long minAddress, long maxAddress, byte[] target)
        {
            if (target == null || target.Length == 0)
                throw new ArgumentException("Target byte array must not be empty.", nameof(target));

            if (maxAddress <= minAddress)
                throw new ArgumentException("Invalid address range.");

            const int CHUNK_SIZE = 0x10000; // 64KB chunks for good performance/memory balance
            List<long> results = new List<long>();

            byte[] buffer = new byte[CHUNK_SIZE + target.Length]; // overlap space for boundary matches

            long current = minAddress;
            while (current < maxAddress)
            {
                int bytesToRead = (int)Math.Min(CHUNK_SIZE, maxAddress - current);
                byte[] data = ReadBytes(current, bytesToRead + target.Length - 1);

                int index = IndexOf(data, target);
                while (index >= 0)
                {
                    results.Add(current + index);
                    index = IndexOf(data, target, index + 1);
                }

                current += bytesToRead;
            }

            return results.ToArray();
        }

        /// <summary>
        /// Optimized byte array search (like IndexOf for byte[]).
        /// Uses a simple but efficient scan that supports overlapping matches.
        /// </summary>
        private static int IndexOf(byte[] buffer, byte[] pattern, int startIndex = 0)
        {
            int limit = buffer.Length - pattern.Length;
            for (int i = startIndex; i <= limit; i++)
            {
                int j = 0;
                for (; j < pattern.Length; j++)
                {
                    if (buffer[i + j] != pattern[j])
                        break;
                }
                if (j == pattern.Length)
                    return i;
            }
            return -1;
        }

        #region Disposable
        public void Dispose()
        {
            CloseHandle(_hProcess);
        }
        #endregion
    }
}
