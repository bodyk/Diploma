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
        protected StringBuilder current;

        protected int cursor;
        protected int limit;
        protected int limit_backward;
        protected int bra;
        protected int ket;



        protected StemmerOperations()
        {
            current = new StringBuilder();
            setCurrent("");
        }

        //    /**
        //     * Set the current string.
        //     */
        protected void setCurrent(string value)
        {
            //           current.replace(0, current.length(), value);
            //current=current.Replace(current.ToString(), value);
            //current = StringBufferReplace(0, current.Length, current, value);
            //current = StringBufferReplace(0, value.Length, current, value);
            current.Remove(0, current.Length);
            current.Append(value);
            cursor = 0;
            limit = current.Length;
            limit_backward = 0;
            bra = cursor;
            ket = limit;
        }

        //    /**
        //     * Get the current string.
        //     */
        protected string getCurrent()
        {
            string result = current.ToString();
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
            current = other.current;
            cursor = other.cursor;
            limit = other.limit;
            limit_backward = other.limit_backward;
            bra = other.bra;
            ket = other.ket;
        }

        protected bool in_grouping(char[] s, int min, int max)
        {
            if (cursor >= limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) current[cursor];
            if (ch > max || ch < min) return false;
            //           ch -= min;
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0) return false;
            cursor++;
            return true;
        }

        protected bool in_grouping_b(char[] s, int min, int max)
        {
            if (cursor <= limit_backward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) current[cursor - 1];
            if (ch > max || ch < min) return false;
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0) return false;
            cursor--;
            return true;
        }

        protected bool out_grouping(char[] s, int min, int max)
        {
            if (cursor >= limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) current[cursor];
            if (ch > max || ch < min)
            {
                cursor++;
                return true;
            }
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0)
            {
                cursor++;
                return true;
            }
            return false;
        }

        protected bool out_grouping_b(char[] s, int min, int max)
        {
            if (cursor <= limit_backward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) current[cursor - 1];
            if (ch > max || ch < min)
            {
                cursor--;
                return true;
            }
            ch -= min;
            if ((s[ch >> 3] & (0X1 << (ch & 0X7))) == 0)
            {
                cursor--;
                return true;
            }
            return false;
        }

        protected bool in_range(int min, int max)
        {
            if (cursor >= limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) current[cursor];
            if (ch > max || ch < min) return false;
            cursor++;
            return true;
        }

        protected bool in_range_b(int min, int max)
        {
            if (cursor <= limit_backward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) current[cursor - 1];
            if (ch > max || ch < min) return false;
            cursor--;
            return true;
        }

        protected bool out_range(int min, int max)
        {
            if (cursor >= limit) return false;
            //           char ch = current.charAt(cursor);
            int ch = (int) current[cursor];
            if (!(ch > max || ch < min)) return false;
            cursor++;
            return true;
        }

        protected bool out_range_b(int min, int max)
        {
            if (cursor <= limit_backward) return false;
            //           char ch = current.charAt(cursor - 1);
            int ch = (int) current[cursor - 1];
            if (!(ch > max || ch < min)) return false;
            cursor--;
            return true;
        }

        protected bool eq_s(int s_size, string s)
        {
            if (limit - cursor < s_size) return false;
            int i;
            for (i = 0; i != s_size; i++)
            {
                if (current[cursor + i] != s[i]) return false;
                //               if (current[cursor + i] != s[i]) return false;
            }
            cursor += s_size;
            return true;
        }

        protected bool eq_s_b(int s_size, string s)
        {
            if (cursor - limit_backward < s_size) return false;
            int i;
            for (i = 0; i != s_size; i++)
            {
                //               if (current.charAt(cursor - s_size + i) != s.charAt(i)) return false;
                if (current[cursor - s_size + i] != s[i]) return false;
            }
            cursor -= s_size;
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


        internal int find_among(Among[] v, int v_size)
        {
            int i = 0;
            int j = v_size;

            int c = cursor;
            int l = limit;

            int common_i = 0;
            int common_j = 0;

            bool first_key_inspected = false;
            while (true)
            {
                int k = i + ((j - i) >> 1);
                int diff = 0;
                int common = common_i < common_j ? common_i : common_j; // smaller
                Among w = v[k];
                int i2;

                for (i2 = common; i2 < w.s_size; i2++)
                {
                    if (c + common == l)
                    {
                        diff = -1;
                        break;
                    }
                    diff = current[c + common] - w.s[i2];
                    if (diff != 0) break;
                    common++;
                }
                if (diff < 0)
                {
                    j = k;
                    common_j = common;
                }
                else
                {
                    i = k;
                    common_i = common;
                }
                if (j - i <= 1)
                {
                    if (i > 0) break; // v->s has been inspected
                    if (j == i) break; // only one item in v
                    // - but now we need to go round once more to get
                    // v->s inspected. This looks messy, but is actually
                    // the optimal approach.
                    if (first_key_inspected) break;
                    first_key_inspected = true;
                }
            }
            while (true)
            {
                Among w = v[i];
                if (common_i >= w.s_size)
                {
                    cursor = c + w.s_size;
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

        internal int find_among_b(Among[] v, int v_size)
        {
            int i = 0;
            int j = v_size;
            int c = cursor;
            int lb = limit_backward;
            int common_i = 0;
            int common_j = 0;
            bool first_key_inspected = false;
            while (true)
            {
                int k = i + ((j - i) >> 1);
                int diff = 0;
                int common = common_i < common_j ? common_i : common_j;
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
                    diff = current[c - 1 - common] - w.s[i2];
                    if (diff != 0) break;
                    common++;
                }
                if (diff < 0)
                {
                    j = k;
                    common_j = common;
                }
                else
                {
                    i = k;
                    common_i = common;
                }
                if (j - i <= 1)
                {
                    if (i > 0) break;
                    if (j == i) break;
                    if (first_key_inspected) break;
                    first_key_inspected = true;
                }
            }
            while (true)
            {
                Among w = v[i];
                if (common_i >= w.s_size)
                {
                    cursor = c - w.s_size;
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
        protected int replace_s(int c_bra, int c_ket, string s)
        {
            int adjustment = s.Length - (c_ket - c_bra);
            //           current.replace(c_bra, c_ket, s);
            current = StringBufferReplace(c_bra, c_ket, current, s);
            limit += adjustment;
            if (cursor >= c_ket) cursor += adjustment;
            else if (cursor > c_bra) cursor = c_bra;
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
            if (bra < 0 ||
                bra > ket ||
                ket > limit ||
                limit > current.Length) // this line could be removed
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
            replace_s(bra, ket, s);
        }

        protected void slice_from(StringBuilder s)
        {
            slice_from(s.ToString());
        }

        protected void slice_del()
        {
            slice_from("");
        }

        protected void insert(int c_bra, int c_ket, string s)
        {
            int adjustment = replace_s(c_bra, c_ket, s);
            if (c_bra <= bra) bra += adjustment;
            if (c_bra <= ket) ket += adjustment;
        }

        protected void insert(int c_bra, int c_ket, StringBuilder s)
        {
            insert(c_bra, c_ket, s.ToString());
        }

        //    /* Copy the slice into the supplied StringBuffer */
        protected StringBuilder slice_to(StringBuilder s)
        {
            slice_check();
            int len = ket - bra;
            //           s.replace(0, s.length(), current.substring(bra, ket));
            //           int lengh = string.IsNullOrEmpty(s.ToString())!= true ? s.Length : 0;
            //           if (ket == current.Length) ket--;
            //string ss = current.ToString().Substring(bra, len);
            //StringBufferReplace(0, s.Length, s, ss);
            //return s;
            return StringBufferReplace(0, s.Length, s, current.ToString().Substring(bra, len));
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
            return StringBufferReplace(0, s.Length, s, current.ToString().Substring(0, limit));
        }
    }
}
