using System.Text.RegularExpressions;
using KLADR_viewer_v4.my_classes;
using System.Collections.Generic;
using KLADR_viewer_v4.management;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using System;

namespace KLADR_viewer_v4
{
    public partial class FormStart : Form
    {
        #region variables
        public WorkDataBase currentDB;
        private bool notCloseForm = false;
        public delegate void initializationDatabaseDelegate(FormStart invokeForm);
        initializationDatabaseDelegate initializationDatabaseDelegateObj;
        #endregion

        public FormStart()
        {
            InitializeComponent();
        }

        public static Color GetTypeCode(string code)
        {
            Color returnColor = Color.Empty;
            if ((code.Length == 13 || code.Length == 17) && code.Substring(code.Length - 2) != "00")
            {
                returnColor = Color.DodgerBlue;
            }
            return returnColor;
        }

        private void InitializationDatabase(object sender, EventArgs e)
        {
            toolStripStatusLabelStart.Text = Language.Other.Connected_to_data_base_of_open;

            initializationDatabaseDelegateObj = new initializationDatabaseDelegate(delegate (FormStart invokeForm)
            {
                System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
                if (!currentDB.SelectDataBase(((ToolStripMenuItem)sender).Text, this))
                {
                    return;
                }
                Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2)
                {
                    invokeForm2.dataGridViewДетали.Rows.Clear();
                    invokeForm2.treeViewStart.Nodes.Clear();
                }), new object[] { this });
                
                IEnumerable<KeyValuePair<string, KLADR>> sortedRegions =
                from k in currentDB.KladrElements
                orderby k.Value.name ascending
                select k;

