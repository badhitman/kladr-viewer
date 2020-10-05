using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using KLADR_viewer_v4.my_classes;

namespace KLADR_viewer_v4
{
    public partial class FormKLADRtoCSV : Form
    {
        public bool notCloseForm = false;

        my_classes.ConvertDBFtoCSV convertClass;

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (!notCloseForm && msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Key Overrided Events Error:" + Ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public FormKLADRtoCSV()
        {
            InitializeComponent();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            string latest_select_folder = regKey.GetValue("latest_select_folder", "").ToString();

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = latest_select_folder;
            OFD.CheckFileExists = true;
            OFD.CheckPathExists = true;
            OFD.DefaultExt = "dbf";
            OFD.Filter = "DBF files|*.DBF|All files *.*|*.*";
            OFD.SupportMultiDottedExtensions = true;
            OFD.Title = "Select *.dbf file of the classifier (or any other DBF file)";
            if (OFD.ShowDialog(this) != System.Windows.Forms.DialogResult.OK || !File.Exists(OFD.FileName))
                return;
            textBoxSelectFolder.Text = OFD.FileName;
            buttonImport.Enabled = true;
            convertClass = new my_classes.ConvertDBFtoCSV(textBoxSelectFolder.Text, this);
        }

        private void toolStripStatusLabelImportKLADRtoCSV_TextChanged(object sender, EventArgs e)
        {
            ToolStripStatusLabel currLabel =  ((ToolStripStatusLabel)sender);
            if (currLabel.Text != currLabel.Tag.ToString())
            {
                toolStripProgressBarKLADRtoCSV.Style = ProgressBarStyle.Marquee;
                notCloseForm = true;
                textBoxSelectFolder.Enabled = false;
                buttonSelectFolder.Enabled = false;
                buttonImport.Enabled = false;
                buttonClose.Enabled = false;
            }
            else
            {
                toolStripProgressBarKLADRtoCSV.Style = ProgressBarStyle.Blocks;
                notCloseForm = false;
                textBoxSelectFolder.Enabled = true;
                buttonSelectFolder.Enabled = true;
                buttonImport.Enabled = true;
                buttonClose.Enabled = true;
            }
        }

        private void FormKLADRtoCSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.notCloseForm)
                e.Cancel = true;
        }

        private void textBoxSelectFolder_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxSelectFolder.Text))
                return;
            buttonSelectFolder_Click(new object(), new EventArgs());
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxSelectFolder.Text))
                return;
            toolStripStatusLabelImportKLADRtoCSV.Text = "import started...";
            convertClass.StartConvert();
        }

        private void FormKLADRtoCSV_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelImportKLADRtoCSV.Tag = toolStripStatusLabelImportKLADRtoCSV.Text;
            global.RaiseCustomEvent += new EventHandler(updateLang);
            updateLang(null, null);
        }

        private void updateLang(object sender, EventArgs e) 
        {
            this.Text = language.formKLADRtoCSV._window_text;
            labelInfoConverter.Text = language.formKLADRtoCSV._label_info;
            buttonImport.Text = language.formKLADRtoCSV._button_import_text;
            buttonClose.Text = language.formKLADRtoCSV._button_close_text;
            toolStripStatusLabelImportKLADRtoCSV.Tag = language.formStart._status_label_text;
            toolStripStatusLabelImportKLADRtoCSV.Text = language.formStart._status_label_text;
        }
    }
}
