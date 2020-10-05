using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        loadResultToRowsDelegate loadResultToRowsDelegateObj;

        public delegate void UpdateStatus(FormStart invokeForm);

        private void loadResultToRowsFunction(string how, FormSearch formSRCH, FormStart formSTRT)
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
                            formSRCH.toolStripStatusLabelSearch.Text = language.formSearch._search_in + " " + message.ToString() + " (" + (tn.Index + 1).ToString() + language.formSearch._search_of + totalTreeNodeCount.ToString() + ")";
                        }), new object[] { tn.Text });
                }
                catch
                {
                    return;
                }
                formSTRT.currentDB.search(how, tn.Tag.ToString(), radioButtonAll.Checked ? SearchArea.All : radioButtonCity.Checked ? SearchArea.City : SearchArea.Street);
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
            searchMethodDelegateObject = new searchMethodDelegate(loadResultToRowsFunction);
            toolStripStatusLabelSearch.Tag = toolStripStatusLabelSearch.Text;
            this.Owner = ownerForm;
            foreach (TreeNode tn in ownerForm.treeViewStart.Nodes)
            {
                TreeNode newTN = new TreeNode(tn.Text);
                newTN.Tag = ((KLADR)tn.Tag).code.Substring(0, 2);
                treeViewSearch.Nodes.Add(newTN);
            }
            this.Text += global.preficsBildProgramm;
        }

        private void buttonИскать_Click(object sender, EventArgs e)
        {
            this.Text = new Regex(@"\s+-\s+\d+\s+\w+$").Replace(this.Text, "");
            toolStripStatusLabelSearch.Text = "search run...";
            dataGridViewResultSearch.Rows.Clear();
            toolStripStatusLabelSearch.Text = textBoxQuerySearch.Text;
            FormStart fs = ((FormStart)this.Owner);
            searchMethodDelegateObject.BeginInvoke(textBoxQuerySearch.Text, this, fs, null, null);
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = false;
            }
        }

        private void buttonInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = !tn.Checked;
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in treeViewSearch.Nodes)
            {
                tn.Checked = true;
            }
        }

        private void textBoxИскать_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                buttonИскать_Click(sender, new EventArgs());
            }
        }

        private void toolStripStatusLabelSearch_TextChanged(object sender, EventArgs e)
        {
            this.Invoke(new UpdateStatus(delegate (FormStart invokeForm2)
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
            global.RaiseCustomEvent += new EventHandler(updateLang);
            updateLang(null, null);
        }

        private void updateLang(object sender, EventArgs e)
        {
            this.Text = language.formSearch._window_text;
            labelQuery.Text = language.formSearch._label_qoery_text;
            toolTipSearch.SetToolTip(labelQuery, language.formSearch._label_qoery_tool_tip);
            toolTipSearch.SetToolTip(textBoxQuerySearch, language.formSearch._label_qoery_tool_tip);
            buttonSearch.Text = language.formSearch._button_start_search_text;
            toolTipSearch.SetToolTip(buttonSearch, language.formSearch._button_start_search_tool_tip);
            labelWhereLook.Text = language.formSearch._where_look_text;
            toolTipSearch.SetToolTip(labelWhereLook, language.formSearch._where_look_tool_tip);
            toolTipSearch.SetToolTip(treeViewSearch, language.formSearch._where_look_tool_tip);
            toolTipSearch.SetToolTip(buttonDeselectAll, language.formSearch._deselect_all_items_tool_tip);
            toolTipSearch.SetToolTip(buttonInvertSelect, language.formSearch._invert_select_items_tool_tip);
            toolTipSearch.SetToolTip(buttonSelectAll, language.formSearch._select_all_items_tool_tip);
            toolTipSearch.SetToolTip(dataGridViewResultSearch, language.formSearch._grid_view_result_search_tool_tip);
            //***********************************
            //
            NameColumn.ToolTipText = language.formStart._name_title_tool_tip;
            CodeColumn.ToolTipText = language.formStart._code_kladr_tool_tip;
            IndexColumn.ToolTipText = language.formStart._index_kladr_tool_tip;
            GNINMBColumn.ToolTipText = language.formStart._gninmb_kladr_tool_tip;
            UNOColumn.ToolTipText = language.formStart._uno_kladr_tool_tip;
            OCATDColumn.ToolTipText = language.formStart._ocatd_kladr_tool_tip;
            //
            //***********************************
            toolStripStatusLabelSearch.Tag = language.formStart._status_label_text;
            toolStripStatusLabelSearch.Text = language.formStart._status_label_text;
        }
    }
}
