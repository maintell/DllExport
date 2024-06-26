﻿/*!
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

/*
 * Modified. Original from https://github.com/3F/vsSolutionBuildEvent
 * Copyright (c) 2013-2016,2019  Denis Kuzmin < x-3F@outlook.com > GitHub/3F
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace net.r_eg.vsSBE.UI.WForms.Components
{
    internal class DataGridViewExt: DataGridView
    {
        /// <summary>
        /// Support AlwaysSelected
        /// </summary>
        protected int lastSelectedRowIndex = 0;

        private readonly object _eLock = new object();

        /// <summary>
        /// Custom column: for work with numeric formats with standard TextBoxCell 
        /// </summary>
        internal class NumericColumn: DataGridViewColumn
        {
            public bool Decimal { get; set; }
            public bool Negative { get; set; }

            public NumericColumn()
                : base(new DataGridViewTextBoxCell())
            {

            }
        }

        /// <summary>
        /// Shows total count of rows and current position for each row
        /// </summary>
        public bool NumberingForRowsHeader
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Always one row selected
        /// </summary>
        public bool AlwaysSelected
        {
            get;
            set;
        } = false;

        public DataGridViewExt()
        {
            CellPainting            += onNumberingCellPainting;
            SelectionChanged        += onAlwaysSelected;
            EditingControlShowing   += (object sender, DataGridViewEditingControlShowingEventArgs e) =>
            {
                if(e.Control == null) {
                    return;
                }

                lock(_eLock) 
                {
                    e.Control.KeyPress -= onControlKeyPress;
                    e.Control.KeyPress += onControlKeyPress;
                    e.Control.PreviewKeyDown -= onControlPreviewKeyDown;
                    e.Control.PreviewKeyDown += onControlPreviewKeyDown;
                }
            };
        }

        protected void onControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if(sender == null || sender.GetType() != typeof(DataGridViewTextBoxEditingControl)) {
                return;
            }
            DataGridView dgv = ((DataGridViewTextBoxEditingControl)sender).EditingControlDataGridView;

            if(dgv.CurrentCell.OwningColumn.GetType() != typeof(NumericColumn)) {
                return;
            }
            //(NumericColumn)dgv.CurrentCell.OwningColumn;

            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        protected virtual void numberingRowsHeader(DataGridViewCellPaintingEventArgs e)
        {
            if(e.ColumnIndex != -1) {
                return;
            }

            string str;
            if(e.RowIndex >= 0) {
                str = $" {(e.RowIndex + 1)}";
            }
            else {
                str = $"({Rows.Count})";
            }

            e.PaintBackground(e.CellBounds, true);
            e.Graphics.DrawString(str, e.CellStyle.Font, new SolidBrush(Color.Black), e.CellBounds);
            e.Handled = true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                EndEdit();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void onNumberingCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(NumberingForRowsHeader) {
                numberingRowsHeader(e);
            }
        }

        private void onAlwaysSelected(object sender, EventArgs e)
        {
            if(!AlwaysSelected || Rows.Count < 1) {
                return;
            }

            if(SelectedRows.Count < 1)
            {
                lastSelectedRowIndex = Math.Max(0, Math.Min(lastSelectedRowIndex, Rows.Count - 1));
                Rows[lastSelectedRowIndex].Selected = true;
                return;
            }

            lastSelectedRowIndex = SelectedRows[0].Index;
        }

        /// <summary>
        /// A trick with left/right keys in EditMode of text columns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onControlPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(sender == null || sender.GetType() != typeof(DataGridViewTextBoxEditingControl)) {
                return;
            }

            var box = (DataGridViewTextBoxEditingControl)sender;
            int pos = box.SelectionStart;

            if(box.Text.Length < 1) {
                return;
            }

            if(pos == 0 && e.KeyData == Keys.Left) 
            {
                BeginEdit(false);
                box.SelectionStart = Math.Min(1, box.Text.Length); // will decrease with std handler
                return;
            }

            if(pos == box.Text.Length && e.KeyData == Keys.Right) 
            {
                BeginEdit(false);
                box.SelectionStart = box.Text.Length - 1; // also will with std handler later
                return;
            }
        }
    }
}
