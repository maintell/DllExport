﻿/*!
 * Copyright (c) Robert Giesecke
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;

namespace net.r_eg.DllExport.Problems
{
    public interface IProblem
    {
        /// <summary>
        /// Human-readable message of problem.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Short information about problem.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Error code if known.
        /// </summary>
        Int64? Code { get; }

        /// <summary>
        /// Human-readable message of how to solve it.
        /// </summary>
        string HowToSolve { get; }

        /// <summary>
        /// Is it possible to solve it automatically.
        /// </summary>
        bool AutoFix { get; }

        /// <summary>
        /// Trying to solve it automatically.
        /// </summary>
        /// <returns>true if problem has been solved.</returns>
        bool TryToSolve();
    }
}
