using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using VIN_LIB.utils;

namespace VIN_LIB
{
    public class VinLibrary
    {
        public static Boolean CheckVIN(string VIN)
        {
            if (!Regex.IsMatch(VIN, "[^a-hj-npr-zA-HJ-NPR-Z0-9]"))
            {
                return false;
            }
            VIN = VIN.ToLower();
            int[] weights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            Dictionary<char, int> Transliterations = new Dictionary<char, int>(15);
            Transliterations.Add('a', 1);
            Transliterations.Add('b', 2);
            Transliterations.Add('c', 3);
            Transliterations.Add('d', 4);
            Transliterations.Add('e', 5);
            Transliterations.Add('f', 6);
            Transliterations.Add('g', 7);
            Transliterations.Add('h', 8);
            Transliterations.Add('j', 1);
            Transliterations.Add('k', 2);
            Transliterations.Add('l', 3);
            Transliterations.Add('m', 4);
            Transliterations.Add('n', 5);
            Transliterations.Add('p', 7);
            Transliterations.Add('r', 9);
            Transliterations.Add('s', 2);
            Transliterations.Add('t', 3);
            Transliterations.Add('u', 4);
            Transliterations.Add('v', 5);
            Transliterations.Add('w', 6);
            Transliterations.Add('x', 7);
            Transliterations.Add('y', 8);
            Transliterations.Add('z', 9);

            int sum = 0;
            char[] VINChars = VIN.ToCharArray();

            for (int i = 0; i < VINChars.Length-1; i++)
            {
                if (!Char.IsDigit(VINChars[i]))
                {
                    sum += Transliterations[VINChars[i]] * weights[i];
                } else
                {
                    sum += int.Parse(""+ VINChars[i]) * weights[i];
                }
            }
            int CheckDigit = sum % 11;
            if (CheckDigit == 10 && VINChars[8] == 'x')
            {
                return true;
            }

            return int.Parse("" + VINChars[8]) == CheckDigit;
            //return true;
        }

        public static string GetVINCountry(String VIN)
        {
            Char[] VINChars = VIN.ToUpper().ToCharArray();
            Dictionary<string, string> Countries = Dictionaries.getCountries();
            string[] keys = Countries.Keys.ToArray();
            
            for (int i = 0; i <= keys.Length - 1; i++)
            {
                string key = keys[i];
                string[] CountryRanges = key.Split('-');
                bool isCountryMatch = true;
                for (int j = 0; j <= CountryRanges.Length - 1; j++)
                {
                    if (!string.IsNullOrEmpty(CountryRanges[j])){
                        char[] RangeChars = CountryRanges[j].ToCharArray();
                        if (CountryRanges[j].Length == 1 && RangeChars[0] != VINChars[j])
                        {
                            isCountryMatch = false;
                            break;
                        }
                        else if (CountryRanges[j].Length == 2 && !(Utils.getCharPower(RangeChars[0]) <= Utils.getCharPower(VINChars[j]) && 
                            Utils.getCharPower(RangeChars[1]) >= Utils.getCharPower(VINChars[j])))
                        {
                            isCountryMatch = false;
                            break;
                        }
                    }
                }
                if (isCountryMatch)
                {
                    return Countries[key];
                }
            }
            return string.Empty;
        }

        public static int GetTransportYear(string VIN)
        {
            return Utils.getYearByChar(VIN.ToCharArray()[9]);
        }

    }

    
}
