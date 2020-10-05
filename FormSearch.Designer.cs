namespace KLADR_viewer_v4
{
    partial class FormSearch
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
            this.treeViewSearch = new System.Windows.Forms.TreeView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelQuery = new System.Windows.Forms.Label();
            this.textBoxQuerySearch = new System.Windows.Forms.TextBox();
            this.dataGridViewResultSearch = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNINMBColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCATDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelWhereLook = new System.Windows.Forms.Label();
            this.buttonDeselectAll = new System.Windows.Forms.Button();
            this.buttonInvertSelect = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.statusStripSearch = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarSearch = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelSearch = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipSearch = new System.Windows.Forms.ToolTip(this.components);
            this.radioButtonCity = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonStreet = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultSearch)).BeginInit();
            this.statusStripSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewSearch
            // 
            this.treeViewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewSearch.CheckBoxes = true;
            this.treeViewSearch.Location = new System.Drawing.Point(12, 67);
            this.treeViewSearch.Name = "treeViewSearch";
            this.treeViewSearch.Size = new System.Drawing.Size(182, 307);
            this.treeViewSearch.TabIndex = 0;
            this.toolTipSearch.SetToolTip(this.treeViewSearch, "Selected regions of the search. Select all or desired regions.\r\nThe smaller the s" +
        "elected regions of the faster search.");
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(689, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(60, 23);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.toolTipSearch.SetToolTip(this.buttonSearch, "Start seqrch");
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonИскать_Click);
            // 
            // labelQuery
            // 
            this.labelQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new System.Drawing.Point(7, 11);
            this.labelQuery.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelQuery.Size = new System.Drawing.Size(38, 18);
            this.labelQuery.TabIndex = 4;
            this.labelQuery.Text = "Query:";
            // 
            // textBoxQuerySearch
            // 
            this.textBoxQuerySearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuerySearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxQuerySearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxQuerySearch.Location = new System.Drawing.Point(55, 13);
            this.textBoxQuerySearch.Name = "textBoxQuerySearch";
            this.textBoxQuerySearch.Size = new System.Drawing.Size(475, 20);
            this.textBoxQuerySearch.TabIndex = 3;
            this.toolTipSearch.SetToolTip(this.textBoxQuerySearch, "By default the search is case insensitive, but it is possible to search using T-S" +
        "QL expression and case sensitive \r\n(you put the expression in curly braces {}. E" +
        "xample {mySearchQueryCity ___}).");
            this.textBoxQuerySearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxИскать_KeyDown);
            // 
            // dataGridViewResultSearch
            // 
            this.dataGridViewResultSearch.AllowUserToAddRows = false;
            this.dataGridViewResultSearch.AllowUserToDeleteRows = false;
            this.dataGridViewResultSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResultSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResultSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewResultSearch.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResultSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewResultSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.CodeColumn,
            this.IndexColumn,
            this.GNINMBColumn,
            this.UNOColumn,
            this.OCATDColumn});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewResultSearch.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewResultSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewResultSearch.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewResultSearch.Location = new System.Drawing.Point(205, 38);
            this.dataGridViewResultSearch.Name = "dataGridViewResultSearch";
            this.dataGridViewResultSearch.ReadOnly = true;
            this.dataGridViewResultSearch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewResultSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewResultSearch.RowHeadersWidth = 4;
            this.dataGridViewResultSearch.Size = new System.Drawing.Size(544, 336);
            this.dataGridViewResultSearch.StandardTab = true;
            this.dataGridViewResultSearch.TabIndex = 6;
            this.toolTipSearch.SetToolTip(this.dataGridViewResultSearch, "Result data of search");
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // CodeColumn
            // 
            this.CodeColumn.HeaderText = "Code";
            this.CodeColumn.Name = "CodeColumn";
            this.CodeColumn.ReadOnly = true;
            // 
            // IndexColumn
            // 
            this.IndexColumn.HeaderText = "Index";
            this.IndexColumn.Name = "IndexColumn";
            this.IndexColumn.ReadOnly = true;
            // 
            // GNINMBColumn
            // 
            this.GNINMBColumn.HeaderText = "GNINMB";
            this.GNINMBColumn.Name = "GNINMBColumn";
            this.GNINMBColumn.ReadOnly = true;
            // 
            // UNOColumn
            // 
            this.UNOColumn.HeaderText = "UNO";
            this.UNOColumn.Name = "UNOColumn";
            this.UNOColumn.ReadOnly = true;
            // 
            // OCATDColumn
            // 
            this.OCATDColumn.HeaderText = "OCATD";
            this.OCATDColumn.Name = "OCATDColumn";
            this.OCATDColumn.ReadOnly = true;
            // 
            // labelWhereLook
            // 
            this.labelWhereLook.AutoSize = true;
            this.labelWhereLook.Location = new System.Drawing.Point(12, 44);
            this.labelWhereLook.Name = "labelWhereLook";
            this.labelWhereLook.Size = new System.Drawing.Size(71, 13);
            this.labelWhereLook.TabIndex = 7;
            this.labelWhereLook.Text = "where to look";
            // 
            // buttonDeselectAll
            // 
            this.buttonDeselectAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeselectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDeselectAll.BackgroundImage")));
            this.buttonDeselectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeselectAll.Location = new System.Drawing.Point(120, 40);
            this.buttonDeselectAll.Name = "buttonDeselectAll";
            this.buttonDeselectAll.Size = new System.Drawing.Size(23, 23);
            this.buttonDeselectAll.TabIndex = 8;
            this.toolTipSearch.SetToolTip(this.buttonDeselectAll, "Unselect all regions");
            this.buttonDeselectAll.UseVisualStyleBackColor = false;
            this.buttonDeselectAll.Click += new System.EventHandler(this.buttonUnselectAll_Click);
            // 
            // buttonInvertSelect
            // 
            this.buttonInvertSelect.BackColor = System.Drawing.SystemColors.Control;
            this.buttonInvertSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInvertSelect.BackgroundImage")));
            this.buttonInvertSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInvertSelect.Location = new System.Drawing.Point(146, 40);
            this.buttonInvertSelect.Name = "buttonInvertSelect";
            this.buttonInvertSelect.Size = new System.Drawing.Size(23, 23);
            this.buttonInvertSelect.TabIndex = 9;
            this.toolTipSearch.SetToolTip(this.buttonInvertSelect, "Invert select regions");
            this.buttonInvertSelect.UseVisualStyleBackColor = false;
            this.buttonInvertSelect.Click += new System.EventHandler(this.buttonInvertSelect_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectAll.BackgroundImage")));
            this.buttonSelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelectAll.Location = new System.Drawing.Point(172, 40);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(23, 23);
            this.buttonSelectAll.TabIndex = 10;
            this.toolTipSearch.SetToolTip(this.buttonSelectAll, "Select all regions");
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // statusStripSearch
            // 
            this.statusStripSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarSearch,
            this.toolStripStatusLabelSearch});
            this.statusStripSearch.Location = new System.Drawing.Point(0, 377);
            this.statusStripSearch.Name = "statusStripSearch";
            this.statusStripSearch.Size = new System.Drawing.Size(761, 22);
            this.statusStripSearch.TabIndex = 11;
            this.statusStripSearch.Text = "statusStrip1";
            // 
            // toolStripProgressBarSearch
            // 
            this.toolStripProgressBarSearch.Name = "toolStripProgressBarSearch";
            this.toolStripProgressBarSearch.Size = new System.Drawing.Size(250, 16);
            // 
            // toolStripStatusLabelSearch
            // 
            this.toolStripStatusLabelSearch.Name = "toolStripStatusLabelSearch";
            this.toolStripStatusLabelSearch.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabelSearch.Text = "Done.";
            this.toolStripStatusLabelSearch.TextChanged += new System.EventHandler(this.toolStripStatusLabelSearch_TextChanged);
            // 
            // radioButtonCity
            // 
            this.radioButtonCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonCity.AutoSize = true;
            this.radioButtonCity.Location = new System.Drawing.Point(582, 11);
            this.radioButtonCity.Name = "radioButtonCity";
            this.radioButtonCity.Size = new System.Drawing.Size(42, 17);
            this.radioButtonCity.TabIndex = 17;
            this.radioButtonCity.Text = "City";
            this.toolTipSearch.SetToolTip(this.radioButtonCity, "Search in the names communities (cities, towns, villages, etc.).");
            this.radioButtonCity.UseVisualStyleBackColor = true;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(532, 11);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(44, 17);
            this.radioButtonAll.TabIndex = 16;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "ALL";
            this.toolTipSearch.SetToolTip(this.radioButtonAll, "Search in the names All. Regions, Districts, Municipalities (cities, towns, villa" +
        "ges, etc.), Streets.");
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonStreet
            // 
            this.radioButtonStreet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonStreet.AutoSize = true;
            this.radioButtonStreet.Location = new System.Drawing.Point(630, 12);
            this.radioButtonStreet.Name = "radioButtonStreet";
            this.radioButtonStreet.Size = new System.Drawing.Size(53, 17);
            this.radioButtonStreet.TabIndex = 15;
            this.radioButtonStreet.Text = "Street";
            this.toolTipSearch.SetToolTip(this.radioButtonStreet, "Search in the names of streets.");
            this.radioButtonStreet.UseVisualStyleBackColor = true;
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 399);
            this.Controls.Add(this.labelQuery);
            this.Controls.Add(this.textBoxQuerySearch);
            this.Controls.Add(this.radioButtonAll);
            this.Controls.Add(this.radioButtonCity);
            this.Controls.Add(this.radioButtonStreet);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelWhereLook);
            this.Controls.Add(this.buttonDeselectAll);
            this.Controls.Add(this.buttonInvertSelect);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.dataGridViewResultSearch);
            this.Controls.Add(this.treeViewSearch);
            this.Controls.Add(this.statusStripSearch);
            this.Name = "FormSearch";
            this.Text = "Search in Classifier";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultSearch)).EndInit();
            this.statusStripSearch.ResumeLayout(false);
            this.statusStripSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelQuery;
        private System.Windows.Forms.TextBox textBoxQuerySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNINMBColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCATDColumn;
        private System.Windows.Forms.Label labelWhereLook;
        private System.Windows.Forms.Button buttonDeselectAll;
        private System.Windows.Forms.Button buttonInvertSelect;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.StatusStrip statusStripSearch;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarSearch;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSearch;
        public System.Windows.Forms.DataGridView dataGridViewResultSearch;
        private System.Windows.Forms.ToolTip toolTipSearch;
        private System.Windows.Forms.RadioButton radioButtonCity;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonStreet;
    }
}