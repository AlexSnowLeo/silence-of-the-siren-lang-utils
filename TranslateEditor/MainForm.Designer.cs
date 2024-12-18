namespace TranslateEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            cbFiles = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            tbSearch = new ToolStripTextBox();
            gridLang = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            FirstLang = new DataGridViewTextBoxColumn();
            SecondLang = new DataGridViewTextBoxColumn();
            statusStrip.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLang).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 793);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1287, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(30, 17);
            toolStripStatusLabel1.Text = "data";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { cbFiles, toolStripLabel1, tbSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1287, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // cbFiles
            // 
            cbFiles.Name = "cbFiles";
            cbFiles.Size = new Size(250, 25);
            cbFiles.SelectedIndexChanged += cbFiles_SelectedIndexChanged;
            cbFiles.SelectedChanged += cbFiles_SelectedChanged;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 22);
            toolStripLabel1.Text = "Search:";
            // 
            // tbSearch
            // 
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(200, 25);
            tbSearch.KeyPress += tbSearch_KeyPress;
            // 
            // gridLang
            // 
            gridLang.AllowUserToAddRows = false;
            gridLang.AllowUserToDeleteRows = false;
            gridLang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridLang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLang.Columns.AddRange(new DataGridViewColumn[] { Key, FirstLang, SecondLang });
            gridLang.Dock = DockStyle.Fill;
            gridLang.Location = new Point(0, 25);
            gridLang.Name = "gridLang";
            gridLang.RowHeadersVisible = false;
            gridLang.Size = new Size(1287, 768);
            gridLang.TabIndex = 2;
            gridLang.CellEndEdit += gridLang_CellEndEdit;
            // 
            // Key
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Key.DefaultCellStyle = dataGridViewCellStyle1;
            Key.FillWeight = 200F;
            Key.Frozen = true;
            Key.HeaderText = "KEY";
            Key.Name = "Key";
            Key.Width = 200;
            // 
            // FirstLang
            // 
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            FirstLang.DefaultCellStyle = dataGridViewCellStyle2;
            FirstLang.FillWeight = 500F;
            FirstLang.Frozen = true;
            FirstLang.HeaderText = "EN";
            FirstLang.Name = "FirstLang";
            FirstLang.Width = 500;
            // 
            // SecondLang
            // 
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            SecondLang.DefaultCellStyle = dataGridViewCellStyle3;
            SecondLang.FillWeight = 500F;
            SecondLang.HeaderText = "RU";
            SecondLang.Name = "SecondLang";
            SecondLang.Width = 500;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 815);
            Controls.Add(gridLang);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip);
            Name = "MainForm";
            Text = "Silence of the Siren Translate Editor";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStrip toolStrip1;
        private DataGridView gridLang;
        private ToolStripComboBox cbFiles;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn FirstLang;
        private DataGridViewTextBoxColumn SecondLang;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbSearch;
    }
}
