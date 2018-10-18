using System;
using System.Collections.Generic;
using UkrainianStemmer.Interfaces;
using UkrainianStemmer.Services;

namespace UkrainianStemmer.StemmerLanguages
{
    public class UkrainianStemmer : StemmerOperations, IStemmer
    {
        static long serialVersionUID = 2016072500L;

        // Інфінітив
        // https://uk.wikipedia.org/wiki/%D0%86%D0%BD%D1%84%D1%96%D0%BD%D1%96%D1%82%D0%B8%D0%B2
        private readonly List<Among> a_infinitive = new List<Among>
        {
            new Among("\u0430\u0434\u0436\u0435", -1, -1), // адже
            new Among("\u0430\u0442\u043E\u043C", -1, -1), // атом
            new Among("\u0432\u0456\u0441\u044C", -1, -1), // вісь
            new Among("\u0434\u0435\u0441\u044C", -1, -1), // десь
            new Among("\u0437\u0434\u043E\u0440\u043E\u0432'\u044F", -1, 1), // здоров'я
            new Among("\u043A\u0440\u043E\u043A", -1, -1), // крок
            new Among("\u043A\u0440\u0456\u043C", -1, -1) // крім
        };

        // Прикметник
        //https://uk.wikipedia.org/wiki/%D0%9F%D1%80%D0%B8%D0%BA%D0%BC%D0%B5%D1%82%D0%BD%D0%B8%D0%BA
        private readonly List<Among> a_adjective = new List<Among>
        {
            new Among("\u043E\u0432\u0430", -1, 1), // ова
            new Among("\u043E\u0432\u0435", -1, 1), // ове
            new Among("\u0438\u043C\u0438", -1, 1), // ими
            new Among("\u0435\u0439", -1, 1), // ей
            new Among("\u0438\u0439", -1, 1), // ий
            new Among("\u043E\u0432\u0438\u0439", 4, 1), // овий
            new Among("\u0456\u0439", -1, 1), // ій
            new Among("\u043E\u0432\u0456\u0439", 6, 1), // овій
            new Among("\u0435\u043C", -1, 1), // ем
            new Among("\u0438\u043C", -1, 1), // им
            new Among("\u043E\u0432\u0438\u043C", 9, 1), // овим
            new Among("\u043E\u043C", -1, 1), // ом
            new Among("\u0456\u043C", -1, 1), // ім
            new Among("\u043E\u0432\u043E", -1, 1), // ово
            new Among("\u043E\u0433\u043E", -1, 1), // ого
            new Among("\u043E\u0432\u043E\u0433\u043E", 14, 1), // ового
            new Among("\u0435\u043C\u0443", -1, 1), // ему
            new Among("\u043E\u043C\u0443", -1, 1), // ому
            new Among("\u043E\u0432\u043E\u043C\u0443", 17, 1), // овому
            new Among("\u0438\u0445", -1, 1), // их
            new Among("\u043E\u0432\u0438\u0445", 19, 1), // ових
            new Among("\u0456\u0445", -1, 1), // іх
            new Among("\u0435\u044E", -1, 1), // ею
            new Among("\u043E\u044E", -1, 1), // ою
            new Among("\u043E\u0432\u043E\u044E", 23, 1), // овою
            new Among("\u0443\u044E", -1, 1), // ую
            new Among("\u044E\u044E", -1, 1), // юю
            new Among("\u0430\u044F", -1, 1), // ая
            new Among("\u043E\u0457", -1, 1), // ої
            new Among("\u043E\u0432\u043E\u0457", 28, 1) // ової
        };

        // Постфікс
        // https://uk.wikipedia.org/wiki/%D0%9F%D0%BE%D1%81%D1%82%D1%84%D1%96%D0%BA%D1%81
        private readonly List<Among> a_postfix = new List<Among>
        {
            new Among("\u0441\u044C", -1, 1), // сь
            new Among("\u0441\u044F", -1, 1) // ся
        };

