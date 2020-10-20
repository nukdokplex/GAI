using System;
using VIN_LIB;
using REG_MARK_LIB;
using REG_MARK_LIB.utils;

namespace VIN_LIB_TESTER
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.Write("Enter VIN: ");
            string VIN = Console.ReadLine();
            VIN = string.IsNullOrWhiteSpace(VIN) ? "1G1BU51H2HX113345" : VIN; // 1987 Chevrolet Caprice
            Console.WriteLine("Good VIN: "+(VinLibrary.CheckVIN(VIN) ? "yes" : "no"));
            Console.WriteLine("Country: ", VinLibrary.GetVINCountry(VIN));
            Console.WriteLine("Year: "+VinLibrary.GetTransportYear(VIN));*/
            Console.WriteLine(RegMarkLibrary.GetCombinationsCountInRange("A000AA000", "X999XX999"));

        }
    }
}
