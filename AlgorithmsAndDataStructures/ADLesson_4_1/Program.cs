using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ADLesson_4_1
{
    public class RandomHelpers
    {
        private readonly Random _random = new Random();
        private readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string RandomString(int length)
        {
            return string.Join("", Enumerable.Repeat(_chars, length).Select(c => c[_random.Next(c.Length)]));
        }
    }

    public class Tables
    {
        private readonly int CountValues = 10_000;
        private readonly int LengthString = 20;
        private readonly RandomHelpers _randomHelpers = new RandomHelpers();
        private readonly string[] ArrayWithRandomString;
        private readonly HashSet<string> HashSetString;

        public Tables()
        {
            ArrayWithRandomString = Enumerable.Repeat<string>("", CountValues)
                .Select(x => _randomHelpers.RandomString(LengthString)).ToArray();

            HashSetString = new HashSet<string>(ArrayWithRandomString);
        }

        [Benchmark]
        [Arguments("QGA1MO8N5LUOS01KT5JQ")]
        public bool FindInHashSet(string findString)
        {
            return HashSetString.Contains(findString);
        }

        [Benchmark]
        [Arguments("QGA1MO8N5LUOS01KT5JQ")]
        public bool FindInArray(string findString)
        {
            return ArrayWithRandomString.Contains(findString);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Tables>();
        }
    }
}