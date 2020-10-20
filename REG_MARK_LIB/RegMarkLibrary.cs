using REG_MARK_LIB.utils;
using System;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace REG_MARK_LIB
{
    public class RegMarkLibrary
    {
        public static bool CheckMark(string mark)
        {
            if (Regex.IsMatch(mark, "[abekmhopctyxABEKMHOPCTYX]{1}[0-9]{3}[abekmhopctyxABEKMHOPCTYX]{2}[0-9]{3}"))
            {
                return true;
            }

            return false;
        }

        public static string GetNextMarkAfter(string mark)
        {
            if (CheckMark(mark))
            {
                mark = mark.ToUpper();
                int[] MarkInt = Utils.ConvertRegMarkToNumber(mark);
                if (MarkInt[0].Equals(999))
                {
                    MarkInt[0] = 0;
                    if (MarkInt[1].Equals(1727))
                    {
                        if (MarkInt[2].Equals(999))
                        {
                            for (int i = 0; i <= MarkInt.Length - 1; i++)
                            {
                                MarkInt[i] = 0;
                            }
                            return Utils.ConvertNumberToRegMark(MarkInt);
                        }
                        else
                        {
                            MarkInt[2]++;
                            return Utils.ConvertNumberToRegMark(MarkInt);
                        }
                    }
                    else
                    {
                        MarkInt[1]++;
                        return Utils.ConvertNumberToRegMark(MarkInt);
                    }

                }
                else
                {
                    MarkInt[0]++;
                    return Utils.ConvertNumberToRegMark(MarkInt);
                }
            }
            return string.Empty;
        }

        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd)
        {
            if (CheckMark(prevMark) && CheckMark(rangeStart) && CheckMark(rangeEnd))
            {
                int[] prevMarkInt = Utils.ConvertRegMarkToNumber(prevMark);
                int[] rangeStartInt = Utils.ConvertRegMarkToNumber(rangeStart);
                int[] rangeEndInt = Utils.ConvertRegMarkToNumber(rangeEnd);
                
                // |X|
                byte i = Utils.CompareMarks(rangeEndInt, rangeStartInt);
                if (i == 2)
                {
                    int[] t = rangeStartInt;
                    rangeStartInt = rangeEndInt;
                    rangeEndInt = t;
                    string ts = rangeStart;
                    rangeStart = rangeEnd;
                    rangeEnd = ts;
                }

                // |
                i = Utils.CompareMarks(prevMarkInt, rangeStartInt);
                byte j = Utils.CompareMarks(rangeStartInt, rangeEndInt);
                if (i == 0 && j == 0)
                {
                    return "out of stock.";
                }

                // | - |
                i = Utils.CompareMarks(rangeEndInt, rangeStartInt);
                j = Utils.CompareMarks(prevMarkInt, rangeStartInt);
                if (i == 0 && j == 2)
                {
                    return rangeStart;
                }
                else if (i == 0 && j == 1)
                {
                    return "out of stock.";
                }

                // |>
                i = Utils.CompareMarks(prevMarkInt, rangeStartInt);

                if (i == 0)
                {
                    return GetNextMarkAfter(prevMark);
                }

                // | <->
                if (i == 2)
                {
                    return rangeStart;
                }

                // <-|-->
                j = Utils.CompareMarks(prevMarkInt, rangeEndInt);

                if (i == 1 && j == 2)
                {
                    return GetNextMarkAfter(prevMark);
                }

                // <---> |

                if (i == 1 && j == 1)
                {
                    return "out of stock.";
                }

            }

            return "out of stock.";
        }

        public static long GetCombinationsCountInRange(string mark1, string mark2)
        {
            int[] markint1 = Utils.ConvertRegMarkToNumber(mark1);
            int[] markint2 = Utils.ConvertRegMarkToNumber(mark2);

            byte i = Utils.CompareMarks(markint1, markint2);
            if (i == 0)
            {
                return 0;
            }
            else
            {
                long CountingBuffer = 1;
                for (int j = 0; j <= 2; j++)
                {
                    CountingBuffer = CountingBuffer * Math.Abs(markint1[j]-markint2[j]);
                }
                return CountingBuffer;
            }
        }
    }
}
