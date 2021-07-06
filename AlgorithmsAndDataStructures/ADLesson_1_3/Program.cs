using System;

namespace ADLesson_1_3
{
    public class TestCase
    {
        public int X { get; set; }
        public int Expected { get; set; }
    }

    class Program
    {
        static void TestFibRecursion(TestCase testCase)
        {
            var actual = Fibonacci.Recursion(testCase.X);


            Console.Write($"[Fibonacci.Recursion] Input: {testCase.X}, Expected: {testCase.Expected}");
            if (actual == testCase.Expected)
            {
                Console.WriteLine($"Test: Valid");
            }
            else
            {
                Console.WriteLine($"Test: Not Valid");
            }
        }

        static void TestFibLoop(TestCase testCase)
        {
            var actual = Fibonacci.Loop(testCase.X);


            Console.Write($"[Fibonacci.Loop] Input: {testCase.X}, Expected: {testCase.Expected}");
            if (actual == testCase.Expected)
            {
                Console.WriteLine($"Test: Valid");
            }
            else
            {
                Console.WriteLine($"Test: Not Valid");
            }
        }

        static void Main(string[] args)
        {
            var testCaseFib0 = new TestCase {X = 0, Expected = 0};
            var testCaseFib1 = new TestCase {X = 1, Expected = 1};
            var testCaseFib2 = new TestCase {X = 2, Expected = 1};
            var testCaseFib3 = new TestCase {X = 3, Expected = 2};
            var testCaseFib7 = new TestCase {X = 7, Expected = 13};

            TestFibRecursion(testCaseFib0);
            TestFibRecursion(testCaseFib1);
            TestFibRecursion(testCaseFib2);
            TestFibRecursion(testCaseFib3);
            TestFibRecursion(testCaseFib7);

            TestFibLoop(testCaseFib0);
            TestFibLoop(testCaseFib1);
            TestFibLoop(testCaseFib2);
            TestFibLoop(testCaseFib3);
            TestFibLoop(testCaseFib7);
        }
    }
}