        // Дієслово
        // https://uk.wikipedia.org/wiki/%D0%94%D1%96%D1%94%D1%81%D0%BB%D0%BE%D0%B2%D0%BE
        private readonly List<Among> a_verb = new List<Among>
        {
            new Among("\u0430\u043B\u0430", -1, 2), // ала
            new Among("\u0443\u0432\u0430\u043B\u0430", 0, 2), // увала
            new Among("\u0438\u043B\u0430", -1, 2), // ила
            new Among("\u0448\u043B\u0430", -1, 1), // шла
            new Among("\u0456\u043B\u0430", -1, 2), // іла
            new Among("\u0435\u043D\u0430", -1, 2), // ена
            new Among("\u0438\u0442\u0430", -1, 2), // ита
            new Among("\u0430\u0432", -1, 2), // ав
            new Among("\u0443\u0432\u0430\u0432", 7, 2), // ував
            new Among("\u0438\u0432", -1, 2), // ив
            new Among("\u0448\u043E\u0432", -1, 1), // шов
            new Among("\u0443\u0439\u0442\u0435", -1, 2), // уйте
            new Among("\u0430\u043B\u0438", -1, 2), // али
            new Among("\u0443\u0432\u0430\u043B\u0438", 12, 2), // ували
            new Among("\u0438\u043B\u0438", -1, 2), // или
            new Among("\u0448\u043B\u0438", -1, 1), // шли
            new Among("\u0430\u043D\u0438\u043C\u0438", -1, 2), // аними
            new Among("\u0443\u0432\u0430\u0442\u0438", -1, 2), // увати
            new Among("\u0438\u0432\u0448\u0438", -1, 2), // ивши
            new Among("\u0443\u0439", -1, 2), // уй
            new Among("\u0430\u043B\u043E", -1, 2), // ало
            new Among("\u0443\u0432\u0430\u043B\u043E", 20, 2), // увало
            new Among("\u0438\u043B\u043E", -1, 2), // ило
            new Among("\u0448\u043B\u043E", -1, 1), // шло
            new Among("\u0456\u043B\u043E", -1, 2), // іло
            new Among("\u0435\u043D\u043E", -1, 2), // ено
            new Among("\u0430\u043D\u0438\u0445", -1, 2), // аних
            new Among("\u0438\u0442\u044C", -1, 2), // ить
            new Among("\u0430\u044E\u0442\u044C", -1, 2), // ають
            new Among("\u0443\u044E\u0442\u044C", -1, 2), // ують
            new Among("\u0456\u044E\u0442\u044C", -1, 2), // іють
            new Among("\u0456\u0442\u044C", -1, 2), // іть
            new Among("\u0443\u0432\u0430\u043D\u043D\u044F", -1, 2), // ування
            new Among("\u0430\u0454", -1, 2), // ає
            new Among("\u0438\u0454", -1, 2), // иє
            new Among("\u0443\u0454", -1, 2), // ує
            new Among("\u044E\u0454", -1, 2), // ює
            new Among("\u044F\u0454", -1, 2), // яє
            new Among("\u0456\u0454", -1, 2), // іє
            new Among("\u0438\u043B\u0456", -1, 2), // илі
            new Among("\u0430\u043D\u0456", -1, 2) // ані
        };

