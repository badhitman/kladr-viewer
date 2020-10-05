namespace KLADR_viewer_v4
{
    partial class FormKLADRtoCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKLADRtoCSV));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxSelectFolder = new System.Windows.Forms.TextBox();
            this.statusStripKLADRtoCSV = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBarKLADRtoCSV = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelImportKLADRtoCSV = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelInfoConverter = new System.Windows.Forms.Label();
            this.statusStripKLADRtoCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(93, 148);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonImport.Enabled = false;
            this.buttonImport.Location = new System.Drawing.Point(12, 148);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 4;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(394, 116);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectFolder.TabIndex = 3;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // textBoxSelectFolder
            // 
            this.textBoxSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectFolder.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectFolder.Location = new System.Drawing.Point(12, 118);
            this.textBoxSelectFolder.Name = "textBoxSelectFolder";
            this.textBoxSelectFolder.ReadOnly = true;
            this.textBoxSelectFolder.Size = new System.Drawing.Size(376, 20);
            this.textBoxSelectFolder.TabIndex = 2;
            this.textBoxSelectFolder.Click += new System.EventHandler(this.textBoxSelectFolder_Click);
            this.textBoxSelectFolder.DoubleClick += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // statusStripKLADRtoCSV
            // 
            this.statusStripKLADRtoCSV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBarKLADRtoCSV,
            this.toolStripStatusLabelImportKLADRtoCSV});
            this.statusStripKLADRtoCSV.Location = new System.Drawing.Point(0, 174);
            this.statusStripKLADRtoCSV.Name = "statusStripKLADRtoCSV";
            this.statusStripKLADRtoCSV.Size = new System.Drawing.Size(434, 22);
            this.statusStripKLADRtoCSV.SizingGrip = false;
            this.statusStripKLADRtoCSV.TabIndex = 6;
            this.statusStripKLADRtoCSV.Text = "statusStrip1";
            // 
            // toolStripProgressBarKLADRtoCSV
            // 
            this.toolStripProgressBarKLADRtoCSV.Margin = new System.Windows.Forms.Padding(7, 3, 1, 3);
            this.toolStripProgressBarKLADRtoCSV.Name = "toolStripProgressBarKLADRtoCSV";
            this.toolStripProgressBarKLADRtoCSV.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabelImportKLADRtoCSV
            // 
            this.toolStripStatusLabelImportKLADRtoCSV.Name = "toolStripStatusLabelImportKLADRtoCSV";
            this.toolStripStatusLabelImportKLADRtoCSV.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabelImportKLADRtoCSV.Tag = "";
            this.toolStripStatusLabelImportKLADRtoCSV.Text = "Done";
            this.toolStripStatusLabelImportKLADRtoCSV.TextChanged += new System.EventHandler(this.toolStripStatusLabelImportKLADRtoCSV_TextChanged);
            // 
            // labelInfoConverter
            // 
            this.labelInfoConverter.AutoSize = true;
            this.labelInfoConverter.Location = new System.Drawing.Point(12, 9);
            this.labelInfoConverter.Name = "labelInfoConverter";
            this.labelInfoConverter.Size = new System.Drawing.Size(366, 91);
            this.labelInfoConverter.TabIndex = 7;
            this.labelInfoConverter.Text = resources.GetString("labelInfoConverter.Text");
            // 
            // FormKLADRtoCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 196);
            this.Controls.Add(this.labelInfoConverter);
            this.Controls.Add(this.statusStripKLADRtoCSV);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.textBoxSelectFolder);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKLADRtoCSV";
            this.Text = "converter/import *.DBF to *.CSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKLADRtoCSV_FormClosing);
            this.Load += new System.EventHandler(this.FormKLADRtoCSV_Load);
            this.statusStripKLADRtoCSV.ResumeLayout(false);
            this.statusStripKLADRtoCSV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TextBox textBoxSelectFolder;
        private System.Windows.Forms.StatusStrip statusStripKLADRtoCSV;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarKLADRtoCSV;
        private System.Windows.Forms.Label labelInfoConverter;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImportKLADRtoCSV;
    }
}