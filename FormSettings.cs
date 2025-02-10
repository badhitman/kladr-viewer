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
    public partial class FormSettings : Form
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
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

        public FormSettings()
        {
            InitializeComponent();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            string folder_database_program = regKey.GetValue("folder_database_program", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer").ToString();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (folder_database_program != "")
            {
                fbd.SelectedPath = folder_database_program;
            }
            fbd.Description = "Specify the folder for the program";
            fbd.ShowNewFolderButton = true;
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string fbdSelectedFolder = fbd.SelectedPath + "\\";
            textBoxSelectFolder.Text = fbdSelectedFolder;
            regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            regKey.SetValue("folder_database_program", fbdSelectedFolder);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            regKey.SetValue("folder_database_program", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer");
            textBoxSelectFolder.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer";
            comboBoxCacheTimeOut.SelectedIndex = 4;
            comboBoxCache_TextChanged(sender, e);
            comboBoxLanguage.SelectedItem = "English";
            comboBoxLanguage_TextChanged(null, null);
        }

        private void textBoxSelectFolder_Click(object sender, EventArgs e)
        {
            string fbdSelectedPath = textBoxSelectFolder.Text.Trim();
            fbdSelectedPath = System.Text.RegularExpressions.Regex.IsMatch(fbdSelectedPath, "\\$") ? fbdSelectedPath : fbdSelectedPath + "\\";
            if (!Directory.Exists(fbdSelectedPath) || fbdSelectedPath == "\\")
            {
                buttonSelectFolder_Click(sender, e);
            }
        }

        private void comboBoxCache_TextChanged(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            regKey.SetValue("CacheTimeOut", (comboBoxCacheTimeOut.Text == "no cache" ? "-1" : (comboBoxCacheTimeOut.Text == "cache all" ? "0" : comboBoxCacheTimeOut.Text)));
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            Global.DirectoryProgramRoot = regKey.GetValue("folder_database_program", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer").ToString();
            string TimeOut = regKey.GetValue("CacheTimeOut", "150").ToString();
            try
            {
                Global.CashTimeLimit = Convert.ToInt32(TimeOut);
            }
            catch
            {
                Global.CashTimeLimit = 150;
                comboBoxCacheTimeOut.SelectedIndex = 4;
                comboBoxCache_TextChanged(new object(), new EventArgs());
            }
        }

        private void comboBoxLanguage_TextChanged(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            regKey.SetValue("lang", comboBoxLanguage.Text);
            foreach (KLADR_viewer_v4.my_classes.Language.Languages lang in Enum.GetValues(typeof(KLADR_viewer_v4.my_classes.Language.Languages)))
            {
                if (lang.ToString() == comboBoxLanguage.Text)
                    Global.CurrentLNG = lang;
            }
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            string defLang = "";
            foreach (KLADR_viewer_v4.my_classes.Language.Languages lang in Enum.GetValues(typeof(KLADR_viewer_v4.my_classes.Language.Languages)))
            {
                comboBoxLanguage.Items.Add(lang.ToString());
                if (Global.CurrentLNG.ToString() == lang.ToString())
                    defLang = lang.ToString();
            }
            comboBoxLanguage.SelectedItem = defLang;

            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            string folder_database_program = regKey.GetValue("folder_database_program", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer").ToString();
            if (!Directory.Exists(folder_database_program))
                folder_database_program = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer";
            textBoxSelectFolder.Text = folder_database_program;
            string CacheTimeOut = regKey.GetValue("CacheTimeOut", "150").ToString();
            if (CacheTimeOut == "-1")
                CacheTimeOut = "no cache";
            if (CacheTimeOut == "0")
                CacheTimeOut = "cache all";
            foreach (string s in comboBoxCacheTimeOut.Items)
            {
                if (s == CacheTimeOut)
                {
                    comboBoxCacheTimeOut.SelectedItem = CacheTimeOut;
                    break;
                }
            }
            if (comboBoxCacheTimeOut.SelectedItem == null)
                comboBoxCacheTimeOut.SelectedItem = "150";
            this.Text += Global.preficsBildProgramm;
            Global.RaiseCustomEvent += new EventHandler(updateLang);
            updateLang(null, null);
        }

        private void updateLang(object sender, EventArgs e) 
        {
            this.Text = Language.FormSettings.Title_window;
            groupBoxLanguageApplication.Text = Language.FormSettings.Lang_app_groupbox_tex;
            labelChoseLangProgramm.Text = Language.FormSettings.Chose_lang_programm_text;
            groupBoxTimeAutCash.Text = Language.FormSettings.Group_box_time_aut_cash;
            labelTimeAutCash.Text = Language.FormSettings.Label_time_aut_cash;
            label_ms.Text = Language.FormSettings.Label_ms_text;
            groupBoxFolderDatabaseProgram.Text = Language.FormSettings.Group_box_folder_database_program;
            labelFolderDatabaseProgram.Text = Language.FormSettings.Label_folder_database_program_text;
            buttonReset.Text = Language.FormSettings.Button_reset_text;
        }
    }
}
