using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UkrainianStemmer.Services;

namespace UkrainianStemmer.StemmerLanguages
{
    public class StemmerOperations
    {

        //    // current string
        protected StringBuilder Current;

        protected int Cursor;
        protected int Limit;
        protected int LimitBackward;
        protected int Bra;
        protected int Ket;



        protected StemmerOperations()
        {
            Current = new StringBuilder();
            SetCurrent("");
        }

        //    /**
        //     * Set the current string.
        //     */
        protected void SetCurrent(string value)
        {
            //           current.replace(0, current.length(), value);
            //current=current.Replace(current.ToString(), value);
            //current = StringBufferReplace(0, current.Length, current, value);
            //current = StringBufferReplace(0, value.Length, current, value);
            Current.Remove(0, Current.Length);
            Current.Append(value);
            Cursor = 0;
            Limit = Current.Length;
            LimitBackward = 0;
            Bra = Cursor;
            Ket = Limit;
        }

        //    /**
        //     * Get the current string.
        //     */
        protected string GetCurrent()
        {
            string result = Current.ToString();
            // Make a new StringBuffer.  If we reuse the old one, and a user of
            // the library keeps a reference to the buffer returned (for example,
            // by converting it to a String in a way which doesn't force a copy),
            // the buffer size will not decrease, and we will risk wasting a large
            // amount of memory.
            // Thanks to Wolfram Esser for spotting this problem.
            //current = new  StringBuilder();
            return result;
        }

        protected void copy_from(StemmerOperations other)
        {
            Current = other.Current;
            Cursor = other.Cursor;
            Limit = other.Limit;
            LimitBackward = other.LimitBackward;
            Bra = other.Bra;
            Ket = other.Ket;
        }

        protected bool in_grouping(char[] s, int min, int max)
        {
            if (Cursor >= Limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) Current[Cursor];
            if (ch > max || ch < min) return false;
            //           ch -= min;
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0) return false;
            Cursor++;
            return true;
        }

