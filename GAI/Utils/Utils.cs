using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GAI.Utils
{
    class Utils
    {
        public static String TransliterateCyrToLat(char Symbol)
        {
            string cyrillicChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            string[] transliterations = { 
                "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "j", "k", "l", "m", 
                "n", "o", "p", "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "shch", "\"", 
                "y", "'", "e", "yu", "ya", "A", "B", "V", "G", "D", "E", "YO", "ZH", "Z", 
                "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "H", "C", 
                "CH", "SH", "SHCH", "\"", "Y", "'", "E", "YU", "YA" };
            return transliterations[cyrillicChars.IndexOf(Symbol)];
            
        }
    }
}
