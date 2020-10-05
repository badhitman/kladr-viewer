using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KLADR_viewer_v4.management;
using System.Text.RegularExpressions;
using System.Globalization;
using KLADR_viewer_v4.my_classes;
using System.Threading;
using System.Reflection;

namespace KLADR_viewer_v4
{
    public partial class FormStart : Form
    {
        #region variables
        public workDataBase currentDB;
        private bool notCloseForm = false;
        public delegate void initializationDatabaseDelegate(FormStart invokeForm);
        initializationDatabaseDelegate initializationDatabaseDelegateObj;
        #endregion

        public FormStart()
        {
            InitializeComponent();
        }

        public static Color getTypeCode(string code)
        {
            Color returnColor = Color.Empty;
            if ((code.Length == 13 || code.Length == 17) && code.Substring(code.Length - 2) != "00")
            {
                returnColor = Color.DodgerBlue;
            }
            return returnColor;
        }

        private void initializationDatabase(object sender, EventArgs e)
        {
            toolStripStatusLabelStart.Text = language.other._connected_to_data_base_of_open;

            initializationDatabaseDelegateObj = new initializationDatabaseDelegate(delegate (FormStart invokeForm)
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                if (!currentDB.selectDataBase(((ToolStripMenuItem)sender).Text, this))
                {
                    return;
                }
                this.Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2)
                {
                    invokeForm2.dataGridViewДетали.Rows.Clear();
                    invokeForm2.treeViewStart.Nodes.Clear();
                }), new object[] { this });
                //this.Invoke(new initializationDatabaseDelegate(delegate(FormStart invokeForm2) { invokeForm2.treeViewStart.BeginUpdate(); }), new object[] { this });

                IEnumerable<KeyValuePair<string, KLADR>> sortedRegions =
                from k in currentDB.KladrElements
                orderby k.Value.name ascending
                select k;

                foreach (KeyValuePair<string, KLADR> k in sortedRegions)
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = k.Value.name + " " + k.Value.socr;
                    newNode.Tag = k.Value;
                    newNode.Nodes.Add("*");
                    newNode.BackColor = FormStart.getTypeCode(k.Value.code);
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