        // Іменник
        // https://uk.wikipedia.org/wiki/%D0%86%D0%BC%D0%B5%D0%BD%D0%BD%D0%B8%D0%BA
        private readonly List<Among> a_noun = new List<Among>
        {
            new Among("\u0430", -1, 3), // а
            new Among("\u044F\u0442\u0430", 0, 1), // ята
            new Among("\u043E\u0432", -1, 3), // ов
            new Among("\u0456\u0432", -1, 3), // ів
            new Among("\u0457\u0432", -1, 3), // їв
            new Among("\u043E\u0457\u0432", 4, 3), // оїв
            new Among("\u0435", -1, 3), // е
            new Among("\u0438", -1, 3), // и
            new Among("\u0430\u043C\u0438", 7, 3), // ами
            new Among("\u044F\u0442\u0430\u043C\u0438", 8, 1), // ятами
            new Among("\u044F\u043C\u0438", 7, 3), // ями
            new Among("\u0456\u044F\u043C\u0438", 10, 3), // іями
            new Among("\u0439", -1, 3), // й
            new Among("\u0435\u0439", 12, 3), // ей
            new Among("\u043E\u0439", 12, 3), // ой
            new Among("\u0456\u0439", 12, 3), // ій
            new Among("\u043E\u043A", -1, 2), // ок
            new Among("\u0438\u043B", -1, 3), // ил
            new Among("\u0456\u043B", -1, 3), // іл
            new Among("\u0430\u043C", -1, 3), // ам
            new Among("\u044F\u0442\u0430\u043C", 19, 1), // ятам
            new Among("\u0435\u043C", -1, 3), // ем
            new Among("\u043E\u043C", -1, 3), // ом
            new Among("\u044F\u043C", -1, 3), // ям
            new Among("\u0456\u044F\u043C", 23, 3), // іям
            new Among("\u043E\u0454\u043C", -1, 3), // оєм
            new Among("\u0435\u043D", -1, 3), // ен
            new Among("\u043E", -1, 3), // о
            new Among("\u044F\u0442", -1, 3), // ят
            new Among("\u0443", -1, 3), // у
            new Among("\u0430\u0445", -1, 3), // ах
            new Among("\u044F\u0445", -1, 3), // ях
            new Among("\u043E\u044F\u0445", 31, 3), // оях
            new Among("\u0456\u044F\u0445", 31, 3), // іях
            new Among("\u044C", -1, 3), // ь
            new Among("\u044E", -1, 3), // ю
            new Among("\u0443\u044E", 35, 3), // ую
            new Among("\u0456\u0454\u044E", 35, 3), // ією
            new Among("\u0456\u044E", 35, 3), // ію
            new Among("\u044F", -1, 3), // я
            new Among("\u043E\u044F", 39, 3), // оя
            new Among("\u0456\u044F", 39, 3), // ія
            new Among("\u0456", -1, 3), // і
            new Among("\u043E\u0432\u0456", 42, 3), // ові
            new Among("\u0435\u0457", -1, 3), // еї
            new Among("\u0456\u0457", -1, 3) // ії
        };

        private readonly List<Among> a_5 = new List<Among>
        {
            new Among("'", -1, 3),
            new Among("\u0441\u044C\u043A", -1, 3), // ськ
            new Among("\u0456\u0439\u0441\u044C\u043A", 1, 3), // ійськ
            new Among("\u043D", -1, 1), // н
            new Among("\u0430\u043D", 3, 3), // ан
            new Among("\u0435\u043D", 3, 3), // ен
            new Among("\u0456\u0447\u043D", 3, 3), // ічн
            new Among("\u044C\u043D", 3, 3), // ьн
            new Among("\u0442", -1, 2), // т
            new Among("\u0438\u0442", 8, 3), // ит
            new Among("\u043E\u0441\u0442", 8, 4), // ост
            new Among("\u044E\u044E\u0442", 8, 3), // юют
            new Among("\u0430\u0454\u0442", 8, 3), // аєт
            new Among("\u0443\u0454\u0442", 8, 3), // уєт
            new Among("\u044E\u0454\u0442", 8, 3), // юєт
            new Among("\u044F\u0454\u0442", 8, 3), // яєт
            new Among("\u044C", -1, 3) // ь
        };

        private bool r_exception1()
        {
            int among_var;
            // (, line 50
            // [, line 52
            bra = cursor;
            // substring, line 52
            among_var = find_among(a_infinitive);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 52
            ket = cursor;
            // atlimit, line 52
            if (cursor < limit)
            {
                return false;
            }
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 54
                    // <-, line 54
                    slice_from("\u0437\u0434\u043E\u0440"); //здор
                    break;
            }
            return true;
        }

