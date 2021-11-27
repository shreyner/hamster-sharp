using System;
using PolishCalculator.App;
using Xunit;

namespace PolishCalculator.AppTests
{
    public class PolishNotationCalculatorUnitTests
    {
        [Fact]
        public void Calc_EmptyString_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();

            Assert.Equal(0, polishNotationCalc.Calc(""));
        }
        
        [Fact]
        public void Calc_WithOneNumber_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();

            Assert.Equal(3, polishNotationCalc.Calc("3"));
        }

        [Fact]
        public void Calc_plus_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();
        
            Assert.Equal(4, polishNotationCalc.Calc("1 3 +"));
        }
        
        [Fact]
        public void Calc_multi_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();
        
            Assert.Equal(3, polishNotationCalc.Calc("1 3 *"));
        }
        
        [Fact]
        public void Calc_minus_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();
        
            Assert.Equal(-2, polishNotationCalc.Calc("1 3 -"));
        }
        
        [Fact]
        public void Calc_del_ReturnOk()
        {
            PolishNotationCalc polishNotationCalc = new();
        
            Assert.Equal(2, polishNotationCalc.Calc("4 2 /"));
        }
    }
}
