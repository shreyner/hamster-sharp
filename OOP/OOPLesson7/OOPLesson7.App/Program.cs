using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLesson7.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var aCoder = new ACoder();
            var bCoder = new BCoder();

            Console.WriteLine(
                "ACoder: payload: \"{0}\", encoded: {1}, decoded: {2}",
                "привет",
                aCoder.Encoder("привет"),
                aCoder.Decoder(aCoder.Encoder("привет"))
            );
            
            Console.WriteLine(
                "BCoder: payload: \"{0}\", encoded: {1}, decoded: {2}",
                "Привет",
                bCoder.Encoder("Привет"),
                bCoder.Decoder(bCoder.Encoder("Привет"))
            );
        }
    }
}