﻿/*!
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using net.r_eg.DllExport.Wizard.Extensions;
using net.r_eg.DllExport.Wizard.UI.Extensions;
using net.r_eg.MvsSln.Core;
using static net.r_eg.DllExport.Wizard.PostProc;

namespace net.r_eg.DllExport.Wizard.UI.Controls
{
    public partial class PostProcControl: UserControl
    {
        private readonly DataTable dtRecords = new();

        public CmdType Type => GetCmdType();

        public IEnumerable<string> ProcEnv => GetProcEnv();

        //TODO: implement logic
        //public string Cmd => txtPostProc.Text;
        public string Cmd => string.Empty;

        public void Render(PostProc instance)
        {
            if(instance == null) {
                throw new ArgumentNullException(nameof(instance));
            }

            SetCmdType(instance.Type);
            SetProcEnv(instance.ProcEnv);
        }

        public PostProc Export(PostProc obj) => (obj ?? throw new ArgumentNullException(nameof(obj)))
                .Configure(ProcEnv, Type, Cmd);

        internal void LoadProperties(IXProject project)
        {
            dtRecords.Rows.Clear();
            if(project == null) return;

            foreach(var p in project.GetProperties().ToArray()) // array to avoid possible changes (+InvalidOperationException)
            {
                // ignore all short environment variables from the manager
                if(p.name?.Length > 2) dtRecords.Rows.Add(p.name, p.evaluated);
            }
            dgvProperties.DataSource = dtRecords;
        }

        public PostProcControl()
        {
            InitializeComponent();

            dgvProperties.AutoGenerateColumns = false;
            foreach(DataGridViewColumn col in dgvProperties.Columns)
            {
                dtRecords.Columns.Add(col.Name);
                dgvProperties.Columns[col.Index].DataPropertyName = dgvProperties.Columns[col.Index].Name;
            }
        }

        private void SetCmdType(CmdType type)
        {
            if(type == CmdType.None)
            {
                radioPostProcDisabled.Checked = true;
                return;
            }

            if((type & CmdType.Custom) == CmdType.Custom) { radioCustom.Checked = true; }
            if((type & CmdType.Predefined) == CmdType.Predefined) { radioDependentProjects.Checked = true; }

            chkX86X64.Checked               = ((type & CmdType.DependentX86X64) == CmdType.DependentX86X64);
            chkIntermediateFiles.Checked    = ((type & CmdType.DependentIntermediateFiles) == CmdType.DependentIntermediateFiles);
            chkSeqDep.Checked               = ((type & CmdType.SeqDependentForSys) == CmdType.SeqDependentForSys);
        }

        private CmdType GetCmdType()
        {
            CmdType ret = CmdType.None;

            if(radioCustom.Checked)             { ret = CmdType.Custom; }
            if(radioDependentProjects.Checked)  { ret = CmdType.Predefined; }

            if(chkX86X64.Checked)               { ret |= CmdType.DependentX86X64; }
            if(chkIntermediateFiles.Checked)    { ret |= CmdType.DependentIntermediateFiles; }
            if(chkSeqDep.Checked)               { ret |= CmdType.SeqDependentForSys; }

            return ret;
        }

        private void SetProcEnv(IEnumerable<string> env)
        {
            listActivatedProperties.Items.Clear();
            listActivatedProperties.Items.AddRange(env.Skip(Activator.PostProc.OFS_ENV_PROP).ToArray());
        }

        private IEnumerable<string> GetProcEnv()
        {
            foreach(var item in listActivatedProperties.Items) yield return $"{item}";
        }

        private void SetUIDependentProjects(bool activated)
        {
            chkX86X64.Enabled = chkIntermediateFiles.Enabled = chkSeqDep.Enabled = activated;

            if(!activated) chkX86X64.Checked = chkIntermediateFiles.Checked = chkSeqDep.Checked = false;
        }

        private void ActivateProperty(object value)
        {
            if(!listActivatedProperties.Items.Contains(value))
            {
                listActivatedProperties.Items.Add(value);
            }
        }

        private void radioDependentProjects_CheckedChanged(object sender, EventArgs e) => SetUIDependentProjects(radioDependentProjects.Checked);

        private void linkAboutVsSBE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => "https://github.com/3F/DllExport/issues/144#issuecomment-609494726".OpenUrl();
        private void linkAboutPostProc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => "https://github.com/3F/DllExport/pull/148#issuecomment-622115091".OpenUrl();
        private void linkAboutDependent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => "https://github.com/3F/DllExport/issues/144#issue-594663447".OpenUrl();

        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ActivateProperty(dgvProperties[0, e.RowIndex].Value);
                dgvProperties.Rows[e.RowIndex].SetRowSelectionColor
                (
                    back: Color.FromArgb(245, 242, 203),
                    fore: Color.FromArgb(23, 36, 47)
                );
            }
        }

        private void dgvProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                dgvProperties.Rows[e.RowIndex].SetRowSelectionColor
                (
                    back: Color.FromArgb(225, 241, 253),
                    fore: Color.FromArgb(23, 36, 47)
                );
            }
        }

        private void listActivatedProperties_DoubleClick(object sender, EventArgs e)
        {
            if(listActivatedProperties.SelectedIndex >= 0)
            {
                listActivatedProperties.Items.RemoveAt(listActivatedProperties.SelectedIndex);
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilter.Text))
            {
                dgvProperties.DataSource = dtRecords;
                return;
            }

            DataTable filtered = dtRecords.Clone();

            foreach(DataRow row in dtRecords.Rows)
            {
                if(row[colName.Name].ToString().StartsWith(txtFilter.Text, StringComparison.OrdinalIgnoreCase))
                {
                    filtered.ImportRow(row);
                }
            }
            dgvProperties.DataSource = filtered;
        }
    }
}