                foreach (KeyValuePair<string, KLADR> k in sortedRegions)
                {
                    TreeNode newNode = new TreeNode
                    {
                        Text = k.Value.name + " " + k.Value.socr,
                        Tag = k.Value
                    };
                    newNode.Nodes.Add("*");
                    newNode.BackColor = GetTypeCode(k.Value.code);
                    if (newNode.BackColor != Color.Empty)
                    {
                        newNode.ToolTipText = "Объект не актуален";
                    }
                    this.Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2)
                    {
                        invokeForm2.treeViewStart.Nodes.Add(newNode);
                        invokeForm2.dataGridViewДетали.Rows.Add(new object[] {
                    k.Value.name + " " + k.Value.socr,
                    k.Value.code,
                    k.Value.post_index,
                    k.Value.gninmb,
                    k.Value.uno,
                    k.Value.ocatd
                });
                    }), new object[] { this });
                }

                Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.labelCountElements.Text = dataGridViewДетали.Rows.Count.ToString(); }), new object[] { this });
                sw.Stop();
                Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.labelTimeOfExecution.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms"; }), new object[] { this });
                Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.toolStripStatusLabelStart.Text = invokeForm2.toolStripStatusLabelStart.Tag.ToString(); }), new object[] { this });
            });
            initializationDatabaseDelegateObj.BeginInvoke(this, null, null);
        }

        private void ФайлToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            databases myBases = new databases();
            открытьToolStripMenuItem.DropDownItems.Clear();
            string documents_directory = Global.DirectoryProgramRoot + "\\";
            if (!Directory.Exists(documents_directory))
            {
                Directory.CreateDirectory(documents_directory);
            }
            foreach (string DirectoryDB in Directory.GetDirectories(documents_directory))
            {
                открытьToolStripMenuItem.DropDownItems.Add(DirectoryDB.Substring(DirectoryDB.LastIndexOf("\\") + 1), null, InitializationDatabase);
            }
        }

        private void ResetCodeTheme()
        {
            if (labelCode.Text.Length == 13)
            {
                int akt_obj = Convert.ToInt32(labelCode.Text.Substring(labelCode.Text.Length - 2));
                if (akt_obj >= 1 && akt_obj <= 50)
                {
                    labelCode.Text += " - " + Language.FormStart._priznak_aktualnosti_01_50;
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._priznak_aktualnosti_01_50);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 51)
                {
                    labelCode.Text += " - " + Language.FormStart._priznak_aktualnosti_51;
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._priznak_aktualnosti_51);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj >= 52 && akt_obj <= 98)
                {
                    labelCode.Text += " - " + Language.FormStart._priznak_aktualnosti_52_98;
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._priznak_aktualnosti_52_98);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 99)
                {
                    labelCode.Text += " - " + Language.FormStart._priznak_aktualnosti_99;
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._priznak_aktualnosti_99);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 0)
                {
                    //labelCode.Text += " - " + language.formStart._priznak_aktualnosti_00;
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._priznak_aktualnosti_00);
                    labelCode.ForeColor = Color.Blue;
                }
                else
                {
                    toolTipStart.SetToolTip(labelCode, Language.FormStart._code_kladr_tool_tip);
                    labelCode.ForeColor = Color.Blue;
                }
            }
            else
            {
                toolTipStart.SetToolTip(labelCode, Language.FormStart._code_kladr_tool_tip);
                labelCode.ForeColor = Color.Blue;
            }
            /*
             Признак актуальности может принимать следующие значения:
            “00” – актуальный объект (его наименование, подчиненность соответствуют состоянию на данный момент адресного пространства). 
            “01”-“50” – объект был переименован, в данной записи приведено одно из прежних его наименований (актуальный адресный объект присутствует в базе данных с тем же кодом, но с признаком актуальности “00”;
            “51” –  объект был переподчинен или влился в состав другого объекта (актуальный адресный объект определяется по базе Altnames.dbf);
            “52”-“98” – резервные значения признака актуальности;
            ”99” – адресный объект не существует, т.е. нет соответствующего ему актуального адресного объекта.
            Длина признака актуальности – два разряда. Длина идентификационного кода  - 11 разрядов. 
             */
            //
            /////////////////////////////////////////////////////////
        }
        private void TreeViewStart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            if (treeViewStart.SelectedNode == null || ((KLADR)treeViewStart.SelectedNode.Tag) == null)
            {
                labelName.Text = "-";
                labelCode.Text = "-";
                labelIndex.Text = "-";
                labelGninmb.Text = "-";
                labelUno.Text = "-";
                labelOcatd.Text = "-";
                return;
            }
            KLADR info = ((KLADR)treeViewStart.SelectedNode.Tag);
            labelName.Text = info.name + " " + info.socr;

            labelIndex.Text = info.post_index;
            labelGninmb.Text = info.gninmb;
            labelUno.Text = info.uno;
            labelOcatd.Text = info.ocatd;
            currentDB.SelectNode((KLADR)treeViewStart.SelectedNode.Tag);
            labelCode.Text = info.code;
            ResetCodeTheme();
            treeViewStart.SelectedNode.Nodes.Clear();
            dataGridViewДетали.Rows.Clear();
            treeViewStart.BeginUpdate();
            dataGridViewДетали.Visible = false;
            foreach (KeyValuePair<string, KLADR> k in currentDB.KladrElements)
            {
                TreeNode newNode = new TreeNode
                {
                    Text = k.Value.name + " " + k.Value.socr,
                    Tag = k.Value
                };
                Color currBColor = k.Value.GetColorObjectKladr();
                newNode.BackColor = currBColor;
                newNode.Nodes.Add("*");
                newNode.BackColor = FormStart.GetTypeCode(k.Value.code);
                if (newNode.BackColor != Color.Empty)
                {
                    newNode.ToolTipText = "Объект не актуален";
                }
                treeViewStart.SelectedNode.Nodes.Add(newNode);
                dataGridViewДетали.Rows.Add(new object[] {
                k.Value.name + " " + k.Value.socr,
                k.Value.code,
                k.Value.post_index,
                k.Value.gninmb,
                k.Value.uno,
                k.Value.ocatd

            });
                dataGridViewДетали.Rows[dataGridViewДетали.Rows.Count - 1].DefaultCellStyle.BackColor = currBColor;
            }
            dataGridViewДетали.Visible = true;
            labelCountElements.Text = dataGridViewДетали.Rows.Count.ToString();
            treeViewStart.EndUpdate();
            sw.Stop();
            labelTimeOfExecution.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms";
        }

        private void SplitContainerВложенный_Resize(object sender, EventArgs e)
        {
            splitContainerВложенный.SplitterDistance = 170;
        }

        private void CtrlC(object text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SendOrPostCallback(CtrlC), text);
            }
            else
            {
                DataObject data = new DataObject(DataFormats.Text, text);
                Clipboard.SetDataObject(data, false, 100, 100);
            }
        }

        private void ContextMenuStripStart_Opening(object sender, CancelEventArgs e)
        {
            string source = ((ContextMenuStrip)sender).SourceControl.Text.Trim();
            if (source == "" || source == "-")
            {
                toolStripMenuItemCopy.Text = "";
                e.Cancel = true;
                return;
            }
            toolStripMenuItemCopy.Text = "Copy '" + source + "' to clipboard";
            toolStripMenuItemCopy.Click += new EventHandler(delegate (object _sender, EventArgs _e) { CtrlC(source); });
        }

        private void TreeViewStart_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeViewStart.SelectedNode = e.Node;
        }

        private void TreeViewStart_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null && !((TreeView)sender).SelectedNode.IsExpanded)
            {
                ((TreeView)sender).BeginUpdate();
                ((TreeView)sender).SelectedNode.Nodes.Clear();
                ((TreeView)sender).SelectedNode.Nodes.Add("*");
                ((TreeView)sender).EndUpdate();
            }
        }

        private void ПоискToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeViewStart.Nodes.Count == 0)
            {
                MessageBox.Show(this, Language.FormStart._warning_engin_search_of_close_connect, Language.FormStart._warning_engin_search_non_connect, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormSearch formSrch = new FormSearch(this);
            formSrch.ShowDialog(this);
        }

        private void LabelIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Regex.IsMatch(labelIndex.Text.Trim(), @"\d{6}") || e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            System.Diagnostics.Process.Start("https://www.pochta.ru/offices/" + labelIndex.Text.Trim());
        }

        private void LabelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Regex.IsMatch(labelName.Text.Trim(), @"\w+") || e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            TreeNode currTN = treeViewStart.SelectedNode;
            string searchQuery = currTN.Text;
            while (currTN.Parent != null)
            {
                currTN = currTN.Parent;
                searchQuery = currTN.Text + ", " + searchQuery;
            }
            System.Diagnostics.Process.Start("http://maps.yandex.ru/?text=" + "Россия, " + searchQuery);
        }

        private void СодержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/badhitman/kladr-viewer");
        }

        private void KLADRToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKLADRtoCSV fks = new FormKLADRtoCSV();
            fks.ShowDialog();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings();
            fs.ShowDialog();
        }

        private void ToolStripStatusLabelStart_TextChanged(object sender, EventArgs e)
        {
            ToolStripStatusLabel currLabel = ((ToolStripStatusLabel)sender);
            if (currLabel.Text != currLabel.Tag.ToString())
            {
                toolStripProgressBarStart.Style = ProgressBarStyle.Marquee;
                notCloseForm = true;
                treeViewStart.Enabled = false;
                dataGridViewДетали.Enabled = false;
                menuStripStart.Enabled = false;
                splitContainerОсновной.Enabled = false;
            }
            else
            {
                toolStripProgressBarStart.Style = ProgressBarStyle.Blocks;
                notCloseForm = false;
                treeViewStart.Enabled = true;
                dataGridViewДетали.Enabled = true;
                menuStripStart.Enabled = true;
                splitContainerОсновной.Enabled = true;
            }
        }

        private void FormStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.notCloseForm)
                e.Cancel = true;
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewДетали.SelectAll();
        }

        private void InvertSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewДетали.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Selected = !cell.Selected;
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(
                    this.dataGridViewДетали.GetClipboardContent());
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelStart.Text = toolStripStatusLabelStart.Tag.ToString();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\KLADR RU.USA");
            string folder_database_program = regKey.GetValue("folder_database_program", System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer").ToString();
            if (!Directory.Exists(folder_database_program))
            {
                folder_database_program = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\KLADR-Viewer";
            }

            Global.DirectoryProgramRoot = folder_database_program;
            regKey.SetValue("lang", my_classes.Language.DetectLang(regKey.GetValue("lang", "English").ToString()));
            Global.CurrentLNG = my_classes.Language.DetectLang(regKey.GetValue("lang", "English").ToString());

            выходToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { this.Close(); });
            опрограммеToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { new FormAbout().ShowDialog(); });
            создатьToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { new FormCreateDB().ShowDialog(); });
            currentDB = new management.WorkDataBase();

            UpdateLang(this.Controls, null);
            Global.RaiseCustomEvent += new EventHandler(UpdateLang);
        }

        private void UpdateLang(object sender, EventArgs e)
        {
            this.Text = Language.FormStart.TextWindow;


            файлToolStripMenuItem.Text = Language.FormStart.File_text;
            файлToolStripMenuItem.ToolTipText = Language.FormStart.File_tool_tip;

            создатьToolStripMenuItem.Text = Language.FormStart.Create_text;
            создатьToolStripMenuItem.ToolTipText = Language.FormStart.Create_tool_tip;

            открытьToolStripMenuItem.Text = Language.FormStart.Open_text;
            открытьToolStripMenuItem.ToolTipText = Language.FormStart.Open_tool_tip;

            выходToolStripMenuItem.Text = Language.FormStart.Exit_text;
            выходToolStripMenuItem.ToolTipText = Language.FormStart.Exit_tool_tip;

            сервисToolStripMenuItem.Text = Language.FormStart.Service_text;
            сервисToolStripMenuItem.ToolTipText = Language.FormStart.Service_tool_tip;

            поискToolStripMenuItem1.Text = Language.FormStart.Search_text;
            поискToolStripMenuItem1.ToolTipText = Language.FormStart.Search_tool_tip;

            kLADRToSQLToolStripMenuItem.Text = Language.FormStart.Dbf_to_csv_text;
            kLADRToSQLToolStripMenuItem.ToolTipText = Language.FormStart.Dbf_to_csv_tool_tip;

            settingsToolStripMenuItem.Text = Language.FormStart.Settings_text;
            settingsToolStripMenuItem.ToolTipText = Language.FormStart.Settings_tool_tip;

            справкаToolStripMenuItem.Text = Language.FormStart.Help_text;
            справкаToolStripMenuItem.ToolTipText = Language.FormStart.Help_tool_tip;

            содержаниеToolStripMenuItem.Text = Language.FormStart.Desc_text;
            содержаниеToolStripMenuItem.ToolTipText = Language.FormStart.Desc_tool_tip;

            опрограммеToolStripMenuItem.Text = Language.FormStart.About_text;
            опрограммеToolStripMenuItem.ToolTipText = Language.FormStart._about_tool_tip;

            toolTipStart.SetToolTip(treeViewStart, Language.FormStart._tree_start_tool_tip);

            toolTipStart.SetToolTip(dataGridViewДетали, Language.FormStart._data_grid_view_detail_start_tool_tip);

            labelTitleName.Text = Language.FormStart._name_title_text;
            toolTipStart.SetToolTip(labelTitleName, Language.FormStart._name_title_tool_tip);
            NameColumn.ToolTipText = Language.FormStart._name_title_tool_tip;

            toolTipStart.SetToolTip(labelName, Language.FormStart._name_title_tool_tip);

            labelTitleCode.Text = Language.FormStart._code_kladr_tool_text;
            toolTipStart.SetToolTip(labelTitleCode, Language.FormStart._code_kladr_tool_tip);
            CodeColumn.ToolTipText = Language.FormStart._code_kladr_tool_tip;

            ResetCodeTheme();
            //toolTipStart.SetToolTip(labelCode, language.formStart._code_kladr_tool_tip);

            labelTitleIndex.Text = Language.FormStart._index_kladr_text;
            toolTipStart.SetToolTip(labelTitleIndex, Language.FormStart._index_kladr_tool_tip);
            IndexColumn.ToolTipText = Language.FormStart._index_kladr_tool_tip;

            toolTipStart.SetToolTip(labelIndex, Language.FormStart._index_kladr_tool_tip);

            labelTitleGninmb.Text = Language.FormStart._gninmb_kladr_text;
            toolTipStart.SetToolTip(labelTitleGninmb, Language.FormStart._gninmb_kladr_tool_tip);
            GNINMBColumn.ToolTipText = Language.FormStart._gninmb_kladr_tool_tip;

            toolTipStart.SetToolTip(labelGninmb, Language.FormStart._gninmb_kladr_tool_tip);

            labelTitleUNO.Text = Language.FormStart._uno_kladr_text;
            toolTipStart.SetToolTip(labelTitleUNO, Language.FormStart._uno_kladr_tool_tip);
            UNOColumn.ToolTipText = Language.FormStart._uno_kladr_tool_tip;

            toolTipStart.SetToolTip(labelUno, Language.FormStart._uno_kladr_tool_tip);

            labelTitleOcatd.Text = Language.FormStart._ocatd_kladr_text;
            toolTipStart.SetToolTip(labelTitleOcatd, Language.FormStart._ocatd_kladr_tool_tip);
            OCATDColumn.ToolTipText = Language.FormStart._ocatd_kladr_tool_tip;

            toolTipStart.SetToolTip(labelOcatd, Language.FormStart._ocatd_kladr_tool_tip);

            labelTitleCountElements.Text = Language.FormStart._count_elements_text;
            toolTipStart.SetToolTip(labelTitleCountElements, Language.FormStart._count_elements_tool_tip);
            labelCountElements.Left = labelTitleCountElements.Left + labelTitleCountElements.Width;
            toolTipStart.SetToolTip(labelCountElements, Language.FormStart._count_elements_tool_tip);

            labelTitleTimeOfExecution.Text = Language.FormStart._time_of_execution_elements_text;
            toolTipStart.SetToolTip(labelTitleTimeOfExecution, Language.FormStart._time_of_execution_elements_tool_tip);
            labelTimeOfExecution.Left = labelTitleTimeOfExecution.Left + labelTitleTimeOfExecution.Width;
            toolTipStart.SetToolTip(labelTimeOfExecution, Language.FormStart._time_of_execution_elements_tool_tip);

            toolStripStatusLabelStart.Tag = Language.FormStart._status_label_text;
            toolStripStatusLabelStart.Text = Language.FormStart._status_label_text;
        }
    }
}
