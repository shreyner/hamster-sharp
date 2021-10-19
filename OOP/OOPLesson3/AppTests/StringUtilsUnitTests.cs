using System;
using App;
using Xunit;

namespace AppTests
{
    public class StringUtilsUnitTests
    {
        [Fact]
        public void ReverseString_ReturnOk()
        {
            var input = "Hello world";
            var expected = "dlrow olleH";
            
            Assert.Equal(StringUtils.Reverse(input), expected);
        }
    }
}