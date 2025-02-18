using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using KLADR_viewer_v4.my_classes;

namespace KLADR_viewer_v4
{
    public partial class FormSearch : Form
    {
        //delegate searchMethod(string how, string where);
        private delegate void searchMethodDelegate(string how, FormSearch formSRCH, FormStart formSTRT);
        searchMethodDelegate searchMethodDelegateObject;

        private delegate void loadResultToRowsDelegate(object message);

        public delegate void UpdateStatus(FormSearch invokeForm);

        private void LoadResultToRowsFunction(string how, FormSearch formSRCH, FormStart formSTRT)
        {
            int totalTreeNodeCount = formSRCH.treeViewSearch.Nodes.Count;
            foreach (TreeNode tn in formSRCH.treeViewSearch.Nodes)
            {
                if (!tn.Checked)
                    continue;
                try
                {
                    formSRCH.Invoke(new loadResultToRowsDelegate(delegate (object message)
                        {
                            formSRCH.toolStripStatusLabelSearch.Text = Language.FormSearch.Search_in + " " + message.ToString() + " (" + (tn.Index + 1).ToString() + Language.FormSearch.Search_of + totalTreeNodeCount.ToString() + ")";
                        }), new object[] { tn.Text });
                }
                catch
                {
                    return;
                }
                formSTRT.currentDB.Search(how, tn.Tag.ToString(), radioButtonAll.Checked ? SearchArea.All : radioButtonCity.Checked ? SearchArea.City : SearchArea.Street);
                try
                {
                    formSRCH.Invoke(new loadResultToRowsDelegate(delegate (object message)
                    {
                        foreach (KeyValuePair<string, KLADR> k in ((Dictionary<string, KLADR>)message))
                        {
                            dataGridViewResultSearch.Rows.Add(new object[] {
                                    k.Value.name + " " + k.Value.socr,
                                    k.Value.code,
                                    k.Value.post_index,
                                    k.Value.gninmb,
                                    k.Value.uno,
                                    k.Value.ocatd});
                        }
                    }), new object[] { formSTRT.currentDB.KladrElements });
                }
                catch
                {
                    return;
                }
            }

            formSRCH.Invoke(new loadResultToRowsDelegate(delegate (object message)
            {
                formSRCH.toolStripStatusLabelSearch.Text = formSRCH.toolStripStatusLabelSearch.Tag.ToString();
                formSRCH.Text += " - " + formSRCH.dataGridViewResultSearch.Rows.Count.ToString() + " items";
            }), new object[] { "" });
        }

        public FormSearch(FormStart ownerForm)
        {
            InitializeComponent();
            searchMethodDelegateObject = new searchMethodDelegate(LoadResultToRowsFunction);
            toolStripStatusLabelSearch.Tag = toolStripStatusLabelSearch.Text;
            this.Owner = ownerForm;
            foreach (TreeNode tn in ownerForm.treeViewStart.Nodes)
            {
                TreeNode newTN = new TreeNode(tn.Text)
                {
                    Tag = ((KLADR)tn.Tag).code.Substring(0, 2)
                };
                treeViewSearch.Nodes.Add(newTN);
            }
            this.Text += Global.preficsBildProgramm;
        }

        private void ButtonИскать_Click(object sender, EventArgs e)
        {
            this.Text = new Regex(@"\s+-\s+\d+\s+\w+$").Replace(this.Text, "");
            toolStripStatusLabelSearch.Text = "search run...";
            dataGridViewResultSearch.Rows.Clear();
            toolStripStatusLabelSearch.Text = textBoxQuerySearch.Text;
            FormStart fs = ((FormStart)this.Owner);
            searchMethodDelegateObject.BeginInvoke(textBoxQuerySearch.Text, this, fs, null, null);
        }

        private void ButtonUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = false;
            }
        }

        private void ButtonInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = !tn.Checked;
            }
        }

        private void ButtonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = true;
            }
        }

        private void TextBoxИскать_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                ButtonИскать_Click(sender, new EventArgs());
            }
        }

        private void ToolStripStatusLabelSearch_TextChanged(object sender, EventArgs e)
        {
            this.Invoke(new UpdateStatus(delegate (FormSearch invokeForm2)
            {
                if (toolStripStatusLabelSearch.Text != toolStripStatusLabelSearch.Tag.ToString())
                {
                    toolStripProgressBarSearch.Style = ProgressBarStyle.Marquee;
                    buttonDeselectAll.Enabled = false;
                    buttonInvertSelect.Enabled = false;
                    buttonSelectAll.Enabled = false;
                    textBoxQuerySearch.Enabled = false;
                    buttonSearch.Enabled = false;
                    treeViewSearch.Enabled = false;
                }
                else
                {
                    toolStripProgressBarSearch.Style = ProgressBarStyle.Blocks;
                    buttonDeselectAll.Enabled = true;
                    buttonInvertSelect.Enabled = true;
                    buttonSelectAll.Enabled = true;
                    textBoxQuerySearch.Enabled = true;
                    buttonSearch.Enabled = true;
                    treeViewSearch.Enabled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }), new object[] { this });
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            Global.RaiseCustomEvent += new EventHandler(updateLang);
            updateLang(null, null);
        }

        private void updateLang(object sender, EventArgs e)
        {
            this.Text = Language.FormSearch.Window_text;
            labelQuery.Text = Language.FormSearch.Label_qoery_text;
            toolTipSearch.SetToolTip(labelQuery, Language.FormSearch.Label_qoery_tool_tip);
            toolTipSearch.SetToolTip(textBoxQuerySearch, Language.FormSearch.Label_qoery_tool_tip);
            buttonSearch.Text = Language.FormSearch.Button_start_search_text;
            toolTipSearch.SetToolTip(buttonSearch, Language.FormSearch.Button_start_search_tool_tip);
            labelWhereLook.Text = Language.FormSearch.Where_look_text;
            toolTipSearch.SetToolTip(labelWhereLook, Language.FormSearch.Where_look_tool_tip);
            toolTipSearch.SetToolTip(treeViewSearch, Language.FormSearch.Where_look_tool_tip);
            toolTipSearch.SetToolTip(buttonDeselectAll, Language.FormSearch.Deselect_all_items_tool_tip);
            toolTipSearch.SetToolTip(buttonInvertSelect, Language.FormSearch.Invert_select_items_tool_tip);
            toolTipSearch.SetToolTip(buttonSelectAll, Language.FormSearch.Select_all_items_tool_tip);
            toolTipSearch.SetToolTip(dataGridViewResultSearch, Language.FormSearch.Grid_view_result_search_tool_tip);
            //***********************************
            //
            NameColumn.ToolTipText = Language.FormStart._name_title_tool_tip;
            CodeColumn.ToolTipText = Language.FormStart._code_kladr_tool_tip;
            IndexColumn.ToolTipText = Language.FormStart._index_kladr_tool_tip;
            GNINMBColumn.ToolTipText = Language.FormStart._gninmb_kladr_tool_tip;
            UNOColumn.ToolTipText = Language.FormStart._uno_kladr_tool_tip;
            OCATDColumn.ToolTipText = Language.FormStart._ocatd_kladr_tool_tip;
            //
            //***********************************
            toolStripStatusLabelSearch.Tag = Language.FormStart._status_label_text;
            toolStripStatusLabelSearch.Text = Language.FormStart._status_label_text;
        }
    }
}