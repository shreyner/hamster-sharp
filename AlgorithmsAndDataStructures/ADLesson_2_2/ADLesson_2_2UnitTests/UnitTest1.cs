using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using ADLesson_2_2;

namespace ADLesson_2_2UnitTests
{
    public class BinarySearchUnitTests
    {
        [Fact]
        public void BinarySearch_ShouldIndex()
        {
            var input = new int[] {20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120};
            var expected = 3;

            var actual = Search.BinarySearch(input, 50);
            
            Assert.Equal(expected, actual);

        }
        
        [Fact]
        public void BinarySearch_NotFind()
        {
            var input = new int[] {20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120};
            var expected = -1;

            var actual = Search.BinarySearch(input, 99);
            
            Assert.Equal(expected, actual);
        }
    }
}