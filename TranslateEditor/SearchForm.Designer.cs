namespace TranslateEditor
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tbSearch = new ToolStripTextBox();
            btnSearch = new ToolStripButton();
            gridLang = new DataGridView();
            statusStrip1 = new StatusStrip();
            lbSearchCount = new ToolStripStatusLabel();
            FileName = new DataGridViewTextBoxColumn();
            Key = new DataGridViewTextBoxColumn();
            FirstLang = new DataGridViewTextBoxColumn();
            SecondLang = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridLang).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tbSearch, btnSearch });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1384, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "Search:";
            // 
            // tbSearch
            // 
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(250, 25);
            tbSearch.KeyPress += tbSearch_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(78, 22);
            btnSearch.Text = "SEARCH ALL";
            btnSearch.Click += btnSearch_Click;
            // 
            // gridLang
            // 
            gridLang.AllowUserToAddRows = false;
            gridLang.AllowUserToDeleteRows = false;
            gridLang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridLang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLang.Columns.AddRange(new DataGridViewColumn[] { FileName, Key, FirstLang, SecondLang });
            gridLang.Dock = DockStyle.Fill;
            gridLang.Location = new Point(0, 25);
            gridLang.Name = "gridLang";
            gridLang.RowHeadersVisible = false;
            gridLang.Size = new Size(1384, 736);
            gridLang.TabIndex = 3;
            gridLang.CellDoubleClick += gridLang_CellDoubleClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbSearchCount });
            statusStrip1.Location = new Point(0, 739);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1384, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbSearchCount
            // 
            lbSearchCount.Name = "lbSearchCount";
            lbSearchCount.Size = new Size(82, 17);
            lbSearchCount.Text = "Search count: ";
            // 
            // FileName
            // 
            FileName.Frozen = true;
            FileName.HeaderText = "BASE FILE";
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            FileName.Width = 250;
            // 
            // Key
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Key.DefaultCellStyle = dataGridViewCellStyle1;
            Key.FillWeight = 200F;
            Key.Frozen = true;
            Key.HeaderText = "LocID";
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
            FirstLang.Width = 450;
            // 
            // SecondLang
            // 
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            SecondLang.DefaultCellStyle = dataGridViewCellStyle3;
            SecondLang.FillWeight = 500F;
            SecondLang.HeaderText = "RU";
            SecondLang.Name = "SecondLang";
            SecondLang.Width = 450;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 761);
            Controls.Add(statusStrip1);
            Controls.Add(gridLang);
            Controls.Add(toolStrip1);
            Name = "SearchForm";
            Text = "Search all";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridLang).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnSearch;
        private DataGridView gridLang;
        public ToolStripTextBox tbSearch;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbSearchCount;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn FirstLang;
        private DataGridViewTextBoxColumn SecondLang;
    }
}