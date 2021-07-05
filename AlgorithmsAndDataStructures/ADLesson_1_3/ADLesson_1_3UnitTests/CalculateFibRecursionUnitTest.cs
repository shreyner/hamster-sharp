using System;
using Xunit;
using ADLesson_1_3;

namespace ADLesson_1_3UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCalculateFibRecursionWith1()
        {
            var input = 1;
            var expected = 1;

            var actual = Fibonacci.Recursion(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateFibRecursionWith2()
        {
            var input = 2;
            var expected = 1;

            var actual = Fibonacci.Recursion(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateFibRecursionWith3()
        {
            var input = 3;
            var expected = 2;

            var actual = Fibonacci.Recursion(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateFibRecursionWith7()
        {
            var input = 7;
            var expected = 13;

            var actual = Fibonacci.Recursion(input);

            Assert.Equal(expected, actual);
        }
    }
}