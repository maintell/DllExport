﻿/*!
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;
using System.Text;
using System.Windows.Forms;
using net.r_eg.DllExport.Wizard.UI.Extensions;

namespace net.r_eg.DllExport.Wizard.UI
{
    internal partial class MsgForm: Form
    {
        public int MsgLevel
        {
            get;
            set;
        }

        public void AddMsg(string msg, MvsSln.Log.Message.Level level)
        {
            if(!IsValidMsg(level)) {
                return;
            }

            if(!String.IsNullOrWhiteSpace(msg))
            {
                this.UIAction(() => {
                    listBoxLog.Items.Add(msg);
                });
            }
        }

        public MsgForm(int msgLevel)
        {
            MsgLevel = msgLevel;
            InitializeComponent();

            Load += (object sender, EventArgs e) => { TopMost = false; TopMost = true; };
        }

        private bool IsValidMsg(MvsSln.Log.Message.Level level)
        {
            if(MsgLevel < 0) {
                return false;
            }
            return ((int)level) >= MsgLevel;
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < listBoxLog.Items.Count; ++i) {
                listBoxLog.SetSelected(i, true);
            }
        }

        private void menuCopySel_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            foreach(string item in listBoxLog.SelectedItems) {
                sb.Append(item + Environment.NewLine);
            }

            if(sb.Length > 0) {
                Clipboard.SetText(sb.ToString());
            }
        }

        private void menuClear_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void listBoxLog_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode == Keys.C) {
                menuCopySel_Click(sender, e);
            }
            else if(e.Modifiers == Keys.Control && e.KeyCode == Keys.A) {
                menuSelectAll_Click(sender, e);
            }
        }
    }
}
