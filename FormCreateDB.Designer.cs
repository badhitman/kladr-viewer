namespace KLADR_viewer_v4
{
    partial class FormCreateDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateDB));
            this.textBoxSelectFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.labelFolderGNIVC = new System.Windows.Forms.Label();
            this.buttonStartTransfer = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelNameDataBase = new System.Windows.Forms.Label();
            this.textBoxNameFolderDB = new System.Windows.Forms.TextBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelCountRecords = new System.Windows.Forms.Label();
            this.progressBarLoader = new System.Windows.Forms.ProgressBar();
            this.toolTipCreateNewDataBase = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBoxSelectFolder
            // 
            this.textBoxSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectFolder.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectFolder.Location = new System.Drawing.Point(115, 34);
            this.textBoxSelectFolder.Name = "textBoxSelectFolder";
            this.textBoxSelectFolder.ReadOnly = true;
            this.textBoxSelectFolder.Size = new System.Drawing.Size(406, 20);
            this.textBoxSelectFolder.TabIndex = 0;
            this.toolTipCreateNewDataBase.SetToolTip(this.textBoxSelectFolder, resources.GetString("textBoxSelectFolder.ToolTip"));
            this.textBoxSelectFolder.Click += new System.EventHandler(this.textBoxSelectFolder_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(527, 31);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectFolder.TabIndex = 1;
            this.buttonSelectFolder.Text = "...";
            this.toolTipCreateNewDataBase.SetToolTip(this.buttonSelectFolder, resources.GetString("buttonSelectFolder.ToolTip"));
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // labelFolderGNIVC
            // 
            this.labelFolderGNIVC.AutoSize = true;
            this.labelFolderGNIVC.Location = new System.Drawing.Point(12, 37);
            this.labelFolderGNIVC.Name = "labelFolderGNIVC";
            this.labelFolderGNIVC.Size = new System.Drawing.Size(97, 13);
            this.labelFolderGNIVC.TabIndex = 2;
            this.labelFolderGNIVC.Text = "Folder DB ГНИВЦ:";
            this.toolTipCreateNewDataBase.SetToolTip(this.labelFolderGNIVC, resources.GetString("labelFolderGNIVC.ToolTip"));
            // 
            // buttonStartTransfer
            // 
            this.buttonStartTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStartTransfer.Enabled = false;
            this.buttonStartTransfer.Location = new System.Drawing.Point(12, 279);
            this.buttonStartTransfer.Name = "buttonStartTransfer";
            this.buttonStartTransfer.Size = new System.Drawing.Size(86, 23);
            this.buttonStartTransfer.TabIndex = 27;
            this.buttonStartTransfer.Text = "Start transfer";
            this.buttonStartTransfer.UseVisualStyleBackColor = true;
            this.buttonStartTransfer.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(104, 279);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(86, 23);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // labelNameDataBase
            // 
            this.labelNameDataBase.AutoSize = true;
            this.labelNameDataBase.Location = new System.Drawing.Point(12, 11);
            this.labelNameDataBase.Name = "labelNameDataBase";
            this.labelNameDataBase.Size = new System.Drawing.Size(85, 13);
            this.labelNameDataBase.TabIndex = 30;
            this.labelNameDataBase.Text = "Name database:";
            this.toolTipCreateNewDataBase.SetToolTip(this.labelNameDataBase, "The name of the database (including the name of the folder in windows)");
            // 
            // textBoxNameFolderDB
            // 
            this.textBoxNameFolderDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNameFolderDB.Location = new System.Drawing.Point(115, 8);
            this.textBoxNameFolderDB.Name = "textBoxNameFolderDB";
            this.textBoxNameFolderDB.Size = new System.Drawing.Size(440, 20);
            this.textBoxNameFolderDB.TabIndex = 31;
            this.toolTipCreateNewDataBase.SetToolTip(this.textBoxNameFolderDB, "The name of the database (including the name of the folder in windows)");
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxLog.Location = new System.Drawing.Point(12, 60);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(543, 187);
            this.textBoxLog.TabIndex = 32;
            this.toolTipCreateNewDataBase.SetToolTip(this.textBoxLog, "Progress import the database into the program");
            // 
            // labelCountRecords
            // 
            this.labelCountRecords.AutoSize = true;
            this.labelCountRecords.Location = new System.Drawing.Point(283, 216);
            this.labelCountRecords.Name = "labelCountRecords";
            this.labelCountRecords.Size = new System.Drawing.Size(0, 13);
            this.labelCountRecords.TabIndex = 33;
            // 
            // progressBarLoader
            // 
            this.progressBarLoader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarLoader.Location = new System.Drawing.Point(10, 253);
            this.progressBarLoader.Name = "progressBarLoader";
            this.progressBarLoader.Size = new System.Drawing.Size(545, 20);
            this.progressBarLoader.TabIndex = 34;
            this.toolTipCreateNewDataBase.SetToolTip(this.progressBarLoader, "Progress import the database into the program");
            // 
            // FormCreateDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(567, 315);
            this.Controls.Add(this.progressBarLoader);
            this.Controls.Add(this.labelCountRecords);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.textBoxNameFolderDB);
            this.Controls.Add(this.labelNameDataBase);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStartTransfer);
            this.Controls.Add(this.labelFolderGNIVC);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.textBoxSelectFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCreateDB";
            this.Text = "Create new Data Base";
            this.Load += new System.EventHandler(this.FormCreateDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSelectFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Label labelFolderGNIVC;
        private System.Windows.Forms.Button buttonStartTransfer;
        private System.Windows.Forms.Label labelNameDataBase;
        private System.Windows.Forms.TextBox textBoxNameFolderDB;
        public System.Windows.Forms.TextBox textBoxLog;
        public System.Windows.Forms.Label labelCountRecords;
        public System.Windows.Forms.Button buttonClose;
        public System.Windows.Forms.ProgressBar progressBarLoader;
        private System.Windows.Forms.ToolTip toolTipCreateNewDataBase;
    }
}