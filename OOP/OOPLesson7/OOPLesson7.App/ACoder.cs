using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLesson7.App
{
    public class ACoder : ICoder
    {
        private List<char> Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray().ToList();
        private int ShiftAlphabet = 1;

        private char GetCharByChar(char symbol, int shift)
        {
            var index = Alphabet.IndexOf(symbol);

            if (index == -1)
            {
                throw new Exception("Unknown char");
            }

            index += shift;

            if (index >= Alphabet.Count)
            {
                index = Alphabet.Count - index;
            }

            if (index < 0)
            {
                index = index + Alphabet.Count;
            }

            return Alphabet.ElementAt(index);
        }

        public string Encoder(string payload)
        {
            return String.Join("", payload.ToCharArray().Select(x => GetCharByChar(x, ShiftAlphabet)));
        }

        public string Decoder(string data)
        {
            return String.Join("", data.ToCharArray().Select(x => GetCharByChar(x, ShiftAlphabet * -1)));
        }
    }
}