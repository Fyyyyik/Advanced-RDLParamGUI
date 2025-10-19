namespace RDLParamGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadFromDolphinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            parameterPatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            generatePatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            compressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            decompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            recompressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            autocompressOnSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            fileList = new System.Windows.Forms.ListBox();
            label2 = new System.Windows.Forms.Label();
            valueList = new System.Windows.Forms.ListBox();
            hexData = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            intData = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            floatData = new System.Windows.Forms.TextBox();
            curDataBox = new System.Windows.Forms.GroupBox();
            refDataBox = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            floatDataOrig = new System.Windows.Forms.TextBox();
            hexDataOrig = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            intDataOrig = new System.Windows.Forms.TextBox();
            labelBox = new System.Windows.Forms.TextBox();
            setLabel = new System.Windows.Forms.Button();
            clrLabel = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            descriptionBox = new System.Windows.Forms.TextBox();
            menuStrip1.SuspendLayout();
            curDataBox.SuspendLayout();
            refDataBox.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, parameterPatchingToolStripMenuItem, updateLabelsToolStripMenuItem, compressionToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(774, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, openReferenceToolStripMenuItem, loadFromDolphinToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            openToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openReferenceToolStripMenuItem
            // 
            openReferenceToolStripMenuItem.Name = "openReferenceToolStripMenuItem";
            openReferenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.O;
            openReferenceToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            openReferenceToolStripMenuItem.Text = "Open Reference";
            openReferenceToolStripMenuItem.Click += openReferenceToolStripMenuItem_Click;
            // 
            // loadFromDolphinToolStripMenuItem
            // 
            loadFromDolphinToolStripMenuItem.Name = "loadFromDolphinToolStripMenuItem";
            loadFromDolphinToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            loadFromDolphinToolStripMenuItem.Text = "Load From Dolphin";
            loadFromDolphinToolStripMenuItem.Click += loadFromDolphinToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.S;
            saveAsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // parameterPatchingToolStripMenuItem
            // 
            parameterPatchingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { importPatchToolStripMenuItem, generatePatchToolStripMenuItem });
            parameterPatchingToolStripMenuItem.Enabled = false;
            parameterPatchingToolStripMenuItem.Name = "parameterPatchingToolStripMenuItem";
            parameterPatchingToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            parameterPatchingToolStripMenuItem.Text = "Patching";
            // 
            // importPatchToolStripMenuItem
            // 
            importPatchToolStripMenuItem.Name = "importPatchToolStripMenuItem";
            importPatchToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            importPatchToolStripMenuItem.Text = "Import Patch";
            importPatchToolStripMenuItem.Click += importPatchToolStripMenuItem_Click;
            // 
            // generatePatchToolStripMenuItem
            // 
            generatePatchToolStripMenuItem.Name = "generatePatchToolStripMenuItem";
            generatePatchToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            generatePatchToolStripMenuItem.Text = "Generate Patch";
            generatePatchToolStripMenuItem.Click += generatePatchToolStripMenuItem_Click;
            // 
            // updateLabelsToolStripMenuItem
            // 
            updateLabelsToolStripMenuItem.Enabled = false;
            updateLabelsToolStripMenuItem.Name = "updateLabelsToolStripMenuItem";
            updateLabelsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            updateLabelsToolStripMenuItem.Text = "Refresh";
            updateLabelsToolStripMenuItem.Click += updateLabelsToolStripMenuItem_Click;
            // 
            // compressionToolStripMenuItem
            // 
            compressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { decompressToolStripMenuItem, recompressToolStripMenuItem, autocompressOnSaveToolStripMenuItem });
            compressionToolStripMenuItem.Name = "compressionToolStripMenuItem";
            compressionToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            compressionToolStripMenuItem.Text = "Compression";
            // 
            // decompressToolStripMenuItem
            // 
            decompressToolStripMenuItem.Name = "decompressToolStripMenuItem";
            decompressToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D;
            decompressToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            decompressToolStripMenuItem.Text = "Decompress File";
            decompressToolStripMenuItem.Click += decompressToolStripMenuItem_Click;
            // 
            // recompressToolStripMenuItem
            // 
            recompressToolStripMenuItem.Name = "recompressToolStripMenuItem";
            recompressToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.D;
            recompressToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            recompressToolStripMenuItem.Text = "Compress File";
            recompressToolStripMenuItem.Click += recompressToolStripMenuItem_Click;
            // 
            // autocompressOnSaveToolStripMenuItem
            // 
            autocompressOnSaveToolStripMenuItem.Checked = true;
            autocompressOnSaveToolStripMenuItem.CheckOnClick = true;
            autocompressOnSaveToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            autocompressOnSaveToolStripMenuItem.Name = "autocompressOnSaveToolStripMenuItem";
            autocompressOnSaveToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            autocompressOnSaveToolStripMenuItem.Text = "Autocompress .cmp Files On Save";
            autocompressOnSaveToolStripMenuItem.CheckedChanged += autocompressOnSaveToolStripMenuItem_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(15, 32);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 15);
            label1.TabIndex = 1;
            label1.Text = "Param Files";
            // 
            // fileList
            // 
            fileList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            fileList.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            fileList.ForeColor = System.Drawing.SystemColors.Window;
            fileList.FormattingEnabled = true;
            fileList.HorizontalScrollbar = true;
            fileList.ItemHeight = 15;
            fileList.Location = new System.Drawing.Point(18, 52);
            fileList.Margin = new System.Windows.Forms.Padding(4);
            fileList.Name = "fileList";
            fileList.Size = new System.Drawing.Size(286, 529);
            fileList.TabIndex = 2;
            fileList.SelectedIndexChanged += fileList_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(311, 33);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "Values";
            // 
            // valueList
            // 
            valueList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            valueList.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            valueList.ForeColor = System.Drawing.SystemColors.Window;
            valueList.FormattingEnabled = true;
            valueList.HorizontalScrollbar = true;
            valueList.ItemHeight = 15;
            valueList.Location = new System.Drawing.Point(311, 52);
            valueList.Margin = new System.Windows.Forms.Padding(4);
            valueList.Name = "valueList";
            valueList.Size = new System.Drawing.Size(267, 454);
            valueList.TabIndex = 5;
            valueList.SelectedIndexChanged += valueList_SelectedIndexChanged;
            // 
            // hexData
            // 
            hexData.Location = new System.Drawing.Point(10, 38);
            hexData.Margin = new System.Windows.Forms.Padding(4);
            hexData.Name = "hexData";
            hexData.Size = new System.Drawing.Size(77, 23);
            hexData.TabIndex = 6;
            hexData.TextChanged += hexData_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 19);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 15);
            label3.TabIndex = 7;
            label3.Text = "Hex";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 65);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(41, 15);
            label4.TabIndex = 8;
            label4.Text = "UInt32";
            // 
            // intData
            // 
            intData.Location = new System.Drawing.Point(10, 83);
            intData.Margin = new System.Windows.Forms.Padding(4);
            intData.Name = "intData";
            intData.Size = new System.Drawing.Size(148, 23);
            intData.TabIndex = 9;
            intData.TextChanged += intData_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 110);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 15);
            label5.TabIndex = 10;
            label5.Text = "Float";
            // 
            // floatData
            // 
            floatData.Location = new System.Drawing.Point(10, 129);
            floatData.Margin = new System.Windows.Forms.Padding(4);
            floatData.Name = "floatData";
            floatData.Size = new System.Drawing.Size(148, 23);
            floatData.TabIndex = 11;
            floatData.TextChanged += floatData_TextChanged;
            // 
            // curDataBox
            // 
            curDataBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            curDataBox.Controls.Add(label3);
            curDataBox.Controls.Add(floatData);
            curDataBox.Controls.Add(hexData);
            curDataBox.Controls.Add(label5);
            curDataBox.Controls.Add(label4);
            curDataBox.Controls.Add(intData);
            curDataBox.ForeColor = System.Drawing.SystemColors.Control;
            curDataBox.Location = new System.Drawing.Point(585, 52);
            curDataBox.Margin = new System.Windows.Forms.Padding(4);
            curDataBox.Name = "curDataBox";
            curDataBox.Padding = new System.Windows.Forms.Padding(4);
            curDataBox.Size = new System.Drawing.Size(172, 167);
            curDataBox.TabIndex = 12;
            curDataBox.TabStop = false;
            curDataBox.Text = "Current Data";
            // 
            // refDataBox
            // 
            refDataBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            refDataBox.Controls.Add(label6);
            refDataBox.Controls.Add(floatDataOrig);
            refDataBox.Controls.Add(hexDataOrig);
            refDataBox.Controls.Add(label7);
            refDataBox.Controls.Add(label8);
            refDataBox.Controls.Add(intDataOrig);
            refDataBox.ForeColor = System.Drawing.SystemColors.Control;
            refDataBox.Location = new System.Drawing.Point(585, 226);
            refDataBox.Margin = new System.Windows.Forms.Padding(4);
            refDataBox.Name = "refDataBox";
            refDataBox.Padding = new System.Windows.Forms.Padding(4);
            refDataBox.Size = new System.Drawing.Size(172, 167);
            refDataBox.TabIndex = 13;
            refDataBox.TabStop = false;
            refDataBox.Text = "Reference Data";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 19);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(27, 15);
            label6.TabIndex = 7;
            label6.Text = "Hex";
            // 
            // floatDataOrig
            // 
            floatDataOrig.Location = new System.Drawing.Point(10, 129);
            floatDataOrig.Margin = new System.Windows.Forms.Padding(4);
            floatDataOrig.Name = "floatDataOrig";
            floatDataOrig.ReadOnly = true;
            floatDataOrig.Size = new System.Drawing.Size(148, 23);
            floatDataOrig.TabIndex = 11;
            // 
            // hexDataOrig
            // 
            hexDataOrig.Location = new System.Drawing.Point(10, 38);
            hexDataOrig.Margin = new System.Windows.Forms.Padding(4);
            hexDataOrig.Name = "hexDataOrig";
            hexDataOrig.ReadOnly = true;
            hexDataOrig.Size = new System.Drawing.Size(77, 23);
            hexDataOrig.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(7, 110);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(33, 15);
            label7.TabIndex = 10;
            label7.Text = "Float";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(7, 65);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(41, 15);
            label8.TabIndex = 8;
            label8.Text = "UInt32";
            // 
            // intDataOrig
            // 
            intDataOrig.Location = new System.Drawing.Point(10, 83);
            intDataOrig.Margin = new System.Windows.Forms.Padding(4);
            intDataOrig.Name = "intDataOrig";
            intDataOrig.ReadOnly = true;
            intDataOrig.Size = new System.Drawing.Size(148, 23);
            intDataOrig.TabIndex = 9;
            // 
            // labelBox
            // 
            labelBox.Location = new System.Drawing.Point(7, 22);
            labelBox.Margin = new System.Windows.Forms.Padding(4);
            labelBox.Name = "labelBox";
            labelBox.Size = new System.Drawing.Size(159, 23);
            labelBox.TabIndex = 12;
            // 
            // setLabel
            // 
            setLabel.ForeColor = System.Drawing.Color.Black;
            setLabel.Location = new System.Drawing.Point(7, 49);
            setLabel.Name = "setLabel";
            setLabel.Size = new System.Drawing.Size(76, 41);
            setLabel.TabIndex = 14;
            setLabel.Text = "Set\r\nLabel";
            setLabel.UseVisualStyleBackColor = true;
            setLabel.Click += setLabel_Click;
            // 
            // clrLabel
            // 
            clrLabel.ForeColor = System.Drawing.Color.Black;
            clrLabel.Location = new System.Drawing.Point(89, 49);
            clrLabel.Name = "clrLabel";
            clrLabel.Size = new System.Drawing.Size(76, 41);
            clrLabel.TabIndex = 15;
            clrLabel.Text = "Clear\r\nLabel";
            clrLabel.UseVisualStyleBackColor = true;
            clrLabel.Click += clrLabel_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(labelBox);
            groupBox3.Controls.Add(clrLabel);
            groupBox3.Controls.Add(setLabel);
            groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            groupBox3.Location = new System.Drawing.Point(585, 400);
            groupBox3.Margin = new System.Windows.Forms.Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4);
            groupBox3.Size = new System.Drawing.Size(172, 105);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Entry Labels";
            // 
            // descriptionBox
            // 
            descriptionBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            descriptionBox.Location = new System.Drawing.Point(311, 512);
            descriptionBox.Multiline = true;
            descriptionBox.Name = "descriptionBox";
            descriptionBox.Size = new System.Drawing.Size(448, 69);
            descriptionBox.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            ClientSize = new System.Drawing.Size(774, 592);
            Controls.Add(descriptionBox);
            Controls.Add(groupBox3);
            Controls.Add(refDataBox);
            Controls.Add(curDataBox);
            Controls.Add(valueList);
            Controls.Add(label2);
            Controls.Add(fileList);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(790, 565);
            Name = "Form1";
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "RDLParamEdit - Dreamixed";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            curDataBox.ResumeLayout(false);
            curDataBox.PerformLayout();
            refDataBox.ResumeLayout(false);
            refDataBox.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox valueList;
        private System.Windows.Forms.TextBox hexData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox intData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox floatData;
        private System.Windows.Forms.GroupBox curDataBox;
        private System.Windows.Forms.GroupBox refDataBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox floatDataOrig;
        private System.Windows.Forms.TextBox hexDataOrig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox intDataOrig;
        private System.Windows.Forms.ToolStripMenuItem updateLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterPatchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recompressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocompressOnSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openReferenceToolStripMenuItem;
        private System.Windows.Forms.TextBox labelBox;
        private System.Windows.Forms.Button setLabel;
        private System.Windows.Forms.Button clrLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.ToolStripMenuItem loadFromDolphinToolStripMenuItem;
    }
}

