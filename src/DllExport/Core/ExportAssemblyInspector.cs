﻿/*!
 * Copyright (c) Robert Giesecke
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Mono.Cecil;

namespace net.r_eg.DllExport
{
    internal class ExportAssemblyInspector: MarshalByRefObject, IExportAssemblyInspector
    {
        public string DllExportAttributeFullName
        {
            get {
                if(this.InputValues == null)
                {
                    return Utilities.DllExportAttributeFullName;
                }
                return this.InputValues.DllExportAttributeFullName;
            }
        }

        public IInputValues InputValues
        {
            get;
            private set;
        }

        public ExportAssemblyInspector(IInputValues inputValues)
        {
            if(inputValues == null)
            {
                throw new ArgumentNullException("inputValues");
            }
            this.InputValues = inputValues;
        }

        public AssemblyExports ExtractExports(AssemblyDefinition assemblyDefinition)
        {
            return ExtractExports(assemblyDefinition, new ExtractExportHandler(TryExtractExport));
        }

        public AssemblyExports ExtractExports()
        {
            return ExtractExports(InputValues.InputFileName);
        }

        public AssemblyExports ExtractExports(string fileName)
        {
            AssemblyDefinition def = LoadAssembly(fileName);
            try
            {
                return ExtractExports(def);
            }
            finally
            {
                def.Dispose(); // 0.10.x
            }
        }

        private IList<TypeDefinition> TraverseNestedTypes(ICollection<TypeDefinition> types)
        {
            List<TypeDefinition> typeDefinitionList = new List<TypeDefinition>(types.Count);
            foreach(TypeDefinition type in (IEnumerable<TypeDefinition>)types)
            {
                typeDefinitionList.Add(type);
                if(type.HasNestedTypes)
                {
                    typeDefinitionList.AddRange((IEnumerable<TypeDefinition>)this.TraverseNestedTypes((ICollection<TypeDefinition>)type.NestedTypes));
                }
            }
            return (IList<TypeDefinition>)typeDefinitionList;
        }

        public AssemblyExports ExtractExports(AssemblyDefinition assemblyDefinition, ExtractExportHandler exportFilter)
        {
            IList<TypeDefinition> typeDefinitionList = this.TraverseNestedTypes((ICollection<TypeDefinition>)assemblyDefinition.Modules.SelectMany<ModuleDefinition, TypeDefinition>((Func<ModuleDefinition, IEnumerable<TypeDefinition>>)(m => (IEnumerable<TypeDefinition>)m.Types)).ToList<TypeDefinition>());
            AssemblyExports result = new AssemblyExports() {
                InputValues = this.InputValues
            };
            foreach(TypeDefinition td in (IEnumerable<TypeDefinition>)typeDefinitionList)
            {
                List<ExportedMethod> exportMethods = new List<ExportedMethod>();
                foreach(MethodDefinition method in td.Methods)
                {
                    TypeDefinition typeRefCopy = td;
                    this.CheckForExportedMethods((Func<ExportedMethod>)(() => new ExportedMethod(this.GetExportedClass(typeRefCopy, result))), exportFilter, exportMethods, method);
                }
                foreach(ExportedMethod exportedMethod in exportMethods)
                {
                    this.GetExportedClass(td, result).Methods.Add(exportedMethod);
                }
            }
            result.Refresh();
            return result;
        }

        private ExportedClass GetExportedClass(TypeDefinition td, AssemblyExports result)
        {
            ExportedClass exportedClass;
            if(!result.ClassesByName.TryGetValue(td.FullName, out exportedClass))
            {
                TypeDefinition typeDefinition = td;
                while(!typeDefinition.HasGenericParameters && typeDefinition.IsNested)
                {
                    typeDefinition = typeDefinition.DeclaringType;
                }
                exportedClass = new ExportedClass(td.FullName, typeDefinition.HasGenericParameters);
                result.ClassesByName.Add(exportedClass.FullTypeName, exportedClass);
            }
            return exportedClass;
        }

        public AssemblyExports ExtractExports(string fileName, ExtractExportHandler exportFilter)
        {
            AssemblyDefinition def  = null;
            string currentDirectory = Directory.GetCurrentDirectory();

            try
            {
                Directory.SetCurrentDirectory(Path.GetDirectoryName(fileName));

                def = LoadAssembly(fileName);
                return ExtractExports(def, exportFilter);
            }
            finally
            {
                Directory.SetCurrentDirectory(currentDirectory);
                def?.Dispose(); // 0.10.x
            }
        }

        public AssemblyBinaryProperties GetAssemblyBinaryProperties(string assemblyFileName)
        {
            if(!File.Exists(assemblyFileName)) {
                return AssemblyBinaryProperties.GetEmpty();
            }

            AssemblyDefinition assemblyDefinition = LoadAssembly(assemblyFileName);
            ModuleDefinition mainModule = assemblyDefinition.MainModule;

            string keyFileName  = null;
            string keyContainer = null;

            foreach(CustomAttribute customAttribute in assemblyDefinition.CustomAttributes)
            {
                switch(customAttribute.Constructor.DeclaringType.FullName)
                {
                    case "System.Reflection.AssemblyKeyFileAttribute":
                    keyFileName = Convert.ToString(customAttribute.ConstructorArguments[0], CultureInfo.InvariantCulture);
                    break;

                    case "System.Reflection.AssemblyKeyNameAttribute":
                    keyContainer = Convert.ToString(customAttribute.ConstructorArguments[0], CultureInfo.InvariantCulture);
                    break;
                }

                if(!string.IsNullOrEmpty(keyFileName) && !string.IsNullOrEmpty(keyContainer)) {
                    break;
                }
            }

            try
            {
                return new AssemblyBinaryProperties
                (
                    mainModule.Attributes, 
                    mainModule.Architecture, 
                    assemblyDefinition.Name.HasPublicKey, 
                    keyFileName, 
                    keyContainer
                );
            }
            finally
            {
                assemblyDefinition.Dispose(); // 0.10.x
            }
        }

        public AssemblyDefinition LoadAssembly(string fileName)
        {
            return AssemblyDefinition.ReadAssembly
            (
                fileName, 
                new ReaderParameters(ReadingMode.Immediate) 
                { 
                    InMemory = true, 
                    ReadWrite = true, 
                    AssemblyResolver = new DisabledAssemblyResolver() 
                }
            );
        }

        public bool SafeExtractExports(string fileName, Stream stream)
        {
            AssemblyExports exports = this.ExtractExports(fileName);
            bool flag;
            if(exports.Count == 0)
            {
                flag = false;
            }
            else
            {
                new BinaryFormatter().Serialize(stream, (object)exports);
                flag = true;
            }
            return flag;
        }

        private void CheckForExportedMethods(Func<ExportedMethod> createExportMethod, ExtractExportHandler exportFilter, List<ExportedMethod> exportMethods, MethodDefinition mi)
        {
            IExportInfo exportInfo;
            if(!exportFilter(mi, out exportInfo)) {
                return;
            }

            ExportedMethod exportedMethod = createExportMethod();
            exportedMethod.IsStatic = mi.IsStatic;
            exportedMethod.IsGeneric = mi.HasGenericParameters;
            StringBuilder stringBuilder = new StringBuilder(mi.Name, mi.Name.Length + 5);
            if(mi.HasGenericParameters)
            {
                stringBuilder.Append("<");
                int num = 0;
                foreach(GenericParameter genericParameter in mi.GenericParameters)
                {
                    ++num;
                    if(num > 1)
                    {
                        stringBuilder.Append(",");
                    }
                    stringBuilder.Append(genericParameter.Name);
                }
                stringBuilder.Append(">");
            }

            exportedMethod.MemberName = stringBuilder.ToString();
            exportedMethod.AssignFrom(exportInfo, InputValues);

            if(String.IsNullOrEmpty(exportedMethod.ExportName)) {
                exportedMethod.ExportName = mi.Name;
            }

            exportMethods.Add(exportedMethod);
        }

        public bool TryExtractExport(ICustomAttributeProvider memberInfo, out IExportInfo exportInfo)
        {
            exportInfo = null;

            foreach(CustomAttribute customAttribute in memberInfo.CustomAttributes)
            {
                if(customAttribute.Constructor.DeclaringType.FullName == DllExportAttributeFullName)
                {
                    exportInfo      = new ExportInfo();
                    IExportInfo ei  = exportInfo;
                    //((IExportInfoEx)exportInfo).CustomAttr = customAttribute;

                    int index = -1;
                    foreach(CustomAttributeArgument constructorArgument in customAttribute.ConstructorArguments)
                    {
                        ++index;
                        ParameterDefinition parameterDefinition = customAttribute.Constructor.Parameters[index];
                        ExportAssemblyInspector.SetParamValue(ei, parameterDefinition.ParameterType.FullName, constructorArgument.Value);
                    }
                    using(var enumerator = customAttribute.Fields.Concat<CustomAttributeNamedArgument>((IEnumerable<CustomAttributeNamedArgument>)customAttribute.Properties).Select(arg => new {
                        Name = arg.Name,
                        Value = arg.Argument.Value
                    }).Distinct().GetEnumerator())
                    {
                        while(enumerator.MoveNext())
                        {
                            var current = enumerator.Current;
                            ExportAssemblyInspector.SetFieldValue(ei, current.Name, current.Value);
                        }
                        break;
                    }
                }
            }
            return exportInfo != null;
        }

        private static void SetParamValue(IExportInfo ei, string name, object value)
        {
            if(name == null)
            {
                return;
            }
            if(name != "System.String")
            {
                if(!(name == "System.Runtime.InteropServices.CallingConvention"))
                {
                    return;
                }
                ei.CallingConvention = (CallingConvention)value;
            }
            else
            {
                ei.ExportName = value?.ToString();
            }
        }

        private static void SetFieldValue(IExportInfo ei, string name, object value)
        {
            if(string.IsNullOrEmpty(name)) return;

            string upperInvariant = name.ToUpperInvariant();

            if(upperInvariant != "NAME" && upperInvariant != "EXPORTNAME")
            {
                if(!(upperInvariant == "CALLINGCONVENTION") && !(upperInvariant == "CONVENTION"))
                {
                    return;
                }
                ei.CallingConvention = (CallingConvention)value;
            }
            else
            {
                ei.ExportName = value?.ToString();
            }
        }
    }
}
