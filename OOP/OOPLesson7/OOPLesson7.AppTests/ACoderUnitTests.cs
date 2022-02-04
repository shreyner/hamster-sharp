using System;
using Xunit;
using OOPLesson7.App;

namespace OOPLesson7.AppTests
{
    public class ACoderUnitTests
    {
        [Fact]
        public void Encode_Decoder_ReturnString()
        {
            var aCode = new ACoder();
            
            Assert.Equal("привет", aCode.Decoder(aCode.Encoder("привет")));
        }
        
        [Fact]
        public void Encode_MiddleElementOfAlphabet_ReturnString()
        {
            var aCode = new ACoder();
            
            Assert.Equal("зий", aCode.Encoder("жзи"));
        }
        
        [Fact]
        public void Encode_LastElementOfAlphabet_ReturnString()
        {
            var aCode = new ACoder();
            
            Assert.Equal("юяа", aCode.Encoder("эюя"));
        }

        [Fact]
        public void Decode_MiddleElementOfAlphabet_ReturnString()
        {
            var aCode = new ACoder();
            
            Assert.Equal("жзи", aCode.Decoder("зий"));
        }

        [Fact]
        public void Decode_FirstElementOfAlphabet_ReturnString()
        {
            var aCode = new ACoder();
            
            Assert.Equal("эюя", aCode.Decoder("юяа"));
        }
    }
}