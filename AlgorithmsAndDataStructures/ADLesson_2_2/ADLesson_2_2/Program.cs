using System;

namespace ADLesson_2_2
{
    public class TestCase
    {
        public int[] Input;
        public int TargetSearch;
        public int Expected;
    }

    class Program
    {
        static void TestBinarySearch(TestCase testCase)
        {
            var actual = Search.BinarySearch(testCase.Input, testCase.TargetSearch);


            Console.Write(
                $"[BinarySearch] Array: {testCase.Input}, Input: {testCase.TargetSearch}, Actual Index in Array: {actual}");

            if (actual == testCase.Expected)
            {
                Console.WriteLine($" Test: Valid");
            }
            else
            {
                Console.WriteLine($" Test: Not Valid");
            }
        }

        static void Main(string[] args)
        {
            var testCaseWithFind = new TestCase {Input = new[] {1, 2, 3, 4}, TargetSearch = 2, Expected = 1};
            var testCaseWithNotFind = new TestCase {Input = new[] {1, 2, 3, 4}, TargetSearch = 0, Expected = -1};

            TestBinarySearch(testCaseWithFind);
            TestBinarySearch(testCaseWithNotFind);
        }
    }
}