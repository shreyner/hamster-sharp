using System;
using PolishCalculator.App;
using Xunit;

namespace PolishCalculator.AppTests
{
    public class InfixToPostfixConverterUnitTests
    {
        [Fact]
        public void Parse_BaseUseCase_ReturnOk()
        {
            InfixToPostfixConverter infixToPostfixConverter = new();

            Assert.Equal("2 7 5 * +", infixToPostfixConverter.Parse("2 + 7 * 5"));
        }
        
        [Fact]
        public void Parse_BaseUseCase2_ReturnOk()
        {
            InfixToPostfixConverter infixToPostfixConverter = new();

            Assert.Equal("3 3 * 7 1 + /", infixToPostfixConverter.Parse("3 * 3 / ( 7 + 1 )"));
        }
        
        [Fact]
        public void Parse_BaseUseCase3_ReturnOk()
        {
            InfixToPostfixConverter infixToPostfixConverter = new();

            Assert.Equal("5 6 2 - 9 * + 3 + 7 1 - +", infixToPostfixConverter.Parse("5 + ( 6 - 2 ) * 9 + 3 + ( 7 - 1 )"));
        }
    }
}
