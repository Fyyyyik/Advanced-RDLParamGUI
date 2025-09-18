using KirbyLib;
using KirbyLib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RDLParamGUI
{
    public class ParamFile
    {
        public XData XData { get; private set; } = new XData();

        public List<uint> Parameters = new List<uint>();

        public ParamFile() { }

        public ParamFile(EndianBinaryReader reader)
        {
            Read(reader);
        }

        public void Read(EndianBinaryReader reader)
        {
            XData.Read(reader);

            long pos = reader.BaseStream.Position;
            reader.BaseStream.Seek(0, SeekOrigin.End);
            long size = reader.BaseStream.Position;
            reader.BaseStream.Seek(pos, SeekOrigin.Begin);

            for(int i = 0; i * 4 + 4 <= size - pos; i++)
            {
                Parameters.Add(reader.ReadUInt32());
            }
        }

        public void Write(EndianBinaryWriter writer)
        {
            XData.WriteHeader(writer);

            foreach(uint param in Parameters)
            {
                writer.Write(param);
            }

            XData.WriteFilesize(writer);
            XData.WriteFooter(writer);
        }
    }
}
