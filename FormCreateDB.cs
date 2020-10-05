using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using KLADR_viewer_v4.management;
using KLADR_viewer_v4.my_classes;

namespace KLADR_viewer_v4
{
    public partial class FormCreateDB : Form
    {
        public FormCreateDB()
        {
            InitializeComponent();
        }

        public bool checkOriginalFolderGNIVC(string folderPatch)
        {
            if (textBoxNameFolderDB.Text.Trim() == "")
            {
                textBoxNameFolderDB.Text = "Base " + DateTime.Now.ToString().Replace(":", "-");
            }
            if (!File.Exists(folderPatch + "\\ALTNAMES.DBF") ||
                !File.Exists(folderPatch + "\\DOMA.DBF") ||
                !File.Exists(folderPatch + "\\FLAT.DBF") ||
                !File.Exists(folderPatch + "\\KLADR.DBF") ||
                !File.Exists(folderPatch + "\\SOCRBASE.DBF") ||
                !File.Exists(folderPatch + "\\STREET.DBF"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            if (progressBarLoader.Style == ProgressBarStyle.Continuous)
                return;
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            string latest_select_folder = regKey.GetValue("latest_select_folder", "").ToString();
            if (!checkOriginalFolderGNIVC(latest_select_folder))
            {
                latest_select_folder = "";
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (latest_select_folder != "")
            {
                fbd.SelectedPath = latest_select_folder;
            }
            fbd.Description = "Specify the folder with the files KLADR that you downloaded from the site GNIVTS (in the selected folder, the files should be: ALTNAMES.DBF, DOMA.DBF, FLAT.DBF, KLADR.DBF, SOCRBASE.DBF, STREET.DBF).";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                buttonStartTransfer.Enabled = false;
                return;
            }
            string fbdSelectedFolder = fbd.SelectedPath + "\\";
            if (!checkOriginalFolderGNIVC(fbdSelectedFolder))
            {
                buttonStartTransfer.Enabled = false;
                MessageBox.Show(this, "The current folder can not be selected (in the selected folder, the files should be: ALTNAMES.DBF, DOMA.DBF, FLAT.DBF, KLADR.DBF, SOCRBASE.DBF, STREET.DBF).", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            textBoxSelectFolder.Text = fbdSelectedFolder;
            buttonStartTransfer.Enabled = true;
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            regKey.SetValue("latest_select_folder", fbdSelectedFolder);
        }

        private void textBoxSelectFolder_Click(object sender, EventArgs e)
        {
            string fbdSelectedPath = textBoxSelectFolder.Text.Trim();
            fbdSelectedPath = Regex.IsMatch(fbdSelectedPath, "\\$") ? fbdSelectedPath : fbdSelectedPath + "\\";
            if (!checkOriginalFolderGNIVC(fbdSelectedPath))
            {
                buttonSelectFolder_Click(sender, e);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            buttonSelectFolder.Enabled = false;
            textBoxNameFolderDB.ReadOnly = true;
            progressBarLoader.Style = ProgressBarStyle.Marquee;
            buttonClose.Enabled = false;
            buttonStartTransfer.Enabled = false;
            databases DBFLoader = new databases();
            DBFLoader.LoadDbfToSqliteStart(textBoxSelectFolder.Text.Trim(), textBoxNameFolderDB.Text.Trim(), this);
        }

        private void FormCreateDB_Load(object sender, EventArgs e)
        {
            buttonStartTransfer.MouseHover += new EventHandler(delegate(object sender_, EventArgs e_) { buttonStartTransfer.Enabled = checkOriginalFolderGNIVC(textBoxSelectFolder.Text); });
            textBoxNameFolderDB.TextChanged += new EventHandler(delegate(object sender_, EventArgs e_)
            {
                int position = textBoxNameFolderDB.SelectionStart;
                try
                {
                    if (textBoxNameFolderDB.Text.Trim() != "" && Directory.CreateDirectory(Path.GetTempPath() + textBoxNameFolderDB.Text.Trim()).ToString() == "")
                    {
                        textBoxNameFolderDB.Text = (textBoxNameFolderDB.Tag == null || textBoxNameFolderDB.Tag.ToString() == "") ? "" : textBoxNameFolderDB.Tag.ToString();
                    }
                    else
                    {
                        textBoxNameFolderDB.Tag = textBoxNameFolderDB.Text.Trim();
                    }
                }
                catch
                {
                    textBoxNameFolderDB.Text = (textBoxNameFolderDB.Tag == null || textBoxNameFolderDB.Tag.ToString() == "") ? "" : textBoxNameFolderDB.Tag.ToString();
                }
                textBoxNameFolderDB.SelectionStart = position;
                buttonStartTransfer.Enabled = checkOriginalFolderGNIVC(textBoxSelectFolder.Text);
            });
            updateLang(null, null);
            global.RaiseCustomEvent += new EventHandler(updateLang);
        }
        
        private void updateLang(object sender, EventArgs e) 
        {
            this.Text = language.formCreateDB._window_text;
            labelNameDataBase.Text = language.formCreateDB._label_name_data_base_text;
            toolTipCreateNewDataBase.SetToolTip(labelNameDataBase, language.formCreateDB._label_name_data_base_tool_tip);
            toolTipCreateNewDataBase.SetToolTip(textBoxNameFolderDB, language.formCreateDB._label_name_data_base_tool_tip);
            labelFolderGNIVC.Text = language.formCreateDB._folder_GNIVC_text;
            toolTipCreateNewDataBase.SetToolTip(labelFolderGNIVC, language.formCreateDB._folder_GNIVC_tool_tip);
            toolTipCreateNewDataBase.SetToolTip(textBoxSelectFolder, language.formCreateDB._folder_GNIVC_tool_tip);
            toolTipCreateNewDataBase.SetToolTip(textBoxLog, language.formCreateDB._text_box_log_tool_tip);
            buttonStartTransfer.Text = language.formCreateDB._button_start_transfer;
            buttonClose.Text = language.formCreateDB._button_close;
            toolTipCreateNewDataBase.SetToolTip(progressBarLoader, language.formCreateDB._text_box_log_tool_tip);
        }
    }
}
