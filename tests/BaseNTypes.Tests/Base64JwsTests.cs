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
    public class Base64JwsTests
    {
        [Fact]
        public void Base64Jws_UsesCorrectAlphabet() 
        {
            var expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";

            Assert.Equal(expected, Base64Jws.Coder.Alphabet);
        }

        [Fact]
        public void Base64Jws_CreateWithInvalidEncodedString_ThrowsException() 
        {
            Assert.Throws<ArgumentException>(() => new Base64Jws("123+"));
        }

        [Fact]
        public void Base64Jws_CreateWithValidBaseNString_ReturnsCorrectBase64JwsString() 
        {
            var base64String = "F+/bFw==".AsBase64();
            var expected = "F-_bFw";

            var sut = new Base64Jws(base64String);

            Assert.Equal(expected, sut.ToString());
        }

        [Fact]
        public void Base64Jws_DecodeWithSpecialChars_ReturnsCorrectDecodedResult() 
        {
            var expected = new byte[] {23, 239, 219, 23};
            var sut = "F-_bFw".AsBase64Jws();

            var result = sut.DecodedBytes;
            
            Assert.Equal(expected, result);
        }


        [Fact]
        public void Base64Jws_EncodeWithSpecialChars_ReturnsCorrectEncodedResult() 
        {
            var bytesToEncode = new byte[] {23, 239, 219, 23};
            var expected = "F-_bFw";
            var sut = new Base64Jws(bytesToEncode);

            var result = sut.ToString();
            
            Assert.Equal(expected, result);
        }

    }
}
