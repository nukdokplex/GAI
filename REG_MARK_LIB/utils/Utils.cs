using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace REG_MARK_LIB.utils
{
    public class Utils
    {
        public static string letters = "ABEKMHOPCTYX";
        public static int GetLetterPower(char letter)
        {
            return letters.IndexOf(letter);
        }

        public static char GetNextLetter(char letter)
        {
            return letters.ToCharArray()[GetLetterPower(letter)+1];
        }

        
        
        public static int[] ConvertRegMarkToNumber(string mark)
        {
            /*//Center Code - max 999
            int FirstFragment = int.Parse("" + mark[1] + mark[2] + mark[3]);
            //Letters - max 1727
            int SecondFragment = GetLetterPower(mark[5]) + GetLetterPower(mark[4]) * 12 + GetLetterPower(mark[0]) * 144;
            //Region code - max 999
            int ThirdFragment = int.Parse("" + mark[6] + mark[7] + mark[8]);*/
            return new int[] { int.Parse("" + mark[1] + mark[2] + mark[3]), //Center Code - max 999 
                GetLetterPower(mark[5]) + GetLetterPower(mark[4]) * 12 + GetLetterPower(mark[0]) * 144, //Letters - max 1727
                int.Parse("" + mark[6] + mark[7] + mark[8]) //Region code - max 999
            };
        }

        static string pad_an_int(int N, int P)
        {
            // string used in Format() method 
            string s = "{0:";
            for (int i = 0; i < P; i++)
            {
                s += "0";
            }
            s += "}";

            // use of string.Format() method 
            string value = string.Format(s, N);

            // return output 
            return value;
        }

        public static byte CompareMarks(int[] mark1, int[] mark2)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (mark1[i] == mark2[i])
                {
                    if (i == 2)
                    {
                        return 0;
                    }
                }
                else
                {
                    break;
                }
            }
            for (int i = 2; i >= 0; i--)
            {
                if (mark1[i] > mark2[i])
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return 3;
        }

        public static string ConvertNumberToRegMark(int[] mark)
        {
            int i = mark[1] / 144;
            int j = mark[1] / 12 % 12;
            int k = mark[1] % 12;
            //      char[] curletters = new char[] { letters[mark[1] % 144] , letters[mark[1] % 12] , };
            return letters[mark[1] / 144] + pad_an_int(mark[0], 3) + letters[mark[1] / 12 % 12] + letters[mark[1] % 12] + pad_an_int(mark[2], 3);
        }
    }
}