        private bool r_adjective()
        {
            int among_var;
            // (, line 70
            // [, line 72
            ket = cursor;
            // substring, line 72
            among_var = find_among_b(a_adjective);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 72
            bra = cursor;
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 82
                    // delete, line 82
                    slice_del();
                    break;
            }
            return true;
        }

        private bool r_postfix()
        {
            int among_var;
            // (, line 87
            // [, line 88
            ket = cursor;
            // substring, line 88
            among_var = find_among_b(a_postfix);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 88
            bra = cursor;
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 91
                    // delete, line 91
                    slice_del();
                    break;
            }
            return true;
        }

        private bool r_verb()
        {
            int among_var;
            // (, line 95
            // [, line 96
            ket = cursor;
            // substring, line 96
            among_var = find_among_b(a_verb);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 96
            bra = cursor;
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 97
                    // <-, line 97
                    slice_from("\u0442"); // т
                    break;
                case 2:
                    // (, line 108
                    // delete, line 108
                    slice_del();
                    break;
            }
            return true;
        }

        private bool r_noun()
        {
            int among_var;
            // (, line 112
            // [, line 113
            ket = cursor;
            // substring, line 113
            among_var = find_among_b(a_noun);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 113
            bra = cursor;
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 115
                    // literal, line 115
                    if (!(eq_s_b("\u043D"))) // н
                    {
                        return false;
                    }
                    // delete, line 115
                    slice_del();
                    break;
                case 2:
                    // (, line 116
                    // <-, line 116
                    slice_from("\u043A"); // к
                    break;
                case 3:
                    // (, line 127
                    // delete, line 127
                    slice_del();
                    break;
            }
            return true;
        }

        private bool r_tidy_up()
        {
            int among_var;
            // (, line 132
            // [, line 133
            ket = cursor;
            // substring, line 133
            among_var = find_among_b(a_5);
            if (among_var == 0)
            {
                return false;
            }
            // ], line 133
            bra = cursor;
            switch (among_var)
            {
                case 0:
                    return false;
                case 1:
                    // (, line 135
                    // literal, line 135
                    if (!(eq_s_b("\u043D"))) // н
                    {
                        return false;
                    }
                    // delete, line 135
                    slice_del();
                    break;
                case 2:
                    // (, line 137
                    // literal, line 137
                    if (!(eq_s_b("\u0442"))) // т
                    {
                        return false;
                    }
                    // delete, line 137
                    slice_del();
                    break;
                case 3:
                    // (, line 146
                    // delete, line 146
                    slice_del();
                    break;
                case 4:
                    // (, line 147
                    // <-, line 147
                    slice_from("\u0456\u0441\u0442"); // іст
                    break;
            }
            return true;
        }

        protected bool eq_s(string s)
        {
            if (limit - cursor < s.Length) return false;
            int i;
            for (i = 0; i != s.Length; i++)
            {
                if (current[cursor + i] != s[i]) return false;
            }
            cursor += s.Length;
            return true;
        }

        protected bool eq_s_b(string s)
        {
            if (cursor - limit_backward < s.Length) return false;
            int i;
            for (i = 0; i != s.Length; i++)
            {
                if (current[cursor - s.Length + i] != s[i]) return false;
            }
            cursor -= s.Length;
            return true;
        }

        protected int find_among(List<Among> v)
        {
            int i = 0;
            int j = v.Count;

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
                for (i2 = common; i2 < w.s.Length; i2++)
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
                if (common_i >= w.s.Length)
                {
                    cursor = c + w.s.Length;
                    if (w.method == null) return w.result;
                    bool res = false;
                    try
                    {
                        //Object resobj = w.method.Invoke(this);
                        //res = resobj.ToString().Equals("true");
                    }
                    catch (Exception e)
                    {
                        res = false;
                        // FIXME - debug message
                    }
                    cursor = c + w.s.Length;
                    if (res) return w.result;
                }
                i = w.substring_i;
                if (i < 0) return 0;
            }
        }

        // find_among_b is for backwards processing. Same comments apply
        protected int find_among_b(List<Among> v)
        {
            int i = 0;
            int j = v.Count;

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
                for (i2 = w.s.Length - 1 - common; i2 >= 0; i2--)
                {
                    if (c - common == lb)
                    {
                        diff = -1;
                        break;
                    }
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
                if (common_i >= w.s.Length)
                {
                    cursor = c - w.s.Length;
                    if (w.method == null) return w.result;

                    bool res = false;
                    try
                    {
                        //Object resobj = w.method.Invoke(this);
                        //res = resobj.ToString().Equals("true");
                    }
                    catch (Exception e)
                    {
                        res = false;
                        // FIXME - debug message
                    }
                    cursor = c - w.s.Length;
                    if (res) return w.result;
                }
                i = w.substring_i;
                if (i < 0) return 0;
            }
        }

        /* to replace chars between c_bra and c_ket in current by the
         * chars in s.
         */
        protected int replace_s(int c_bra, int c_ket, string s)
        {
            int adjustment = s.Length - (c_ket - c_bra);
            current = current.Replace(current.ToString(c_bra, c_ket - c_bra), s);
            limit += adjustment;
            if (cursor >= c_ket) cursor += adjustment;
            else if (cursor > c_bra) cursor = c_bra;
            return adjustment;
        }

        protected void slice_check()
        {
            if (bra < 0 ||
                bra > ket ||
                ket > limit ||
                limit > current.Length)   // this line could be removed
            {
                Console.WriteLine("faulty slice operation");
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

        /* Copy the slice into the supplied StringBuffer */
        protected string slice_to(string s)
        {
            slice_check();
            int len = ket - bra;
            s = current.ToString(bra, ket - bra);
            return s;
        }

        protected string assign_to(string s)
        {
            s = current.ToString(0, limit);
            return s;
        }

        public string Stem(string s)
        {
            this.setCurrent(s);
            lab0: do
            {
                int v_1 = cursor;
                lab1: do
                {
                    {
                        int v_2 = cursor;
                        lab2: do
                        {
                            {
                                int c = cursor + 4;
                                if (0 > c || c > limit)
                                {
                                    goto lab2_end;
                                }
                                cursor = c;
                            }
                            goto lab1_end;
                        } while (false);
                        lab2_end:
                        cursor = v_2;
                    }
                    goto lab0_end;
                } while (false);
                lab1_end:
                cursor = v_1;

                lab3: do
                {
                    int v_3 = cursor;
                    lab4: do
                    {
                        if (!r_exception1())
                        {
                            goto lab4_end;
                        }
                        goto lab3_end;
                    } while (false);
                    lab4_end:
                    cursor = v_3;

                    limit_backward = cursor;
                    cursor = limit;

                    int v_4 = limit - cursor;
                    lab5: do
                    {

                        int v_5 = limit - cursor;
                        lab6: do
                        {
                            // call postfix, line 157
                            if (!r_postfix())
                            {
                                cursor = limit - v_5;
                                goto lab6_end;
                            }
                        } while (false);
                        lab6_end:
                        // or, line 158
                        lab7: do
                        {
                            int v_6 = limit - cursor;
                            lab8: do
                            {
                                // call adjective, line 158
                                if (!r_adjective())
                                {
                                    goto lab8_end;
                                }
                                goto lab7_end;
                            } while (false);
                            lab8_end:
                            cursor = limit - v_6;
                            lab9: do
                            {
                                // call verb, line 158
                                if (!r_verb())
                                {
                                    goto lab9_end;
                                }
                                goto lab7_end;
                            } while (false);
                            lab9_end:
                            cursor = limit - v_6;
                            // call noun, line 158
                            if (!r_noun())
                            {
                                goto lab5_end;
                            }
                        } while (false);
                        lab7_end:
                        ;
                    } while (false);
                    lab5_end:
                    cursor = limit - v_4;
                    // do, line 160
                    int v_7 = limit - cursor;
                    lab10: do
                    {
                        // call tidy_up, line 160
                        if (!r_tidy_up())
                        {
                            goto lab10_end;
                        }
                    } while (false);
                    lab10_end:
                    cursor = limit - v_7;
                    cursor = limit_backward;
                } while (false);
                lab3_end:
                ;
            } while (false);
            lab0_end:
            return this.getCurrent();
        }
    }
}
