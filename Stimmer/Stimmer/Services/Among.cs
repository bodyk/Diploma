﻿using System;
using System.Reflection;

namespace Stimmer.Services
{
    public class Among
    {
        public Among(String s, int substring_i, int result)
        {
            this.s = s.ToCharArray();
            this.substring_i = substring_i;
            this.result = result;
            this.method = null;
        }

        public Among(String s, int substring_i, int result, String methodname, SnowballProgram programclass)
        {
            this.s = s.ToCharArray();
            this.substring_i = substring_i;
            this.result = result;
            try
            {
                this.method = programclass.getDeclaredMethod(methodname);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public readonly char[] s; /* search string */
        public readonly int substring_i; /* index to longest matching substring */
        public readonly int result; /* result of the lookup */
        public readonly MethodInfo method; /* method to use if substring matches */
    }
}
