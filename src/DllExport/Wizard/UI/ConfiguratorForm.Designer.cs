﻿namespace net.r_eg.DllExport.Wizard.UI
{
    partial class ConfiguratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            fdialog?.Dispose();
            icons?.Dispose();

            if(ctsUpdater != null)
            {
                ctsUpdater.Cancel();
                ctsUpdater.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfiguratorForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.progressLine = new net.r_eg.DllExport.Wizard.UI.Controls.ProgressLineControl();
            this.btnApply = new System.Windows.Forms.Button();
            this.comboBoxSln = new System.Windows.Forms.ComboBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdListOfPkg = new System.Windows.Forms.Button();
            this.comboBoxStorage = new System.Windows.Forms.ComboBox();
            this.chkPin = new System.Windows.Forms.CheckBox();
            this.splitCon = new System.Windows.Forms.SplitContainer();
            this.panelPrjs = new System.Windows.Forms.Panel();
            this.dgvFilter = new net.r_eg.DllExport.Wizard.UI.Components.DataGridViewExt();
            this.gcInstalled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gcType = new System.Windows.Forms.DataGridViewImageColumn();
            this.gcPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabCfgDxp = new System.Windows.Forms.TabPage();
            this.projectItems = new net.r_eg.DllExport.Wizard.UI.Controls.ProjectItemsControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.labelStorage = new System.Windows.Forms.Label();
            this.txtCfgData = new System.Windows.Forms.TextBox();
            this.tabPreProc = new System.Windows.Forms.TabPage();
            this.preProcControl = new net.r_eg.DllExport.Wizard.UI.Controls.PreProcControl();
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.typeRefControl = new net.r_eg.DllExport.Wizard.UI.Controls.TypeRefControl();
            this.tabAsm = new System.Windows.Forms.TabPage();
            this.asmControl = new net.r_eg.DllExport.Wizard.UI.Controls.AsmControl();
            this.tabRef = new System.Windows.Forms.TabPage();
            this.refControl = new net.r_eg.DllExport.Wizard.UI.Controls.RefControl();
            this.tabPostProc = new System.Windows.Forms.TabPage();
            this.postProcControl = new net.r_eg.DllExport.Wizard.UI.Controls.PostProcControl();
            this.tabUpdating = new System.Windows.Forms.TabPage();
            this.txtLogUpd = new System.Windows.Forms.TextBox();
            this.panelUpdVerTop = new System.Windows.Forms.Panel();
            this.cbPackages = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabBuildInfo = new System.Windows.Forms.TabPage();
            this.labelSrcMit = new System.Windows.Forms.Label();
            this.linkIlasm = new System.Windows.Forms.LinkLabel();
            this.lnkSrc = new System.Windows.Forms.LinkLabel();
            this.lnk3F = new System.Windows.Forms.LinkLabel();
            this.labelSrc = new System.Windows.Forms.Label();
            this.txtBuildInfo = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCon)).BeginInit();
            this.splitCon.Panel1.SuspendLayout();
            this.splitCon.Panel2.SuspendLayout();
            this.splitCon.SuspendLayout();
            this.panelPrjs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.tabCtrl.SuspendLayout();
            this.tabCfgDxp.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tabPreProc.SuspendLayout();
            this.tabTypes.SuspendLayout();
            this.tabAsm.SuspendLayout();
            this.tabRef.SuspendLayout();
            this.tabPostProc.SuspendLayout();
            this.tabUpdating.SuspendLayout();
            this.panelUpdVerTop.SuspendLayout();
            this.tabBuildInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTop.Controls.Add(this.progressLine);
            this.panelTop.Controls.Add(this.btnApply);
            this.panelTop.Controls.Add(this.comboBoxSln);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(446, 29);
            this.panelTop.TabIndex = 0;
            // 
            // progressLine
            // 
            this.progressLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressLine.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.progressLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressLine.Location = new System.Drawing.Point(0, 21);
            this.progressLine.Name = "progressLine";
            this.progressLine.Size = new System.Drawing.Size(275, 5);
            this.progressLine.TabIndex = 8;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(381, 1);
            this.btnApply.Margin = new System.Windows.Forms.Padding(1);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(61, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.toolTipMain.SetToolTip(this.btnApply, "Apply changes");
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // comboBoxSln
            // 
            this.comboBoxSln.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSln.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSln.DropDownWidth = 500;
            this.comboBoxSln.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSln.FormattingEnabled = true;
            this.comboBoxSln.Location = new System.Drawing.Point(1, 2);
            this.comboBoxSln.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxSln.Name = "comboBoxSln";
            this.comboBoxSln.Size = new System.Drawing.Size(378, 21);
            this.comboBoxSln.TabIndex = 0;
            this.toolTipMain.SetToolTip(this.comboBoxSln, "Solution File");
            this.comboBoxSln.SelectedIndexChanged += new System.EventHandler(this.comboBoxSln_SelectedIndexChanged);
            // 
            // btnUpdListOfPkg
            // 
            this.btnUpdListOfPkg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdListOfPkg.Location = new System.Drawing.Point(287, 4);
            this.btnUpdListOfPkg.Name = "btnUpdListOfPkg";
            this.btnUpdListOfPkg.Size = new System.Drawing.Size(38, 23);
            this.btnUpdListOfPkg.TabIndex = 2;
            this.btnUpdListOfPkg.Text = "( @ )";
            this.toolTipMain.SetToolTip(this.btnUpdListOfPkg, "<< Receive new list");
            this.btnUpdListOfPkg.UseVisualStyleBackColor = true;
            this.btnUpdListOfPkg.Click += new System.EventHandler(this.BtnUpdListOfPkg_Click);
            // 
            // comboBoxStorage
            // 
            this.comboBoxStorage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStorage.DropDownWidth = 190;
            this.comboBoxStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStorage.FormattingEnabled = true;
            this.comboBoxStorage.Location = new System.Drawing.Point(251, 4);
            this.comboBoxStorage.Margin = new System.Windows.Forms.Padding(1);
            this.comboBoxStorage.Name = "comboBoxStorage";
            this.comboBoxStorage.Size = new System.Drawing.Size(170, 21);
            this.comboBoxStorage.TabIndex = 14;
            this.toolTipMain.SetToolTip(this.comboBoxStorage, "Storage");
            // 
            // chkPin
            // 
            this.chkPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPin.AutoSize = true;
            this.chkPin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkPin.Image = ((System.Drawing.Image)(resources.GetObject("chkPin.Image")));
            this.chkPin.Location = new System.Drawing.Point(405, 0);
            this.chkPin.Name = "chkPin";
            this.chkPin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPin.Size = new System.Drawing.Size(33, 17);
            this.chkPin.TabIndex = 22;
            this.chkPin.Text = "   ";
            this.toolTipMain.SetToolTip(this.chkPin, "Pin window");
            this.chkPin.UseVisualStyleBackColor = true;
            this.chkPin.CheckedChanged += new System.EventHandler(this.ChkPin_CheckedChanged);
            // 
            // splitCon
            // 
            this.splitCon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCon.IsSplitterFixed = true;
            this.splitCon.Location = new System.Drawing.Point(0, 29);
            this.splitCon.Margin = new System.Windows.Forms.Padding(0);
            this.splitCon.Name = "splitCon";
            this.splitCon.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCon.Panel1
            // 
            this.splitCon.Panel1.Controls.Add(this.panelPrjs);
            this.splitCon.Panel1.Controls.Add(this.panelFilter);
            // 
            // splitCon.Panel2
            // 
            this.splitCon.Panel2.Controls.Add(this.tabCtrl);
            this.splitCon.Size = new System.Drawing.Size(446, 363);
            this.splitCon.SplitterDistance = 81;
            this.splitCon.TabIndex = 2;
            // 
            // panelPrjs
            // 
            this.panelPrjs.Controls.Add(this.dgvFilter);
            this.panelPrjs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrjs.Location = new System.Drawing.Point(0, 19);
            this.panelPrjs.Margin = new System.Windows.Forms.Padding(0);
            this.panelPrjs.Name = "panelPrjs";
            this.panelPrjs.Size = new System.Drawing.Size(446, 62);
            this.panelPrjs.TabIndex = 2;
            // 
            // dgvFilter
            // 
            this.dgvFilter.AllowUserToAddRows = false;
            this.dgvFilter.AllowUserToDeleteRows = false;
            this.dgvFilter.AllowUserToResizeRows = false;
            this.dgvFilter.AlwaysSelected = true;
            this.dgvFilter.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFilter.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilter.ColumnHeadersVisible = false;
            this.dgvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gcInstalled,
            this.gcType,
            this.gcPath});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilter.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilter.DragDropSortable = false;
            this.dgvFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFilter.Location = new System.Drawing.Point(0, 0);
            this.dgvFilter.Margin = new System.Windows.Forms.Padding(0);
            this.dgvFilter.MultiSelect = false;
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.NumberingForRowsHeader = false;
            this.dgvFilter.ReadOnly = true;
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.RowHeadersWidth = 28;
            this.dgvFilter.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFilter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilter.Size = new System.Drawing.Size(446, 62);
            this.dgvFilter.TabIndex = 0;
            this.dgvFilter.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilter_RowEnter);
            this.dgvFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFilter_KeyDown);
            // 
            // gcInstalled
            // 
            this.gcInstalled.HeaderText = "";
            this.gcInstalled.MinimumWidth = 2;
            this.gcInstalled.Name = "gcInstalled";
            this.gcInstalled.ReadOnly = true;
            this.gcInstalled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcInstalled.Width = 6;
            // 
            // gcType
            // 
            this.gcType.HeaderText = "Type";
            this.gcType.MinimumWidth = 16;
            this.gcType.Name = "gcType";
            this.gcType.ReadOnly = true;
            this.gcType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gcType.ToolTipText = "Project Type";
            this.gcType.Width = 32;
            // 
            // gcPath
            // 
            this.gcPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gcPath.HeaderText = "Path";
            this.gcPath.MinimumWidth = 70;
            this.gcPath.Name = "gcPath";
            this.gcPath.ReadOnly = true;
            this.gcPath.ToolTipText = "Path to project file";
            // 
            // panelFilter
            // 
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(446, 19);
            this.panelFilter.TabIndex = 1;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabCtrl.Controls.Add(this.tabCfgDxp);
            this.tabCtrl.Controls.Add(this.tabData);
            this.tabCtrl.Controls.Add(this.tabPreProc);
            this.tabCtrl.Controls.Add(this.tabTypes);
            this.tabCtrl.Controls.Add(this.tabAsm);
            this.tabCtrl.Controls.Add(this.tabRef);
            this.tabCtrl.Controls.Add(this.tabPostProc);
            this.tabCtrl.Controls.Add(this.tabUpdating);
            this.tabCtrl.Controls.Add(this.tabBuildInfo);
            this.tabCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCtrl.Location = new System.Drawing.Point(-4, 0);
            this.tabCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(450, 283);
            this.tabCtrl.TabIndex = 0;
            this.tabCtrl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCtrl_Selected);
            // 
            // tabCfgDxp
            // 
            this.tabCfgDxp.Controls.Add(this.projectItems);
            this.tabCfgDxp.Location = new System.Drawing.Point(4, 25);
            this.tabCfgDxp.Name = "tabCfgDxp";
            this.tabCfgDxp.Padding = new System.Windows.Forms.Padding(3);
            this.tabCfgDxp.Size = new System.Drawing.Size(442, 254);
            this.tabCfgDxp.TabIndex = 0;
            this.tabCfgDxp.Text = "Options";
            this.tabCfgDxp.UseVisualStyleBackColor = true;
            // 
            // projectItems
            // 
            this.projectItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectItems.BackColor = System.Drawing.SystemColors.Control;
            this.projectItems.Browse = null;
            this.projectItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.projectItems.Location = new System.Drawing.Point(0, 0);
            this.projectItems.Margin = new System.Windows.Forms.Padding(0);
            this.projectItems.Name = "projectItems";
            this.projectItems.NamespaceValidate = null;
            this.projectItems.OpenUrl = null;
            this.projectItems.Size = new System.Drawing.Size(448, 274);
            this.projectItems.TabIndex = 2;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.labelStorage);
            this.tabData.Controls.Add(this.comboBoxStorage);
            this.tabData.Controls.Add(this.txtCfgData);
            this.tabData.Location = new System.Drawing.Point(4, 25);
            this.tabData.Name = "tabData";
            this.tabData.Size = new System.Drawing.Size(442, 254);
            this.tabData.TabIndex = 3;
            this.tabData.Text = "Data";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // labelStorage
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(180, 7);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(67, 13);
            this.labelStorage.TabIndex = 15;
            this.labelStorage.Text = "Use storage:";
            // 
            // txtCfgData
            // 
            this.txtCfgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCfgData.BackColor = System.Drawing.SystemColors.Window;
            this.txtCfgData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCfgData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCfgData.Location = new System.Drawing.Point(3, 29);
            this.txtCfgData.Multiline = true;
            this.txtCfgData.Name = "txtCfgData";
            this.txtCfgData.ReadOnly = true;
            this.txtCfgData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCfgData.Size = new System.Drawing.Size(436, 219);
            this.txtCfgData.TabIndex = 13;
            // 
            // tabPreProc
            // 
            this.tabPreProc.Controls.Add(this.preProcControl);
            this.tabPreProc.Location = new System.Drawing.Point(4, 25);
            this.tabPreProc.Name = "tabPreProc";
            this.tabPreProc.Size = new System.Drawing.Size(442, 254);
            this.tabPreProc.TabIndex = 4;
            this.tabPreProc.Text = "Pre-processing";
            this.tabPreProc.UseVisualStyleBackColor = true;
            // 
            // preProcControl
            // 
            this.preProcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preProcControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.preProcControl.Location = new System.Drawing.Point(0, 0);
            this.preProcControl.Name = "preProcControl";
            this.preProcControl.Size = new System.Drawing.Size(442, 254);
            this.preProcControl.TabIndex = 0;
            // 
            // tabTypes
            // 
            this.tabTypes.Controls.Add(this.typeRefControl);
            this.tabTypes.Location = new System.Drawing.Point(4, 25);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Size = new System.Drawing.Size(442, 254);
            this.tabTypes.TabIndex = 6;
            this.tabTypes.Text = "Types";
            this.tabTypes.UseVisualStyleBackColor = true;
            // 
            // typeRefControl
            // 
            this.typeRefControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.typeRefControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.typeRefControl.Location = new System.Drawing.Point(0, 0);
            this.typeRefControl.Margin = new System.Windows.Forms.Padding(0);
            this.typeRefControl.Name = "typeRefControl";
            this.typeRefControl.Size = new System.Drawing.Size(442, 254);
            this.typeRefControl.TabIndex = 0;
            // 
            // tabAsm
            // 
            this.tabAsm.Controls.Add(this.asmControl);
            this.tabAsm.Location = new System.Drawing.Point(4, 25);
            this.tabAsm.Name = "tabAsm";
            this.tabAsm.Size = new System.Drawing.Size(442, 254);
            this.tabAsm.TabIndex = 7;
            this.tabAsm.Text = "Asm";
            this.tabAsm.UseVisualStyleBackColor = true;
            // 
            // asmControl
            // 
            this.asmControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.asmControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.asmControl.Location = new System.Drawing.Point(0, 0);
            this.asmControl.Margin = new System.Windows.Forms.Padding(0);
            this.asmControl.Name = "asmControl";
            this.asmControl.Size = new System.Drawing.Size(442, 254);
            this.asmControl.TabIndex = 0;
            // 
            // tabRef
            // 
            this.tabRef.Controls.Add(this.refControl);
            this.tabRef.Location = new System.Drawing.Point(4, 25);
            this.tabRef.Name = "tabRef";
            this.tabRef.Size = new System.Drawing.Size(442, 254);
            this.tabRef.TabIndex = 8;
            this.tabRef.Text = "Ref";
            this.tabRef.UseVisualStyleBackColor = true;
            // 
            // refControl
            // 
            this.refControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.refControl.Location = new System.Drawing.Point(0, 0);
            this.refControl.Name = "refControl";
            this.refControl.Size = new System.Drawing.Size(442, 254);
            this.refControl.TabIndex = 0;
            // 
            // tabPostProc
            // 
            this.tabPostProc.Controls.Add(this.postProcControl);
            this.tabPostProc.Location = new System.Drawing.Point(4, 25);
            this.tabPostProc.Name = "tabPostProc";
            this.tabPostProc.Size = new System.Drawing.Size(442, 254);
            this.tabPostProc.TabIndex = 5;
            this.tabPostProc.Text = "Post";
            this.tabPostProc.UseVisualStyleBackColor = true;
            // 
            // postProcControl
            // 
            this.postProcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postProcControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.postProcControl.Location = new System.Drawing.Point(0, 0);
            this.postProcControl.Margin = new System.Windows.Forms.Padding(0);
            this.postProcControl.Name = "postProcControl";
            this.postProcControl.Size = new System.Drawing.Size(442, 254);
            this.postProcControl.TabIndex = 0;
            // 
            // tabUpdating
            // 
            this.tabUpdating.Controls.Add(this.txtLogUpd);
            this.tabUpdating.Controls.Add(this.panelUpdVerTop);
            this.tabUpdating.Location = new System.Drawing.Point(4, 25);
            this.tabUpdating.Name = "tabUpdating";
            this.tabUpdating.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdating.Size = new System.Drawing.Size(442, 254);
            this.tabUpdating.TabIndex = 2;
            this.tabUpdating.Text = "Updater";
            this.tabUpdating.UseVisualStyleBackColor = true;
            // 
            // txtLogUpd
            // 
            this.txtLogUpd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogUpd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.txtLogUpd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLogUpd.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogUpd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.txtLogUpd.Location = new System.Drawing.Point(0, 33);
            this.txtLogUpd.Multiline = true;
            this.txtLogUpd.Name = "txtLogUpd";
            this.txtLogUpd.ReadOnly = true;
            this.txtLogUpd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogUpd.Size = new System.Drawing.Size(446, 222);
            this.txtLogUpd.TabIndex = 13;
            this.txtLogUpd.WordWrap = false;
            // 
            // panelUpdVerTop
            // 
            this.panelUpdVerTop.Controls.Add(this.btnUpdListOfPkg);
            this.panelUpdVerTop.Controls.Add(this.cbPackages);
            this.panelUpdVerTop.Controls.Add(this.btnUpdate);
            this.panelUpdVerTop.Location = new System.Drawing.Point(39, 0);
            this.panelUpdVerTop.Name = "panelUpdVerTop";
            this.panelUpdVerTop.Size = new System.Drawing.Size(342, 34);
            this.panelUpdVerTop.TabIndex = 14;
            // 
            // cbPackages
            // 
            this.cbPackages.FormattingEnabled = true;
            this.cbPackages.Location = new System.Drawing.Point(121, 6);
            this.cbPackages.Name = "cbPackages";
            this.cbPackages.Size = new System.Drawing.Size(160, 21);
            this.cbPackages.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(11, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update to";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // tabBuildInfo
            // 
            this.tabBuildInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabBuildInfo.Controls.Add(this.chkPin);
            this.tabBuildInfo.Controls.Add(this.labelSrcMit);
            this.tabBuildInfo.Controls.Add(this.linkIlasm);
            this.tabBuildInfo.Controls.Add(this.lnkSrc);
            this.tabBuildInfo.Controls.Add(this.lnk3F);
            this.tabBuildInfo.Controls.Add(this.labelSrc);
            this.tabBuildInfo.Controls.Add(this.txtBuildInfo);
            this.tabBuildInfo.Location = new System.Drawing.Point(4, 25);
            this.tabBuildInfo.Name = "tabBuildInfo";
            this.tabBuildInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuildInfo.Size = new System.Drawing.Size(442, 254);
            this.tabBuildInfo.TabIndex = 1;
            this.tabBuildInfo.Text = "# info";
            // 
            // labelSrcMit
            // 
            this.labelSrcMit.AutoSize = true;
            this.labelSrcMit.Location = new System.Drawing.Point(17, 23);
            this.labelSrcMit.Name = "labelSrcMit";
            this.labelSrcMit.Size = new System.Drawing.Size(78, 13);
            this.labelSrcMit.TabIndex = 21;
            this.labelSrcMit.Text = "( MIT License )";
            // 
            // linkIlasm
            // 
            this.linkIlasm.AutoSize = true;
            this.linkIlasm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIlasm.Location = new System.Drawing.Point(108, 23);
            this.linkIlasm.Name = "linkIlasm";
            this.linkIlasm.Size = new System.Drawing.Size(149, 13);
            this.linkIlasm.TabIndex = 20;
            this.linkIlasm.TabStop = true;
            this.linkIlasm.Text = "https://github.com/3F/coreclr";
            this.linkIlasm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIlasm_LinkClicked);
            // 
            // lnkSrc
            // 
            this.lnkSrc.AutoSize = true;
            this.lnkSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSrc.Location = new System.Drawing.Point(108, 3);
            this.lnkSrc.Name = "lnkSrc";
            this.lnkSrc.Size = new System.Drawing.Size(159, 13);
            this.lnkSrc.TabIndex = 16;
            this.lnkSrc.TabStop = true;
            this.lnkSrc.Text = "https://github.com/3F/DllExport";
            this.lnkSrc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSrc_LinkClicked);
            // 
            // lnk3F
            // 
            this.lnk3F.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk3F.AutoSize = true;
            this.lnk3F.Location = new System.Drawing.Point(422, 23);
            this.lnk3F.Name = "lnk3F";
            this.lnk3F.Size = new System.Drawing.Size(19, 13);
            this.lnk3F.TabIndex = 14;
            this.lnk3F.TabStop = true;
            this.lnk3F.Text = "3F";
            this.lnk3F.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk3F_LinkClicked);
            // 
            // labelSrc
            // 
            this.labelSrc.AutoSize = true;
            this.labelSrc.Location = new System.Drawing.Point(21, 3);
            this.labelSrc.Name = "labelSrc";
            this.labelSrc.Size = new System.Drawing.Size(68, 13);
            this.labelSrc.TabIndex = 13;
            this.labelSrc.Text = "Open source";
            // 
            // txtBuildInfo
            // 
            this.txtBuildInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtBuildInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuildInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuildInfo.Location = new System.Drawing.Point(3, 41);
            this.txtBuildInfo.Multiline = true;
            this.txtBuildInfo.Name = "txtBuildInfo";
            this.txtBuildInfo.ReadOnly = true;
            this.txtBuildInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBuildInfo.Size = new System.Drawing.Size(436, 207);
            this.txtBuildInfo.TabIndex = 12;
            // 
            // ConfiguratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(446, 392);
            this.Controls.Add(this.splitCon);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfiguratorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DllExport";
            this.Load += new System.EventHandler(this.ConfiguratorForm_Load);
            this.panelTop.ResumeLayout(false);
            this.splitCon.Panel1.ResumeLayout(false);
            this.splitCon.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCon)).EndInit();
            this.splitCon.ResumeLayout(false);
            this.panelPrjs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.tabCtrl.ResumeLayout(false);
            this.tabCfgDxp.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            this.tabPreProc.ResumeLayout(false);
            this.tabTypes.ResumeLayout(false);
            this.tabAsm.ResumeLayout(false);
            this.tabRef.ResumeLayout(false);
            this.tabPostProc.ResumeLayout(false);
            this.tabUpdating.ResumeLayout(false);
            this.tabUpdating.PerformLayout();
            this.panelUpdVerTop.ResumeLayout(false);
            this.tabBuildInfo.ResumeLayout(false);
            this.tabBuildInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox comboBoxSln;
        private System.Windows.Forms.ToolTip toolTipMain;
        private Controls.ProgressLineControl progressLine;
        private System.Windows.Forms.SplitContainer splitCon;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabCfgDxp;
        private Controls.ProjectItemsControl projectItems;
        private System.Windows.Forms.TabPage tabBuildInfo;
        private net.r_eg.DllExport.Wizard.UI.Components.DataGridViewExt dgvFilter;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Panel panelPrjs;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcInstalled;
        private System.Windows.Forms.DataGridViewImageColumn gcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gcPath;
        private System.Windows.Forms.TextBox txtBuildInfo;
        private System.Windows.Forms.Label labelSrc;
        private System.Windows.Forms.LinkLabel lnk3F;
        private System.Windows.Forms.LinkLabel lnkSrc;
        private System.Windows.Forms.LinkLabel linkIlasm;
        private System.Windows.Forms.TabPage tabUpdating;
        private System.Windows.Forms.ComboBox cbPackages;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtLogUpd;
        private System.Windows.Forms.Panel panelUpdVerTop;
        private System.Windows.Forms.Button btnUpdListOfPkg;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Label labelStorage;
        private System.Windows.Forms.ComboBox comboBoxStorage;
        private System.Windows.Forms.TextBox txtCfgData;
        private System.Windows.Forms.Label labelSrcMit;
        private System.Windows.Forms.TabPage tabPreProc;
        private Controls.PreProcControl preProcControl;
        private System.Windows.Forms.TabPage tabPostProc;
        private Controls.PostProcControl postProcControl;
        private System.Windows.Forms.TabPage tabTypes;
        private System.Windows.Forms.TabPage tabAsm;
        private Controls.TypeRefControl typeRefControl;
        private Controls.AsmControl asmControl;
        private System.Windows.Forms.TabPage tabRef;
        private Controls.RefControl refControl;
        private System.Windows.Forms.CheckBox chkPin;
    }
}