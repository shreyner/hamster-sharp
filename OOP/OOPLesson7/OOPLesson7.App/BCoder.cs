using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLesson7.App
{
    public class BCoder : ICoder
    {
        private List<char> UpperCaseAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray().ToList();
        private List<char> LowerCaseAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray().ToList();
        
        private char EncodeChar(char symbol)
        {
            var index = UpperCaseAlphabet.IndexOf(symbol);

            if (index != -1)
            {
                return UpperCaseAlphabet.ElementAt(UpperCaseAlphabet.Count - index - 1);
            }

            index = LowerCaseAlphabet.IndexOf(symbol);

            return LowerCaseAlphabet.ElementAt(LowerCaseAlphabet.Count - index - 1);
        }

        public string Encoder(string payload)
        {
            return String.Join("", payload.ToCharArray().Select(EncodeChar));
        }

        public string Decoder(string data)
        {
            return String.Join("", data.ToCharArray().Select(EncodeChar));
        }
    }
}