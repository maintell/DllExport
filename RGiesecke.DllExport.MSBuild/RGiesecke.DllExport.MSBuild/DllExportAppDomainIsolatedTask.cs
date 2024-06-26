﻿/*!
 * Copyright (c) Robert Giesecke
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;
using System.Resources;
using System.Security.Permissions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace RGiesecke.DllExport.MSBuild
{
    [LoadInSeparateAppDomain]
    [PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class DllExportAppDomainIsolatedTask: AppDomainIsolatedTask, IDllExportTask, IInputValues, IInputRawValues, IServiceProvider, ITask
    {
        private readonly ExportTaskImplementation<DllExportAppDomainIsolatedTask> _ExportTaskImplementation;

        public string MethodAttributes
        {
            get {
                return this._ExportTaskImplementation.MethodAttributes;
            }

            set {
                this._ExportTaskImplementation.MethodAttributes = value;
            }
        }

        bool? IDllExportTask.SkipOnAnyCpu
        {
            get {
                return this._ExportTaskImplementation.SkipOnAnyCpu;
            }

            set {
                this._ExportTaskImplementation.SkipOnAnyCpu = value;
            }
        }

        public string SkipOnAnyCpu
        {
            get {
                return Convert.ToString((object)this._ExportTaskImplementation.SkipOnAnyCpu);
            }

            set {
                if(string.IsNullOrEmpty(value))
                {
                    this._ExportTaskImplementation.SkipOnAnyCpu = new bool?();
                }
                else
                {
                    this._ExportTaskImplementation.SkipOnAnyCpu = new bool?(Convert.ToBoolean(value));
                }
            }
        }

        public string TargetFrameworkVersion
        {
            get {
                return this._ExportTaskImplementation.TargetFrameworkVersion;
            }

            set {
                this._ExportTaskImplementation.TargetFrameworkVersion = value;
            }
        }

        public string Platform
        {
            get {
                return this._ExportTaskImplementation.Platform;
            }

            set {
                this._ExportTaskImplementation.Platform = value;
            }
        }

        public string CpuType
        {
            get {
                return this._ExportTaskImplementation.CpuType;
            }

            set {
                this._ExportTaskImplementation.CpuType = value;
            }
        }

        public string ProjectDirectory
        {
            get {
                return this._ExportTaskImplementation.ProjectDirectory;
            }

            set {
                this._ExportTaskImplementation.ProjectDirectory = value;
            }
        }

        public string AssemblyKeyContainerName
        {
            get {
                return this._ExportTaskImplementation.AssemblyKeyContainerName;
            }

            set {
                this._ExportTaskImplementation.AssemblyKeyContainerName = value;
            }
        }

        public int Timeout
        {
            get {
                return this._ExportTaskImplementation.Timeout;
            }

            set {
                this._ExportTaskImplementation.Timeout = value;
            }
        }

        public CpuPlatform Cpu
        {
            get {
                return this._ExportTaskImplementation.Cpu;
            }

            set {
                this._ExportTaskImplementation.Cpu = value;
            }
        }

        public bool EmitDebugSymbols
        {
            get {
                return this._ExportTaskImplementation.EmitDebugSymbols;
            }

            set {
                this._ExportTaskImplementation.EmitDebugSymbols = value;
            }
        }

        public string LeaveIntermediateFiles
        {
            get {
                return this._ExportTaskImplementation.LeaveIntermediateFiles;
            }

            set {
                this._ExportTaskImplementation.LeaveIntermediateFiles = value;
            }
        }

        public string FileName
        {
            get {
                return this._ExportTaskImplementation.FileName;
            }

            set {
                this._ExportTaskImplementation.FileName = value;
            }
        }

        [Required]
        public string FrameworkPath
        {
            get {
                return this._ExportTaskImplementation.FrameworkPath;
            }

            set {
                this._ExportTaskImplementation.FrameworkPath = value;
            }
        }

        public string VsDevCmd
        {
            get {
                return _ExportTaskImplementation.VsDevCmd;
            }

            set {
                _ExportTaskImplementation.VsDevCmd = value;
            }
        }

        public string VcVarsAll
        {
            get {
                return _ExportTaskImplementation.VcVarsAll;
            }

            set {
                _ExportTaskImplementation.VcVarsAll = value;
            }
        }

        public string LibToolPath
        {
            get {
                return this._ExportTaskImplementation.LibToolPath;
            }

            set {
                this._ExportTaskImplementation.LibToolPath = value;
            }
        }

        public string LibToolDllPath
        {
            get {
                return this._ExportTaskImplementation.LibToolDllPath;
            }

            set {
                this._ExportTaskImplementation.LibToolDllPath = value;
            }
        }

        [Required]
        public string InputFileName
        {
            get {
                return this._ExportTaskImplementation.InputFileName;
            }

            set {
                this._ExportTaskImplementation.InputFileName = value;
            }
        }

        public string KeyContainer
        {
            get {
                return this._ExportTaskImplementation.KeyContainer;
            }

            set {
                this._ExportTaskImplementation.KeyContainer = value;
            }
        }

        public string KeyFile
        {
            get {
                return this._ExportTaskImplementation.KeyFile;
            }

            set {
                this._ExportTaskImplementation.KeyFile = value;
            }
        }

        public string OutputFileName
        {
            get {
                return this._ExportTaskImplementation.OutputFileName;
            }

            set {
                this._ExportTaskImplementation.OutputFileName = value;
            }
        }

        public string RootDirectory
        {
            get {
                return this._ExportTaskImplementation.RootDirectory;
            }

            set {
                this._ExportTaskImplementation.RootDirectory = value;
            }
        }

        public string SdkPath
        {
            get {
                return this._ExportTaskImplementation.SdkPath;
            }

            set {
                this._ExportTaskImplementation.SdkPath = value;
            }
        }

        public int OrdinalsBase
        {
            get {
                return _ExportTaskImplementation.OrdinalsBase;
            }

            set {
                _ExportTaskImplementation.OrdinalsBase = value;
            }
        }

        public bool GenExpLib
        {
            get {
                return _ExportTaskImplementation.GenExpLib;
            }

            set {
                _ExportTaskImplementation.GenExpLib = value;
            }
        }

        public string OurILAsmPath
        {
            get {
                return _ExportTaskImplementation.OurILAsmPath;
            }

            set {
                _ExportTaskImplementation.OurILAsmPath = value;
            }
        }

        public bool SysObjRebase
        {
            get => _ExportTaskImplementation.SysObjRebase;
            set => _ExportTaskImplementation.SysObjRebase = value;
        }

        public string ProcEnv
        {
            get => _ExportTaskImplementation.ProcEnv;
            set => _ExportTaskImplementation.ProcEnv = value;
        }

        public string MetaLib
        {
            get {
                return _ExportTaskImplementation.MetaLib;
            }

            set {
                _ExportTaskImplementation.MetaLib = value;
            }
        }

        public PatchesType Patches
        {
            get => _ExportTaskImplementation.Patches;
            set => _ExportTaskImplementation.Patches = value;
        }

        public long PatchesRaw
        {
            set => Patches = (PatchesType)value;
        }

        public PeCheckType PeCheck
        {
            get => _ExportTaskImplementation.PeCheck;
            set => _ExportTaskImplementation.PeCheck = value;
        }

        public int PeCheckRaw
        {
            set => PeCheck = (PeCheckType)value;
        }

        public string DllExportAttributeFullName
        {
            get {
                return this._ExportTaskImplementation.DllExportAttributeFullName;
            }

            set {
                this._ExportTaskImplementation.DllExportAttributeFullName = value;
            }
        }

        public string DllExportAttributeAssemblyName
        {
            get {
                return this._ExportTaskImplementation.DllExportAttributeAssemblyName;
            }

            set {
                this._ExportTaskImplementation.DllExportAttributeAssemblyName = value;
            }
        }

        static DllExportAppDomainIsolatedTask()
        {
            AssemblyLoadingRedirection.EnsureSetup();
        }

        public DllExportAppDomainIsolatedTask()
        {
            this._ExportTaskImplementation = new ExportTaskImplementation<DllExportAppDomainIsolatedTask>(this);
        }

        public DllExportAppDomainIsolatedTask(ResourceManager taskResources)
        : base(taskResources)
        {
            this._ExportTaskImplementation = new ExportTaskImplementation<DllExportAppDomainIsolatedTask>(this);
        }

        public DllExportAppDomainIsolatedTask(ResourceManager taskResources, string helpKeywordPrefix)
        : base(taskResources, helpKeywordPrefix)
        {
            this._ExportTaskImplementation = new ExportTaskImplementation<DllExportAppDomainIsolatedTask>(this);
        }

        public IDllExportNotifier GetNotifier()
        {
            return this._ExportTaskImplementation.GetNotifier();
        }

        public void Notify(int severity, string code, string message, params object[] values)
        {
            this._ExportTaskImplementation.Notify(severity, code, message, values);
        }

        public void Notify(int severity, string code, string fileName, SourceCodePosition? startPosition, SourceCodePosition? endPosition, string message, params object[] values)
        {
            this._ExportTaskImplementation.Notify(severity, code, fileName, startPosition, endPosition, message, values);
        }

        [CLSCompliant(false)]
        public AssemblyBinaryProperties InferAssemblyBinaryProperties()
        {
            return this._ExportTaskImplementation.InferAssemblyBinaryProperties();
        }

        public void InferOutputFile()
        {
            this._ExportTaskImplementation.InferOutputFile();
        }

        public override bool Execute() => _ExportTaskImplementation.Execute();

        public object GetService(Type serviceType)
        {
            return _ExportTaskImplementation.GetService(serviceType);
        }
    }
}
