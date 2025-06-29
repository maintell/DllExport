﻿namespace net.r_eg.DllExport.Wizard.UI.Controls
{
    partial class PreProcControl
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
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radioPreProcDisabled = new System.Windows.Forms.RadioButton();
            this.linkPreProc = new System.Windows.Forms.LinkLabel();
            this.linkAboutConari = new System.Windows.Forms.LinkLabel();
            this.txtPreProc = new net.r_eg.DllExport.Wizard.UI.Components.TextBoxExt();
            this.radioRawExec = new System.Windows.Forms.RadioButton();
            this.radioILMerge = new System.Windows.Forms.RadioButton();
            this.chkMergeConari = new System.Windows.Forms.CheckBox();
            this.chkIgnoreErrors = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioILRepack = new System.Windows.Forms.RadioButton();
            this.chkMergeRef = new System.Windows.Forms.CheckBox();
            this.chkGenDebugInfo = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkLib = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // radioPreProcDisabled
            // 
            this.radioPreProcDisabled.AutoSize = true;
            this.radioPreProcDisabled.Checked = true;
            this.radioPreProcDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPreProcDisabled.Location = new System.Drawing.Point(373, 51);
            this.radioPreProcDisabled.Name = "radioPreProcDisabled";
            this.radioPreProcDisabled.Size = new System.Drawing.Size(65, 17);
            this.radioPreProcDisabled.TabIndex = 25;
            this.radioPreProcDisabled.TabStop = true;
            this.radioPreProcDisabled.Text = "Disabled";
            this.toolTip1.SetToolTip(this.radioPreProcDisabled, "To disable Pre-Processing");
            this.radioPreProcDisabled.UseVisualStyleBackColor = true;
            this.radioPreProcDisabled.CheckedChanged += new System.EventHandler(this.RadioPreProcDisabled_CheckedChanged);
            // 
            // linkPreProc
            // 
            this.linkPreProc.AutoSize = true;
            this.linkPreProc.Location = new System.Drawing.Point(6, 27);
            this.linkPreProc.Name = "linkPreProc";
            this.linkPreProc.Size = new System.Drawing.Size(13, 13);
            this.linkPreProc.TabIndex = 24;
            this.linkPreProc.TabStop = true;
            this.linkPreProc.Text = "?";
            this.linkPreProc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkPreProc_LinkClicked);
            // 
            // linkAboutConari
            // 
            this.linkAboutConari.AutoSize = true;
            this.linkAboutConari.Location = new System.Drawing.Point(88, 5);
            this.linkAboutConari.Name = "linkAboutConari";
            this.linkAboutConari.Size = new System.Drawing.Size(37, 13);
            this.linkAboutConari.TabIndex = 23;
            this.linkAboutConari.TabStop = true;
            this.linkAboutConari.Text = "Conari";
            this.toolTip1.SetToolTip(this.linkAboutConari, "Add Conari inside final module for easy access to unmanaged features");
            this.linkAboutConari.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkAboutConari_LinkClicked);
            // 
            // txtPreProc
            // 
            this.txtPreProc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreProc.BackColor = System.Drawing.SystemColors.Control;
            this.txtPreProc.BackgroundCaption = "";
            this.txtPreProc.BackgroundCaptionAlpha = 60;
            this.txtPreProc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreProc.Enabled = false;
            this.txtPreProc.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreProc.FontBold = false;
            this.txtPreProc.Location = new System.Drawing.Point(3, 74);
            this.txtPreProc.Multiline = true;
            this.txtPreProc.Name = "txtPreProc";
            this.txtPreProc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreProc.Size = new System.Drawing.Size(436, 150);
            this.txtPreProc.TabIndex = 22;
            // 
            // radioRawExec
            // 
            this.radioRawExec.AutoSize = true;
            this.radioRawExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioRawExec.Location = new System.Drawing.Point(25, 49);
            this.radioRawExec.Name = "radioRawExec";
            this.radioRawExec.Size = new System.Drawing.Size(97, 17);
            this.radioRawExec.TabIndex = 20;
            this.radioRawExec.Text = "Exec command";
            this.toolTip1.SetToolTip(this.radioRawExec, "Execute command via <Exec Command=\"...your code below...\" WorkingDirectory=\"$(Tar" +
        "getDir)\" />\"");
            this.radioRawExec.UseVisualStyleBackColor = true;
            this.radioRawExec.CheckedChanged += new System.EventHandler(this.RadioRawExec_CheckedChanged);
            // 
            // radioILMerge
            // 
            this.radioILMerge.AutoSize = true;
            this.radioILMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioILMerge.Location = new System.Drawing.Point(25, 27);
            this.radioILMerge.Name = "radioILMerge";
            this.radioILMerge.Size = new System.Drawing.Size(63, 17);
            this.radioILMerge.TabIndex = 19;
            this.radioILMerge.Text = "ILMerge";
            this.toolTip1.SetToolTip(this.radioILMerge, "Merge modules via ILMerge; arguments and/or modules must separated by a whitespac" +
        "e:\r\nModule1 Module2 /arg1 ...");
            this.radioILMerge.UseVisualStyleBackColor = true;
            this.radioILMerge.CheckedChanged += new System.EventHandler(this.RadioILMerge_CheckedChanged);
            // 
            // chkMergeConari
            // 
            this.chkMergeConari.AutoSize = true;
            this.chkMergeConari.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkMergeConari.Location = new System.Drawing.Point(25, 4);
            this.chkMergeConari.Name = "chkMergeConari";
            this.chkMergeConari.Size = new System.Drawing.Size(66, 17);
            this.chkMergeConari.TabIndex = 18;
            this.chkMergeConari.Text = "Integrate";
            this.toolTip1.SetToolTip(this.chkMergeConari, "Add Conari inside final module for easy access to unmanaged features");
            this.chkMergeConari.UseVisualStyleBackColor = true;
            this.chkMergeConari.CheckedChanged += new System.EventHandler(this.ChkMergeConari_CheckedChanged);
            // 
            // chkIgnoreErrors
            // 
            this.chkIgnoreErrors.AutoSize = true;
            this.chkIgnoreErrors.Enabled = false;
            this.chkIgnoreErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIgnoreErrors.Location = new System.Drawing.Point(186, 49);
            this.chkIgnoreErrors.Name = "chkIgnoreErrors";
            this.chkIgnoreErrors.Size = new System.Drawing.Size(82, 17);
            this.chkIgnoreErrors.TabIndex = 26;
            this.chkIgnoreErrors.Text = "Ignore errors";
            this.chkIgnoreErrors.UseVisualStyleBackColor = true;
            // 
            // radioILRepack
            // 
            this.radioILRepack.AutoSize = true;
            this.radioILRepack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioILRepack.Location = new System.Drawing.Point(94, 27);
            this.radioILRepack.Name = "radioILRepack";
            this.radioILRepack.Size = new System.Drawing.Size(71, 17);
            this.radioILRepack.TabIndex = 30;
            this.radioILRepack.Text = "ILRepack";
            this.toolTip1.SetToolTip(this.radioILRepack, "Merge modules via ILRepack; arguments and/or modules must separated by a whitespa" +
        "ce:\r\nModule1 Module2 /arg1 ...");
            this.radioILRepack.UseVisualStyleBackColor = true;
            this.radioILRepack.CheckedChanged += new System.EventHandler(this.radioILRepack_CheckedChanged);
            // 
            // chkMergeRef
            // 
            this.chkMergeRef.AutoSize = true;
            this.chkMergeRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkMergeRef.Location = new System.Drawing.Point(186, 5);
            this.chkMergeRef.Name = "chkMergeRef";
            this.chkMergeRef.Size = new System.Drawing.Size(146, 17);
            this.chkMergeRef.TabIndex = 31;
            this.chkMergeRef.Text = "Integrate [Ref] assemblies";
            this.toolTip1.SetToolTip(this.chkMergeRef, "All defined assemblies in [Ref] tab");
            this.chkMergeRef.UseVisualStyleBackColor = true;
            this.chkMergeRef.CheckedChanged += new System.EventHandler(this.ChkMergeRef_CheckedChanged);
            // 
            // chkGenDebugInfo
            // 
            this.chkGenDebugInfo.AutoSize = true;
            this.chkGenDebugInfo.Enabled = false;
            this.chkGenDebugInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGenDebugInfo.Location = new System.Drawing.Point(186, 27);
            this.chkGenDebugInfo.Name = "chkGenDebugInfo";
            this.chkGenDebugInfo.Size = new System.Drawing.Size(75, 17);
            this.chkGenDebugInfo.TabIndex = 27;
            this.chkGenDebugInfo.Text = "Debug info";
            this.toolTip1.SetToolTip(this.chkGenDebugInfo, "Generate debug info");
            this.chkGenDebugInfo.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Enabled = false;
            this.chkLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLog.Location = new System.Drawing.Point(274, 49);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(41, 17);
            this.chkLog.TabIndex = 29;
            this.chkLog.Text = "Log";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // chkLib
            // 
            this.chkLib.AutoSize = true;
            this.chkLib.Enabled = false;
            this.chkLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLib.Location = new System.Drawing.Point(274, 27);
            this.chkLib.Name = "chkLib";
            this.chkLib.Size = new System.Drawing.Size(37, 17);
            this.chkLib.TabIndex = 32;
            this.chkLib.Text = "Lib";
            this.toolTip1.SetToolTip(this.chkLib, "Apply /lib using DllExportPreProcSysLibs");
            this.chkLib.UseVisualStyleBackColor = true;
            // 
            // PreProcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chkLib);
            this.Controls.Add(this.chkMergeRef);
            this.Controls.Add(this.radioILRepack);
            this.Controls.Add(this.chkLog);
            this.Controls.Add(this.chkGenDebugInfo);
            this.Controls.Add(this.chkIgnoreErrors);
            this.Controls.Add(this.radioPreProcDisabled);
            this.Controls.Add(this.linkPreProc);
            this.Controls.Add(this.linkAboutConari);
            this.Controls.Add(this.txtPreProc);
            this.Controls.Add(this.radioRawExec);
            this.Controls.Add(this.radioILMerge);
            this.Controls.Add(this.chkMergeConari);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "PreProcControl";
            this.Size = new System.Drawing.Size(441, 227);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioPreProcDisabled;
        private System.Windows.Forms.LinkLabel linkPreProc;
        private System.Windows.Forms.LinkLabel linkAboutConari;
        private net.r_eg.DllExport.Wizard.UI.Components.TextBoxExt txtPreProc;
        private System.Windows.Forms.RadioButton radioRawExec;
        private System.Windows.Forms.RadioButton radioILMerge;
        private System.Windows.Forms.CheckBox chkMergeConari;
        private System.Windows.Forms.CheckBox chkIgnoreErrors;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkGenDebugInfo;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.RadioButton radioILRepack;
        private System.Windows.Forms.CheckBox chkMergeRef;
        private System.Windows.Forms.CheckBox chkLib;
    }
}
