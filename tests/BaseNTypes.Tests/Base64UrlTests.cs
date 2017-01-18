// Copyright 2016-2017 Franzmayr Peter (peter@franzmayr.at)
//   
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
// associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using Xunit;

namespace Franzmayr.BaseNTypes.Tests
{
    public class Base64UrlTests
    {
        [Fact]
        public void Base64Url_UsesCorrectAlphabet() 
        {
            var expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

            Assert.Equal(expected, Base64Url.Coder.Alphabet);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123+")]
        public void Base64Url_CreateWithInvalidEncodedString_ThrowsException(string encodedString) 
        {
            Assert.Throws<ArgumentException>(() => new Base64Url(encodedString));
        }

        [Theory, ClassData(typeof(Base64RfcTestPatterns))]
        [InlineData(null, "")]
        public void Base64Url_Encode_ReturnsCorrectEncodedResult(string stringToEncode, string expected) 
        {
            Assert.Equal(expected, stringToEncode.ToBase64Url().ToString());
        }

        [Theory, ClassData(typeof(Base64RfcTestPatterns))]
        [InlineData("", null)]
        public void Base64Url_Decode_ReturnsCorrectDecodedResult(string expected, string stringToDecode) 
        {
            Assert.Equal(expected, new Base64Url(stringToDecode).FromBaseN());
        }

        [Fact]
        public void Base64Url_CreateWithValidBaseNString_ReturnsCorrectBase64UrlString() 
        {
            var base64String = new Base64("F+/bFw==");
            var expected = "F-_bFw==";

            var sut = new Base64Url(base64String);

            Assert.Equal(expected, sut.ToString());
        }

        [Fact]
        public void Base64Url_DecodeWithSpecialChars_ReturnsCorrectDecodedResult() 
        {
            var stringToDecode = "F-_bFw==";
            var expected = new byte[] {23, 239, 219, 23};
            var sut = new Base64Url(stringToDecode);

            var result = sut.DecodedBytes;
            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Base64Url_EncodeWithSpecialChars_ReturnsCorrectEncodedResult() 
        {
            var bytesToEncode = new byte[] {23, 239, 219, 23};
            var expected = "F-_bFw==";
            var sut = new Base64Url(bytesToEncode);

            var result = sut.ToString();
            
            Assert.Equal(expected, result);
        }
   }
}