                this.Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.labelCountElements.Text = dataGridViewДетали.Rows.Count.ToString(); }), new object[] { this });
                sw.Stop();
                this.Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.labelTimeOfExecution.Text = sw.Elapsed.TotalMilliseconds.ToString() + " ms"; }), new object[] { this });
                this.Invoke(new initializationDatabaseDelegate(delegate (FormStart invokeForm2) { invokeForm2.toolStripStatusLabelStart.Text = invokeForm2.toolStripStatusLabelStart.Tag.ToString(); }), new object[] { this });
            });
            initializationDatabaseDelegateObj.BeginInvoke(this, null, null);
        }

        private void файлToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            management.databases myBases = new management.databases();
            открытьToolStripMenuItem.DropDownItems.Clear();
            string documents_directory = global.DirectoryProgrammRoot + "\\";
            if (!Directory.Exists(documents_directory))
            {
                Directory.CreateDirectory(documents_directory);
            }
            foreach (string DirectoryDB in Directory.GetDirectories(documents_directory))
            {
                открытьToolStripMenuItem.DropDownItems.Add(DirectoryDB.Substring(DirectoryDB.LastIndexOf("\\") + 1), null, initializationDatabase);
            }
        }
        
        private void ResetCodeTheme()
        {
            if (labelCode.Text.Length == 13)
            {
                int akt_obj = Convert.ToInt32(labelCode.Text.Substring(labelCode.Text.Length - 2));
                if (akt_obj >= 1 && akt_obj <= 50)
                {
                    labelCode.Text += " - " + language.formStart._priznak_aktualnosti_01_50;
                    toolTipStart.SetToolTip(labelCode, language.formStart._priznak_aktualnosti_01_50);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 51)
                {
                    labelCode.Text += " - " + language.formStart._priznak_aktualnosti_51;
                    toolTipStart.SetToolTip(labelCode, language.formStart._priznak_aktualnosti_51);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj >= 52 && akt_obj <= 98)
                {
                    labelCode.Text += " - " + language.formStart._priznak_aktualnosti_52_98;
                    toolTipStart.SetToolTip(labelCode, language.formStart._priznak_aktualnosti_52_98);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 99)
                {
                    labelCode.Text += " - " + language.formStart._priznak_aktualnosti_99;
                    toolTipStart.SetToolTip(labelCode, language.formStart._priznak_aktualnosti_99);
                    labelCode.ForeColor = Color.Red;
                }
                else if (akt_obj == 0)
                {
                    //labelCode.Text += " - " + language.formStart._priznak_aktualnosti_00;
                    toolTipStart.SetToolTip(labelCode, language.formStart._priznak_aktualnosti_00);
                    labelCode.ForeColor = Color.Blue;
                }
                else
                {
                    toolTipStart.SetToolTip(labelCode, language.formStart._code_kladr_tool_tip);
                    labelCode.ForeColor = Color.Blue;
                }
            }
            else
            {
                toolTipStart.SetToolTip(labelCode, language.formStart._code_kladr_tool_tip);
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
        private void treeViewStart_AfterSelect(object sender, TreeViewEventArgs e)
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
            currentDB.selectNode(((KLADR)treeViewStart.SelectedNode.Tag));
            labelCode.Text = info.code;
            ResetCodeTheme();
            treeViewStart.SelectedNode.Nodes.Clear();
            dataGridViewДетали.Rows.Clear();
            treeViewStart.BeginUpdate();
            dataGridViewДетали.Visible = false;
            foreach (KeyValuePair<string, KLADR> k in currentDB.KladrElements)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = k.Value.name + " " + k.Value.socr;
                newNode.Tag = k.Value;
                Color currBColor = k.Value.getColorObjectKladr();
                newNode.BackColor = currBColor;
                newNode.Nodes.Add("*");
                newNode.BackColor = FormStart.getTypeCode(k.Value.code);
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

        private void splitContainerВложенный_Resize(object sender, EventArgs e)
        {
            splitContainerВложенный.SplitterDistance = 170;
        }

        private void CtrlC(object text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SendOrPostCallback(CtrlC), text);
            }
            else
            {
                DataObject data = new DataObject(DataFormats.Text, text);
                Clipboard.SetDataObject(data, false, 100, 100);
            }
        }

        private void contextMenuStripStart_Opening(object sender, CancelEventArgs e)
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

        private void treeViewStart_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            treeViewStart.SelectedNode = e.Node;
        }

        private void treeViewStart_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (((TreeView)sender).SelectedNode != null && !((TreeView)sender).SelectedNode.IsExpanded)
            {
                ((TreeView)sender).BeginUpdate();
                ((TreeView)sender).SelectedNode.Nodes.Clear();
                ((TreeView)sender).SelectedNode.Nodes.Add("*");
                ((TreeView)sender).EndUpdate();
            }
        }

        private void поискToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeViewStart.Nodes.Count == 0)
            {
                MessageBox.Show(this, language.formStart._warning_engin_search_of_close_connect, language.formStart._warning_engin_search_non_connect, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormSearch formSrch = new FormSearch(this);
            formSrch.ShowDialog(this);
        }

        private void labelIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Regex.IsMatch(labelIndex.Text.Trim(), @"\d{6}") || e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }
            System.Diagnostics.Process.Start("https://www.pochta.ru/offices/" + labelIndex.Text.Trim());
        }

        private void labelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void содержаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/badhitman/kladr-viewer");
        }

        private void kLADRToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKLADRtoCSV fks = new FormKLADRtoCSV();
            fks.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings fs = new FormSettings();
            fs.ShowDialog();
        }

        private void toolStripStatusLabelStart_TextChanged(object sender, EventArgs e)
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

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewДетали.SelectAll();
        }

        private void invertSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewДетали.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Selected = !cell.Selected;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
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

            global.DirectoryProgrammRoot = folder_database_program;
            regKey.SetValue("lang", my_classes.language.detectLang(regKey.GetValue("lang", "English").ToString()));
            global.currentLNG = my_classes.language.detectLang(regKey.GetValue("lang", "English").ToString());

            выходToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { this.Close(); });
            опрограммеToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { new FormAbout().ShowDialog(); });
            создатьToolStripMenuItem.Click += new EventHandler(delegate (object _sender, EventArgs _e) { new FormCreateDB().ShowDialog(); });
            currentDB = new management.workDataBase();

            updateLang(this.Controls, null);
            global.RaiseCustomEvent += new EventHandler(updateLang);
        }

        private void updateLang(object sender, EventArgs e)
        {
            this.Text = language.formStart._textWindow;


            файлToolStripMenuItem.Text = language.formStart._file_text;
            файлToolStripMenuItem.ToolTipText = language.formStart._file_tool_tip;

            создатьToolStripMenuItem.Text = language.formStart._create_text;
            создатьToolStripMenuItem.ToolTipText = language.formStart._create_tool_tip;

            открытьToolStripMenuItem.Text = language.formStart._open_text;
            открытьToolStripMenuItem.ToolTipText = language.formStart._open_tool_tip;

            выходToolStripMenuItem.Text = language.formStart._exit_text;
            выходToolStripMenuItem.ToolTipText = language.formStart._exit_tool_tip;

            сервисToolStripMenuItem.Text = language.formStart._service_text;
            сервисToolStripMenuItem.ToolTipText = language.formStart._service_tool_tip;

            поискToolStripMenuItem1.Text = language.formStart._search_text;
            поискToolStripMenuItem1.ToolTipText = language.formStart._search_tool_tip;

            kLADRToSQLToolStripMenuItem.Text = language.formStart._dbf_to_csv_text;
            kLADRToSQLToolStripMenuItem.ToolTipText = language.formStart._dbf_to_csv_tool_tip;

            settingsToolStripMenuItem.Text = language.formStart._settings_text;
            settingsToolStripMenuItem.ToolTipText = language.formStart._settings_tool_tip;

            справкаToolStripMenuItem.Text = language.formStart._help_text;
            справкаToolStripMenuItem.ToolTipText = language.formStart._help_tool_tip;

            содержаниеToolStripMenuItem.Text = language.formStart._desc_text;
            содержаниеToolStripMenuItem.ToolTipText = language.formStart._desc_tool_tip;

            опрограммеToolStripMenuItem.Text = language.formStart._about_text;
            опрограммеToolStripMenuItem.ToolTipText = language.formStart._about_tool_tip;

            toolTipStart.SetToolTip(treeViewStart, language.formStart._tree_start_tool_tip);

            toolTipStart.SetToolTip(dataGridViewДетали, language.formStart._data_grid_view_detail_start_tool_tip);

            labelTitleName.Text = language.formStart._name_title_text;
            toolTipStart.SetToolTip(labelTitleName, language.formStart._name_title_tool_tip);
            NameColumn.ToolTipText = language.formStart._name_title_tool_tip;

            toolTipStart.SetToolTip(labelName, language.formStart._name_title_tool_tip);

            labelTitleCode.Text = language.formStart._code_kladr_tool_text;
            toolTipStart.SetToolTip(labelTitleCode, language.formStart._code_kladr_tool_tip);
            CodeColumn.ToolTipText = language.formStart._code_kladr_tool_tip;

            ResetCodeTheme();
            //toolTipStart.SetToolTip(labelCode, language.formStart._code_kladr_tool_tip);

            labelTitleIndex.Text = language.formStart._index_kladr_text;
            toolTipStart.SetToolTip(labelTitleIndex, language.formStart._index_kladr_tool_tip);
            IndexColumn.ToolTipText = language.formStart._index_kladr_tool_tip;

            toolTipStart.SetToolTip(labelIndex, language.formStart._index_kladr_tool_tip);

            labelTitleGninmb.Text = language.formStart._gninmb_kladr_text;
            toolTipStart.SetToolTip(labelTitleGninmb, language.formStart._gninmb_kladr_tool_tip);
            GNINMBColumn.ToolTipText = language.formStart._gninmb_kladr_tool_tip;

            toolTipStart.SetToolTip(labelGninmb, language.formStart._gninmb_kladr_tool_tip);

            labelTitleUNO.Text = language.formStart._uno_kladr_text;
            toolTipStart.SetToolTip(labelTitleUNO, language.formStart._uno_kladr_tool_tip);
            UNOColumn.ToolTipText = language.formStart._uno_kladr_tool_tip;

            toolTipStart.SetToolTip(labelUno, language.formStart._uno_kladr_tool_tip);

            labelTitleOcatd.Text = language.formStart._ocatd_kladr_text;
            toolTipStart.SetToolTip(labelTitleOcatd, language.formStart._ocatd_kladr_tool_tip);
            OCATDColumn.ToolTipText = language.formStart._ocatd_kladr_tool_tip;

            toolTipStart.SetToolTip(labelOcatd, language.formStart._ocatd_kladr_tool_tip);

            labelTitleCountElements.Text = language.formStart._count_elements_text;
            toolTipStart.SetToolTip(labelTitleCountElements, language.formStart._count_elements_tool_tip);
            labelCountElements.Left = labelTitleCountElements.Left + labelTitleCountElements.Width;
            toolTipStart.SetToolTip(labelCountElements, language.formStart._count_elements_tool_tip);

            labelTitleTimeOfExecution.Text = language.formStart._time_of_execution_elements_text;
            toolTipStart.SetToolTip(labelTitleTimeOfExecution, language.formStart._time_of_execution_elements_tool_tip);
            labelTimeOfExecution.Left = labelTitleTimeOfExecution.Left + labelTitleTimeOfExecution.Width;
            toolTipStart.SetToolTip(labelTimeOfExecution, language.formStart._time_of_execution_elements_tool_tip);

            toolStripStatusLabelStart.Tag = language.formStart._status_label_text;
            toolStripStatusLabelStart.Text = language.formStart._status_label_text;
        }
    }
}
