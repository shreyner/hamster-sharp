using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var rationalNumber1 = new RationalNumber(1, 2);
            var rationalNumber11 = new RationalNumber(1, 2);
            var rationalNumber2 = new RationalNumber(1, 3);

            var rationalNumber3 = new RationalNumber(1, 2);
            var rationalNumber4 = new RationalNumber(1, 3);

            Console.WriteLine(
                "RN1: {0}, RN2: {1}\nRN2 == RN1: {2} | RN2 != RN1 {3}\nRN1 + RN2: {4}, RN2 - RN1: {5}\nRN1++ {6}, RN2-- {7}\nRN1 < RN2 {8}, RN2 < RN1 {9}",
                rationalNumber1,
                rationalNumber2,
                rationalNumber2 == rationalNumber1,
                rationalNumber2 != rationalNumber1,
                rationalNumber1 + rationalNumber2,
                rationalNumber2 - rationalNumber1,
                rationalNumber3++,
                rationalNumber4--,
                rationalNumber1 < rationalNumber2,
                rationalNumber2 < rationalNumber1 
            );
        }
    }
}