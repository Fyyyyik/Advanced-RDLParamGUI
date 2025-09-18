using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IniParser;
using IniParser.Exceptions;
using IniParser.Model;
using IniParser.Parser;
using KirbyLib;
using KirbyLib.IO;

namespace RDLParamGUI
{
    public partial class Form1 : Form
    {
        Endianness endianness;
        byte[] version;
        uint unkXbin;
        Dictionary<string, ParamFile> paramData;
        Dictionary<string, ParamFile> refData;
        IniData labelData = new IniData();
        string filepath, refPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refPath = Directory.GetCurrentDirectory() + @"\Reference.bin";
            autocompressOnSaveToolStripMenuItem.Checked = RDLParamGUI.Properties.Settings.Default.autocompress;
            UpdateINI();
        }

        private void autocompressOnSaveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            RDLParamGUI.Properties.Settings.Default.autocompress = autocompressOnSaveToolStripMenuItem.Checked;
            RDLParamGUI.Properties.Settings.Default.Save();
        }

        public void UpdateINI()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\labels.ini"))
            {
                labelData = new FileIniDataParser().ReadFile(Directory.GetCurrentDirectory() + "\\labels.ini");
            }
            if (paramData != null)
                UpdateFileList();
        }

        public void UpdateFileList()
        {
            fileList.Items.Clear();
            fileList.BeginUpdate();
            foreach (KeyValuePair<string, ParamFile> file in paramData)
            {
                fileList.Items.Add(file.Key);
            }
            fileList.EndUpdate();
        }

        public void Save()
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            GenericArchive archive = new GenericArchive();
            archive.XData.Endianness = endianness;
            archive.XData.Version = version;
            foreach (string fileName in paramData.Keys)
            {
                byte[] buffer;
                using(MemoryStream stream = new MemoryStream())
                using(EndianBinaryWriter writer = new EndianBinaryWriter(stream))
                {
                    paramData[fileName].Write(writer);
                    buffer = stream.ToArray();
                }

                GenericArchive.FileInfo fileInfo = new GenericArchive.FileInfo();
                fileInfo.Name = fileName;
                fileInfo.Data = buffer;
                archive.Files.Add(fileInfo);
            }

            using(FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Write))
            using(EndianBinaryWriter writer = new EndianBinaryWriter(stream))
                archive.Write(writer);

            if (filepath.EndsWith(".cmp") && autocompressOnSaveToolStripMenuItem.Checked)
            {
                Process recompress = new Process();
                recompress.StartInfo = lzxCompressFile(filepath);
                recompress.Start();
                recompress.WaitForExit();
                recompress.Dispose();
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XBIN Binary Archives|*.bin;*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                valueList.Items.Clear();
                fileList.Items.Clear();
                hexData.Text = "";
                intData.Text = "";
                floatData.Text = "";
                hexDataOrig.Text = "";
                intDataOrig.Text = "";
                floatDataOrig.Text = "";
                labelBox.Text = "";
                descriptionBox.Text = "";

                filepath = open.FileName;
                if (filepath.EndsWith(".cmp"))
                {
                    Console.WriteLine("Decompressing...");
                    Process decompress = new Process();
                    decompress.StartInfo = lzxDecompressFile(filepath);
                    decompress.Start();
                    decompress.WaitForExit();
                    decompress.Dispose();
                }

                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                paramData = new Dictionary<string, ParamFile>();

                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                GenericArchive archive = new GenericArchive();
                using(FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                using(EndianBinaryReader reader = new EndianBinaryReader(stream))
                    archive.Read(reader);

                endianness = archive.XData.Endianness;
                version = archive.XData.Version;

                for (int i = 0; i < archive.Files.Count; i++)
                {
                    ParamFile file = new ParamFile();
                    using(MemoryStream stream = new MemoryStream(archive.Files[i].Data))
                    using(EndianBinaryReader reader = new EndianBinaryReader(stream))
                        file.Read(reader);

                    paramData.Add(archive.Files[i].Name, file);
                }

                if (filepath.EndsWith(".cmp"))
                {
                    Console.WriteLine("Recompressing...");
                    Process recompress = new Process();
                    recompress.StartInfo = lzxCompressFile(filepath);
                    recompress.Start();
                    recompress.WaitForExit();
                    recompress.Dispose();
                }

                UpdateFileList();
                this.Cursor = Cursors.Default;
                this.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                parameterPatchingToolStripMenuItem.Enabled = true;
                updateLabelsToolStripMenuItem.Enabled = true;
                RefreshReference();
            }
        }

        private void openReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "XBIN Binary Archives|*.bin;*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                File.Copy(open.FileName, refPath, true);
                if (open.FileName.EndsWith(".cmp"))
                {
                    Console.WriteLine("Decompressing...");
                    Process decompress = new Process();
                    decompress.StartInfo = lzxDecompressFile(refPath);
                    decompress.Start();
                    decompress.WaitForExit();
                    decompress.Dispose();
                }
                RefreshReference();
            }
        }

        private void RefreshReference()
        {
            if (File.Exists(refPath))
            {
                refData = new Dictionary<string, ParamFile>();
                refPath = Directory.GetCurrentDirectory() + @"\Reference.bin";

                GenericArchive refArchive = new GenericArchive();
                using(FileStream stream = new FileStream(refPath, FileMode.Open, FileAccess.Read))
                using(EndianBinaryReader reader = new EndianBinaryReader(stream))
                    refArchive.Read(reader);

                for (int i = 0; i < refArchive.Files.Count; i++)
                {
                    ParamFile paramFile = new ParamFile();
                    using(MemoryStream stream = new MemoryStream(refArchive.Files[i].Data))
                    using(EndianBinaryReader reader = new EndianBinaryReader(stream))
                        paramFile.Read(reader);

                    refData.Add(refArchive.Files[i].Name, paramFile);
                }

                generatePatchToolStripMenuItem.Enabled = true;
            }
            else
            {
                refData = new Dictionary<string, ParamFile>();
                generatePatchToolStripMenuItem.Enabled = false;
            }
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            valueList.Items.Clear();
            hexData.Text = "";
            intData.Text = "";
            floatData.Text = "";
            hexDataOrig.Text = "";
            intDataOrig.Text = "";
            floatDataOrig.Text = "";
            labelBox.Text = "";
            descriptionBox.Text = "";
            string filename = fileList.SelectedItem.ToString();
            for (int i = 0; i < paramData[filename].Parameters.Count; i++)
            {
                if (labelData.Sections.ContainsSection(filename))
                {
                    if (labelData.Sections[filename].ContainsKey(i.ToString()))
                    {
                        valueList.Items.Add(labelData.Sections[filename][i.ToString()]);
                    }
                    else
                    {
                        valueList.Items.Add("Entry " + i);
                    }
                }
                else
                {
                    valueList.Items.Add("Entry " + i);
                }
            }
        }

        private void valueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = valueList.SelectedIndex;
            if (refData != null)
            {
                try
                {
                    uint[] origData = refData[fileList.SelectedItem.ToString()].Parameters.ToArray();
                    byte[] origFloatBytes = BitConverter.GetBytes(origData[index]);
                    hexDataOrig.Text = origData[index].ToString("X8");
                    intDataOrig.Text = origData[index].ToString();
                    floatDataOrig.Text = BitConverter.ToSingle(origFloatBytes, 0).ToString();
                }
                catch 
                {
                    hexDataOrig.Text = "";
                    intDataOrig.Text = "";
                    floatDataOrig.Text = "";
                }
            }
            try
            {
                uint[] data = paramData[fileList.SelectedItem.ToString()].Parameters.ToArray();
                byte[] floatBytes = BitConverter.GetBytes(data[index]);
                hexData.Text = data[index].ToString("X8");
                intData.Text = data[index].ToString();
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
            }
            catch 
            {
                hexData.Text = "";
                intData.Text = "";
                floatData.Text = "";
            }

            labelBox.Text = "";
            descriptionBox.Text = "";
            try
            {
                string f = fileList.SelectedItem.ToString();
                string v = valueList.SelectedIndex.ToString();
                if (labelData.Sections.ContainsSection(f))
                {
                    if (labelData.Sections[f].ContainsKey(v))
                    {
                        labelBox.Text = labelData.Sections[f][v];
                    }
                    if (labelData.Sections[f].ContainsKey(v + "D"))
                    {
                        descriptionBox.Text = labelData.Sections[f][v + "D"].Replace("<br>", Environment.NewLine);
                    }
                }
            } catch { }
        }

        private void updateLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateINI();
            RefreshReference();
            valueList.Items.Clear();
            hexData.Text = "";
            intData.Text = "";
            floatData.Text = "";
            hexDataOrig.Text = "";
            intDataOrig.Text = "";
            floatDataOrig.Text = "";
        }

        private void hexData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && hexData.Focused)
            {
                int index = valueList.SelectedIndex;
                byte[] floatBytes = BitConverter.GetBytes(uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber));
                intData.Text = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber).ToString();
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
                paramData[fileList.SelectedItem.ToString()].Parameters[index] = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber);
            }
        }

        private void intData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && intData.Focused)
            {
                int index = valueList.SelectedIndex;
                byte[] floatBytes = BitConverter.GetBytes(uint.Parse(intData.Text));
                hexData.Text = uint.Parse(intData.Text).ToString("X8");
                floatData.Text = BitConverter.ToSingle(floatBytes, 0).ToString();
                paramData[fileList.SelectedItem.ToString()].Parameters[index] = uint.Parse(intData.Text);
            }
        }

        private void floatData_TextChanged(object sender, EventArgs e)
        {
            if (hexData.Text != "" && intData.Text != "" && floatData.Text != "" && floatData.Focused)
            {
                try
                {
                    int index = valueList.SelectedIndex;
                    byte[] floatBytes = BitConverter.GetBytes(float.Parse(floatData.Text));
                    uint parsedFloat = BitConverter.ToUInt32(floatBytes, 0);
                    hexData.Text = parsedFloat.ToString("X8");
                    intData.Text = parsedFloat.ToString();
                    paramData[fileList.SelectedItem.ToString()].Parameters[index] = uint.Parse(hexData.Text, System.Globalization.NumberStyles.HexNumber);
                } catch { }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.AddExtension = true;
            save.Filter = "LZ11 Compressed XBIN Binary Archives|*.cmp|XBIN Binary Archives|*.bin";
            save.DefaultExt = ".cmp";
            if (save.ShowDialog() == DialogResult.OK)
            {
                filepath = save.FileName;
                Save();
            }
        }

        private void importPatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Parameter Patch File|*.ini";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string importPath = open.FileName;
                IniData patchData = new FileIniDataParser().ReadFile(importPath);

                for (int i = 0; i < fileList.Items.Count; i++)
                {
                    if (patchData.Sections.ContainsSection(fileList.Items[i].ToString()))
                    {
                        string filename = fileList.Items[i].ToString();
                        for (int j = 0; j < paramData[filename].Parameters.Count; j++)
                        {
                            if (patchData.Sections[filename].ContainsKey(j.ToString()))
                            {
                                paramData[filename].Parameters[j] = uint.Parse(patchData.Sections[filename][j.ToString()], System.Globalization.NumberStyles.HexNumber);
                            }
                        }
                    }
                }
                UpdateINI();
                RefreshReference();
                valueList.Items.Clear();
                hexData.Text = "";
                intData.Text = "";
                floatData.Text = "";
                hexDataOrig.Text = "";
                intDataOrig.Text = "";
                floatDataOrig.Text = "";
            }
        }
        private void generatePatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "New Patch";
            save.AddExtension = true;
            save.Filter = "Parameter Patch File|*.ini";
            if (save.ShowDialog() == DialogResult.OK)
            {
                IniData patch = new IniData();

                for (int i = 0; i < fileList.Items.Count; i++)
                {
                    string filename = fileList.Items[i].ToString();
                    for (int j = 0; j < paramData[filename].Parameters.Count; j++)
                    {
                        if (paramData[filename].Parameters[j] != refData[filename].Parameters[j])
                        {
                            if (!patch.Sections.ContainsSection(filename))
                            {
                                patch.Sections.AddSection(filename);
                            }
                            patch.Sections[filename].AddKey(j.ToString(), paramData[filename].Parameters[j].ToString("X8"));
                        }
                    }
                }
                new FileIniDataParser().WriteFile(save.FileName, patch);
            }
        }
        private void decompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "LZ11 Compressed File|*.cmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Process decompress = new Process();
                decompress.StartInfo = lzxDecompressFile(open.FileName);
                decompress.Start();
                decompress.WaitForExit();
                decompress.Dispose();
                string newPath = open.FileName;
                if (open.FileName.EndsWith(".cmp"))
                {
                    newPath = open.FileName.Substring(0, open.FileName.Length - 4);
                    File.Copy(open.FileName, newPath, true);
                    File.Delete(open.FileName);
                }
            }
        }

        private void recompressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Process recompress = new Process();
                recompress.StartInfo = lzxCompressFile(open.FileName);
                recompress.Start();
                recompress.WaitForExit();
                recompress.Dispose();
                string newPath = open.FileName;
                if (!open.FileName.EndsWith(".cmp"))
                {
                    newPath = open.FileName + ".cmp";
                    File.Copy(open.FileName, newPath, true);
                    File.Delete(open.FileName);
                }
            }
        }

        private void setLabel_Click(object sender, EventArgs e)
        {
            // Get Selected Param Group and Entry, remove the existing labels if they exist
            string f = fileList.SelectedItem.ToString();
            string v = valueList.SelectedIndex.ToString();
            if (!labelData.Sections.ContainsSection(f))
                labelData.Sections.AddSection(f);
            if (labelData.Sections[f].ContainsKey(v))
                labelData.Sections[f].RemoveKey(v);
            if (labelData.Sections[f].ContainsKey(v + "D"))
                labelData.Sections[f].RemoveKey(v + "D");

            // Set new labels
            
            if (!String.IsNullOrEmpty(labelBox.Text))
                labelData.Sections[f].AddKey(v, labelBox.Text);
            if (!String.IsNullOrEmpty(descriptionBox.Text))
            {
                string neoDescript = descriptionBox.Text.Replace(Environment.NewLine, "<br>");
                labelData.Sections[f].AddKey(v + "D", neoDescript);
            }
                

            // Write to labels.ini
            new FileIniDataParser().WriteFile(Directory.GetCurrentDirectory() + "\\labels.ini", labelData);

            int prevF = fileList.SelectedIndex;
            int prevV = valueList.SelectedIndex;
            valueList.Items.Clear();
            UpdateFileList();
            fileList.SelectedIndex = prevF;
            valueList.SelectedIndex = prevV;
        }

        private void clrLabel_Click(object sender, EventArgs e)
        {
            string f = fileList.SelectedItem.ToString();
            string v = valueList.SelectedIndex.ToString();
            if (labelData.Sections.ContainsSection(f))
            {
                if (labelData.Sections[f].ContainsKey(v))
                    labelData.Sections[f].RemoveKey(v);
                if (labelData.Sections[f].ContainsKey(v + "D"))
                    labelData.Sections[f].RemoveKey(v + "D");
            }

            // Write to labels.ini
            new FileIniDataParser().WriteFile(Directory.GetCurrentDirectory() + "\\labels.ini", labelData);

            int prevF = fileList.SelectedIndex;
            int prevV = valueList.SelectedIndex;
            valueList.Items.Clear();
            UpdateFileList();
            fileList.SelectedIndex = prevF;
            valueList.SelectedIndex = prevV;
        }
        public ProcessStartInfo lzxDecompressFile(string filepath)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = $"\"{AppDomain.CurrentDomain.BaseDirectory}\\lzx.exe\"",
                Arguments = $" -d \"{filepath}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            return processStartInfo;
        }
        public ProcessStartInfo lzxCompressFile(string filepath)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = $"\"{AppDomain.CurrentDomain.BaseDirectory}\\lzx.exe\"",
                Arguments = $" -evb \"{filepath}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            return processStartInfo;
        }
    }
}
