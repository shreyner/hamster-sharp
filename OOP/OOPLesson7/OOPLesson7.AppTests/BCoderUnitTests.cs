using System;
using OOPLesson7.App;
using Xunit;

namespace OOPLesson7.AppTests
{
    public class BCoderUnitTests
    {
        
        [Fact]
        public void Encode_Decoder_ReturnString()
        {
            var bCode = new BCoder();
            
            Assert.Equal("Привет", bCode.Decoder(bCode.Encoder("Привет")));
        }
        
        [Fact]
        public void Encode_BaseValue_ReturnString()
        {
            var bCode = new BCoder();
            
            Assert.Equal("ЮЭЬюэь", bCode.Encoder("БВГбвг"));
        }
        
        [Fact]
        public void Decode_BaseValue_ReturnString()
        {
            var bCode = new BCoder();
            
            Assert.Equal("БВГбвг", bCode.Decoder("ЮЭЬюэь"));
        }
        
    }
}