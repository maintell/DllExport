﻿/*!
 * Copyright (c) Robert Giesecke
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

namespace net.r_eg.DllExport.Parsing
{
    public enum ParserState
    {
        Normal,

        ClassDeclaration,

        Class,

        ClassExtern,

        ClassExternForwarder,

        DeleteExportDependency,

        MethodDeclaration,

        MethodProperties,

        Method,

        DeleteExportAttribute,

        AssemblyDeclaration,

        Assembly,

        AssemblyExtern,
    }
}
