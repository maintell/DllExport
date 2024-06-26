﻿/*!
 * Copyright (c) Robert Giesecke
 * Copyright (c) Denis Kuzmin <x-3F@outlook.com> github/3F
 * Copyright (c) DllExport contributors https://github.com/3F/DllExport/graphs/contributors
 * Licensed under the MIT License (MIT).
 * See accompanying LICENSE.txt file or visit https://github.com/3F/DllExport
*/

using System;
using System.Collections.Generic;

namespace RGiesecke.DllExport
{
    internal static class Null
    {
        public static int NullSafeCount<T>(this ICollection<T> items)
        {
            if(items != null)
            {
                return items.Count;
            }
            return 0;
        }

        public static string NullSafeTrim(this string input, params char[] trimChars)
        {
            if(input != null)
            {
                return input.Trim(trimChars);
            }
            return (string)null;
        }

        public static string NullSafeToString(this object input)
        {
            if(input != null)
            {
                return input.ToString();
            }
            return (string)null;
        }

        public static string NullSafeToLowerInvariant(this string input)
        {
            if(input != null)
            {
                return input.ToLowerInvariant();
            }
            return (string)null;
        }

        public static string NullSafeToUpperInvariant(this string input)
        {
            if(input != null)
            {
                return input.ToUpperInvariant();
            }
            return (string)null;
        }

        public static string NullSafeTrimStart(this string input, params char[] trimChars)
        {
            if(input != null)
            {
                return input.TrimStart(trimChars);
            }
            return (string)null;
        }

        public static string NullIfEmpty(this string input)
        {
            if(!string.IsNullOrEmpty(input))
            {
                return input;
            }
            return (string)null;
        }

        public static string NullSafeTrimEnd(this string input, params char[] trimChars)
        {
            if(input != null)
            {
                return input.TrimEnd(trimChars);
            }
            return (string)null;
        }

        public static T IfNull<T>(this T input, T replacement)
        {
            if((object)input != null)
            {
                return input;
            }
            return replacement;
        }

        public static string IfEmpty(this string input, string replacement)
        {
            if(!string.IsNullOrEmpty(input))
            {
                return input;
            }
            return replacement;
        }

        public static TValue NullSafeCall<T, TValue>(this T input, Func<T, TValue> method)
        {
            if((object)input != null)
            {
                return method(input);
            }
            return default(TValue);
        }

        public static TValue NullSafeCall<T, TValue>(this T input, Func<TValue> method)
        {
            if((object)input != null)
            {
                return method();
            }
            return default(TValue);
        }
    }
}
