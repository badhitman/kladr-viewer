namespace KLADR_viewer_v4
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.groupBoxTimeAutCash = new System.Windows.Forms.GroupBox();
            this.label_ms = new System.Windows.Forms.Label();
            this.labelTimeAutCash = new System.Windows.Forms.Label();
            this.comboBoxCacheTimeOut = new System.Windows.Forms.ComboBox();
            this.groupBoxFolderDatabaseProgram = new System.Windows.Forms.GroupBox();
            this.labelFolderDatabaseProgram = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxSelectFolder = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxLanguageApplication = new System.Windows.Forms.GroupBox();
            this.labelChoseLangProgramm = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.groupBoxTimeAutCash.SuspendLayout();
            this.groupBoxFolderDatabaseProgram.SuspendLayout();
            this.groupBoxLanguageApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTimeAutCash
            // 
            this.groupBoxTimeAutCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTimeAutCash.Controls.Add(this.label_ms);
            this.groupBoxTimeAutCash.Controls.Add(this.labelTimeAutCash);
            this.groupBoxTimeAutCash.Controls.Add(this.comboBoxCacheTimeOut);
            this.groupBoxTimeAutCash.Location = new System.Drawing.Point(12, 67);
            this.groupBoxTimeAutCash.Name = "groupBoxTimeAutCash";
            this.groupBoxTimeAutCash.Size = new System.Drawing.Size(531, 95);
            this.groupBoxTimeAutCash.TabIndex = 9;
            this.groupBoxTimeAutCash.TabStop = false;
            this.groupBoxTimeAutCash.Text = "Engine cache timeout";
            // 
            // label_ms
            // 
            this.label_ms.AutoSize = true;
            this.label_ms.Location = new System.Drawing.Point(97, 72);
            this.label_ms.Name = "label_ms";
            this.label_ms.Size = new System.Drawing.Size(63, 13);
            this.label_ms.TabIndex = 11;
            this.label_ms.Text = "milliseconds";
            // 
            // labelTimeAutCash
            // 
            this.labelTimeAutCash.AutoSize = true;
            this.labelTimeAutCash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTimeAutCash.Location = new System.Drawing.Point(6, 16);
            this.labelTimeAutCash.Name = "labelTimeAutCash";
            this.labelTimeAutCash.Size = new System.Drawing.Size(460, 39);
            this.labelTimeAutCash.TabIndex = 10;
            this.labelTimeAutCash.Text = resources.GetString("labelTimeAutCash.Text");
            // 
            // comboBoxCacheTimeOut
            // 
            this.comboBoxCacheTimeOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCacheTimeOut.FormattingEnabled = true;
            this.comboBoxCacheTimeOut.Items.AddRange(new object[] {
            "no cache",
            "cache all",
            "50",
            "100",
            "150",
            "300",
            "700"});
            this.comboBoxCacheTimeOut.Location = new System.Drawing.Point(6, 64);
            this.comboBoxCacheTimeOut.Name = "comboBoxCacheTimeOut";
            this.comboBoxCacheTimeOut.Size = new System.Drawing.Size(85, 21);
            this.comboBoxCacheTimeOut.TabIndex = 2;
            this.comboBoxCacheTimeOut.SelectedIndexChanged += new System.EventHandler(this.comboBoxCache_TextChanged);
            this.comboBoxCacheTimeOut.TextChanged += new System.EventHandler(this.comboBoxCache_TextChanged);
            // 
            // groupBoxFolderDatabaseProgram
            // 
            this.groupBoxFolderDatabaseProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFolderDatabaseProgram.Controls.Add(this.labelFolderDatabaseProgram);
            this.groupBoxFolderDatabaseProgram.Controls.Add(this.buttonSelectFolder);
            this.groupBoxFolderDatabaseProgram.Controls.Add(this.textBoxSelectFolder);
            this.groupBoxFolderDatabaseProgram.Location = new System.Drawing.Point(12, 168);
            this.groupBoxFolderDatabaseProgram.Name = "groupBoxFolderDatabaseProgram";
            this.groupBoxFolderDatabaseProgram.Size = new System.Drawing.Size(531, 92);
            this.groupBoxFolderDatabaseProgram.TabIndex = 12;
            this.groupBoxFolderDatabaseProgram.TabStop = false;
            this.groupBoxFolderDatabaseProgram.Text = "Folder database program";
            // 
            // labelFolderDatabaseProgram
            // 
            this.labelFolderDatabaseProgram.AutoSize = true;
            this.labelFolderDatabaseProgram.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelFolderDatabaseProgram.Location = new System.Drawing.Point(6, 16);
            this.labelFolderDatabaseProgram.Name = "labelFolderDatabaseProgram";
            this.labelFolderDatabaseProgram.Size = new System.Drawing.Size(430, 39);
            this.labelFolderDatabaseProgram.TabIndex = 13;
            this.labelFolderDatabaseProgram.Text = resources.GetString("labelFolderDatabaseProgram.Text");
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectFolder.Location = new System.Drawing.Point(497, 63);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectFolder.TabIndex = 4;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // textBoxSelectFolder
            // 
            this.textBoxSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectFolder.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectFolder.Location = new System.Drawing.Point(6, 65);
            this.textBoxSelectFolder.Name = "textBoxSelectFolder";
            this.textBoxSelectFolder.ReadOnly = true;
            this.textBoxSelectFolder.Size = new System.Drawing.Size(485, 20);
            this.textBoxSelectFolder.TabIndex = 3;
            this.textBoxSelectFolder.Click += new System.EventHandler(this.textBoxSelectFolder_Click);
            this.textBoxSelectFolder.DoubleClick += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(12, 268);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.Location = new System.Drawing.Point(392, 268);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(151, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset to Defaults";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxLanguageApplication
            // 
            this.groupBoxLanguageApplication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLanguageApplication.Controls.Add(this.labelChoseLangProgramm);
            this.groupBoxLanguageApplication.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLanguageApplication.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLanguageApplication.Name = "groupBoxLanguageApplication";
            this.groupBoxLanguageApplication.Size = new System.Drawing.Size(531, 49);
            this.groupBoxLanguageApplication.TabIndex = 7;
            this.groupBoxLanguageApplication.TabStop = false;
            this.groupBoxLanguageApplication.Text = "Language of application";
            // 
            // labelChoseLangProgramm
            // 
            this.labelChoseLangProgramm.AutoSize = true;
            this.labelChoseLangProgramm.Location = new System.Drawing.Point(202, 22);
            this.labelChoseLangProgramm.Name = "labelChoseLangProgramm";
            this.labelChoseLangProgramm.Size = new System.Drawing.Size(261, 13);
            this.labelChoseLangProgramm.TabIndex = 8;
            this.labelChoseLangProgramm.Text = "Please choose the preferred language for the program";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(9, 19);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(187, 21);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_TextChanged);
            this.comboBoxLanguage.TextChanged += new System.EventHandler(this.comboBoxLanguage_TextChanged);
            // 
            // FormSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 299);
            this.Controls.Add(this.groupBoxLanguageApplication);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxFolderDatabaseProgram);
            this.Controls.Add(this.groupBoxTimeAutCash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettings_FormClosed);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBoxTimeAutCash.ResumeLayout(false);
            this.groupBoxTimeAutCash.PerformLayout();
            this.groupBoxFolderDatabaseProgram.ResumeLayout(false);
            this.groupBoxFolderDatabaseProgram.PerformLayout();
            this.groupBoxLanguageApplication.ResumeLayout(false);
            this.groupBoxLanguageApplication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTimeAutCash;
        private System.Windows.Forms.GroupBox groupBoxFolderDatabaseProgram;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TextBox textBoxSelectFolder;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxCacheTimeOut;
        private System.Windows.Forms.Label labelFolderDatabaseProgram;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelTimeAutCash;
        private System.Windows.Forms.Label label_ms;
        private System.Windows.Forms.GroupBox groupBoxLanguageApplication;
        private System.Windows.Forms.Label labelChoseLangProgramm;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}