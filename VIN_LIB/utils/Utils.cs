using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace VIN_LIB.utils
{
    class Utils
    {
        public static int getCharPower(char character)
        {
            return (new Dictionary<char, int> {
                { 'A', 0 },
                { 'B', 1 },
                { 'C', 2 },
                { 'D', 3 },
                { 'E', 4 },
                { 'F', 5 },
                { 'G', 6 },
                { 'H', 7 },
               // { 'I', 8 },
                { 'J', 9 },
                { 'K', 10 },
                { 'L', 11 },
                { 'M', 12 },
                { 'N', 13 },
               // { 'O', 14 },
                { 'P', 15 },
              //  { 'Q', 16 },
                { 'R', 17 },
                { 'S', 18 },
                { 'T', 19 },
                { 'U', 20 },
                { 'V', 21 },
                { 'W', 22 },
                { 'X', 23 },
                { 'Y', 24 },
                { 'Z', 25 },
                { '1', 26 },
                { '2', 27 },
                { '3', 28 },
                { '4', 29 },
                { '5', 30 },
                { '6', 31 },
                { '7', 32 },
                { '8', 33 },
                { '9', 34 },
                { '0', 35 },
            })[character];
        }
        public static int getYearByChar(Char character)
        {
            return new Dictionary<Char, int> {
                { 'A', 1980 },
                { 'B', 1981 },
                { 'C', 1982 },
                { 'D', 1983 },
                { 'E', 1984 },
                { 'F', 1985 },
                { 'G', 1986 },
                { 'H', 1987 },
                { 'J', 1988 },
                { 'K', 1989 },
                { 'L', 1990 },
                { 'M', 1991 },
                { 'N', 1992 },
                { 'P', 1993 },
                { 'R', 1994 },
                { 'S', 1995 },
                { 'T', 1996 },
                { 'V', 1997 },
                { 'W', 1998 },
                { 'X', 1999 },
                { 'Y', 2000 },
                { '1', 2001 },
                { '2', 2002 },
                { '3', 2003 },
                { '4', 2004 },
                { '5', 2005 },
                { '6', 2006 },
                { '7', 2007 },
                { '8', 2008 },
                { '9', 2009 },

            }[Char.ToUpper(character)];
        }
    }
}
