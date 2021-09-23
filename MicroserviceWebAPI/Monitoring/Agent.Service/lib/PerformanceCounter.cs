using System;

namespace Agent.Service
{
    public class PerformanceCounter
    {
        private readonly Random _random;

        public PerformanceCounter()
        {
            _random = new Random();
        }

        public int NextValue()
        {
            return _random.Next();
        }
    }
}