        protected bool in_grouping_b(char[] s, int min, int max)
        {
            if (Cursor <= LimitBackward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) Current[Cursor - 1];
            if (ch > max || ch < min) return false;
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0) return false;
            Cursor--;
            return true;
        }

        protected bool out_grouping(char[] s, int min, int max)
        {
            if (Cursor >= Limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) Current[Cursor];
            if (ch > max || ch < min)
            {
                Cursor++;
                return true;
            }
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0)
            {
                Cursor++;
                return true;
            }
            return false;
        }

        protected bool out_grouping_b(char[] s, int min, int max)
        {
            if (Cursor <= LimitBackward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) Current[Cursor - 1];
            if (ch > max || ch < min)
            {
                Cursor--;
                return true;
            }
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0)
            {
                Cursor--;
                return true;
            }
            return false;
        }

        protected bool in_range(int min, int max)
        {
            if (Cursor >= Limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) Current[Cursor];
            if (ch > max || ch < min) return false;
            Cursor++;
            return true;
        }

        protected bool in_range_b(int min, int max)
        {
            if (Cursor <= LimitBackward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) Current[Cursor - 1];
            if (ch > max || ch < min) return false;
            Cursor--;
            return true;
        }

        protected bool out_range(int min, int max)
        {
            if (Cursor >= Limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) Current[Cursor];
            if (!(ch > max || ch < min)) return false;
            Cursor++;
            return true;
        }

        protected bool out_range_b(int min, int max)
        {
            if (Cursor <= LimitBackward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) Current[Cursor - 1];
            if (!(ch > max || ch < min)) return false;
            Cursor--;
            return true;
        }

        protected bool eq_s(int sSize, string s)
        {
            if (Limit - Cursor < sSize) return false;
            int i;
            for (i = 0; i != sSize; i++)
            {
                if (Current[Cursor + i] != s[i]) return false;
                //               if (current[cursor + i] != s[i]) return false;
            }
            Cursor += sSize;
            return true;
        }

        protected bool eq_s_b(int sSize, string s)
        {
            if (Cursor - LimitBackward < sSize) return false;
            int i;
            for (i = 0; i != sSize; i++)
            {
                //               if (current.charAt(cursor - s_size + i) != s.charAt(i)) return false;
                if (Current[Cursor - sSize + i] != s[i]) return false;
            }
            Cursor -= sSize;
            return true;
        }

        protected bool eq_v(StringBuilder s)
        {
            return eq_s(s.Length, s.ToString());
        }

        protected bool eq_v_b(StringBuilder s)
        {
            return eq_s_b(s.Length, s.ToString());
        }


        internal int find_among(Among[] v, int vSize)
        {
            int i = 0;
            int j = vSize;

            int c = Cursor;
            int l = Limit;

            int commonI = 0;
            int commonJ = 0;

            bool firstKeyInspected = false;
            while (true)
            {
                int k = i + ((j - i) >> 1);
                int diff = 0;
                int common = commonI < commonJ ? commonI : commonJ; // smaller
                Among w = v[k];
                int i2;

                for (i2 = common; i2 < w.s_size; i2++)
                {
                    if (c + common == l)
                    {
                        diff = -1;
                        break;
                    }
                    diff = Current[c + common] - w.s[i2];
                    if (diff != 0) break;
                    common++;
                }
                if (diff < 0)
                {
                    j = k;
                    commonJ = common;
                }
                else
                {
                    i = k;
                    commonI = common;
                }
                if (j - i <= 1)
                {
                    if (i > 0) break; // v->s has been inspected
                    if (j == i) break; // only one item in v
                    // - but now we need to go round once more to get
                    // v->s inspected. This looks messy, but is actually
                    // the optimal approach.
                    if (firstKeyInspected) break;
                    firstKeyInspected = true;
                }
            }
            while (true)
            {
                Among w = v[i];
                if (commonI >= w.s_size)
                {
                    Cursor = c + w.s_size;
                    if (w.method == null) return w.result;
                    //bool res;
                    //try
                    //{
                    //    Object resobj = w.method.invoke(w.methodobject,new Object[0]);
                    //    res = resobj.toString().equals("true");
                    //}
                    //catch (InvocationTargetException e)
                    //{
                    //    res = false;
                    //    // FIXME - debug message
                    //}
                    //catch (IllegalAccessException e)
                    //{
                    //    res = false;
                    //// FIXME - debug message
                    //}
                    //cursor = c + w.s_size;
                    //if (res) return w.result;
                }
                i = w.substring_i;
                if (i < 0) return 0;
            }
        }

        //    // find_among_b is for backwards processing. Same comments apply

        internal int find_among_b(Among[] v, int vSize)
        {
            int i = 0;
            int j = vSize;
            int c = Cursor;
            int lb = LimitBackward;
            int commonI = 0;
            int commonJ = 0;
            bool firstKeyInspected = false;
            while (true)
            {
                int k = i + ((j - i) >> 1);
                int diff = 0;
                int common = commonI < commonJ ? commonI : commonJ;
                Among w = v[k];
                int i2;
                for (i2 = w.s_size - 1 - common; i2 >= 0; i2--)
                {
                    if (c - common == lb)
                    {
                        diff = -1;
                        break;
                    }
                    //                   diff = current.charAt(c - 1 - common) - w.s[i2];
                    diff = Current[c - 1 - common] - w.s[i2];
                    if (diff != 0) break;
                    common++;
                }
                if (diff < 0)
                {
                    j = k;
                    commonJ = common;
                }
                else
                {
                    i = k;
                    commonI = common;
                }
                if (j - i <= 1)
                {
                    if (i > 0) break;
                    if (j == i) break;
                    if (firstKeyInspected) break;
                    firstKeyInspected = true;
                }
            }
            while (true)
            {
                Among w = v[i];
                if (commonI >= w.s_size)
                {
                    Cursor = c - w.s_size;
                    if (w.method == null) return w.result;
                    //boolean res;
                    //try 
                    //{
                    //    Object resobj = w.method.invoke(w.methodobject,
                    //        new Object[0]);
                    //    res = resobj.toString().equals("true");
                    // } 
                    //catch (InvocationTargetException e) 
                    //{
                    //    res = false;
                    //    // FIXME - debug message
                    // } 
                    //catch (IllegalAccessException e) 
                    //{
                    //    res = false;
                    //    // FIXME - debug message
                    // }
                    //cursor = c - w.s_size;
                    //if (res) return w.result;
                }
                i = w.substring_i;
                if (i < 0) return 0;
            }
        }

        //    /* to replace chars between c_bra and c_ket in current by the
        //     * chars in s.
        //     */
        protected int replace_s(int cBra, int cKet, string s)
        {
            int adjustment = s.Length - (cKet - cBra);
            //           current.replace(c_bra, c_ket, s);
            Current = StringBufferReplace(cBra, cKet, Current, s);
            Limit += adjustment;
            if (Cursor >= cKet) Cursor += adjustment;
            else if (Cursor > cBra) Cursor = cBra;
            return adjustment;
        }

        private StringBuilder StringBufferReplace(int start, int end, StringBuilder s, string s1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < start; i++)
            {
                sb.Insert(sb.Length, s[i]);
            }
            //           for (int i = 1; i < end - start + 1; i++)
            //           {
            sb.Insert(sb.Length, s1);
            //           }
            for (int i = end; i < s.Length; i++)
            {
                sb.Insert(sb.Length, s[i]);
            }

            return sb;
            //string temp = s.ToString();
            //temp = temp.Substring(start - 1, end - start + 1);
            //s = s.Replace(temp, s1, start - 1, end - start + 1);
            //return s;
        }

        protected void slice_check()
        {
            if (Bra < 0 ||
                Bra > Ket ||
                Ket > Limit ||
                Limit > Current.Length) // this line could be removed
            {
                //System.err.println("faulty slice operation");
                // FIXME: report error somehow.
                /*
                    fprintf(stderr, "faulty slice operation:\n");
                    debug(z, -1, 0);
                    exit(1);
                    */
            }
        }

        protected void slice_from(string s)
        {
            slice_check();
            replace_s(Bra, Ket, s);
        }

        protected void slice_from(StringBuilder s)
        {
            slice_from(s.ToString());
        }

        protected void slice_del()
        {
            slice_from("");
        }

        protected void Insert(int cBra, int cKet, string s)
        {
            int adjustment = replace_s(cBra, cKet, s);
            if (cBra <= Bra) Bra += adjustment;
            if (cBra <= Ket) Ket += adjustment;
        }

        protected void Insert(int cBra, int cKet, StringBuilder s)
        {
            Insert(cBra, cKet, s.ToString());
        }

        //    /* Copy the slice into the supplied StringBuffer */
        protected StringBuilder slice_to(StringBuilder s)
        {
            slice_check();
            int len = Ket - Bra;
            //           s.replace(0, s.length(), current.substring(bra, ket));
            //           int lengh = string.IsNullOrEmpty(s.ToString())!= true ? s.Length : 0;
            //           if (ket == current.Length) ket--;
            //string ss = current.ToString().Substring(bra, len);
            //StringBufferReplace(0, s.Length, s, ss);
            //return s;
            return StringBufferReplace(0, s.Length, s, Current.ToString().Substring(Bra, len));
            //           return StringBufferReplace(0, lengh, s, current.ToString().Substring(bra, ket));
            //           return s;
        }

        //    /* Copy the slice into the supplied StringBuilder */
        //protected StringBuilder slice_to(StringBuilder s)
        //{
        //    slice_check();
        //    int len = ket - bra;
        //    s.replace(0, s.length(), current.substring(bra, ket));
        //    return s;
        //}

        protected StringBuilder assign_to(StringBuilder s)
        {
            //s.replace(0, s.length(), current.substring(0, limit));
            //return s;
            return StringBufferReplace(0, s.Length, s, Current.ToString().Substring(0, Limit));
        }
    }
}
