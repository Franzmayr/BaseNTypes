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

using System.Collections.Generic;
using Xunit;

namespace Franzmayr.BaseNTypes.Tests
{
    public class Base16Tests 
    {
        [Fact]
        public void Base16_UsesCorrectAlphabet() 
        {
            Assert.Equal("0123456789ABCDEF", Base16.Coder.Alphabet);
        }

        [Fact]
        public void Base16_CreateWithValidBaseNString_ReturnsCorrectBase16String() 
        {
            var expected = "666F6F626172";

            var sut = "MZXW6YTBOI======".AsBase32().ToBase16();

            Assert.Equal(expected, sut.ToString());
        }

        // IETF RFC 4648 Test Patterns (https://tools.ietf.org/html/rfc4648)
        public static IEnumerable<object[]> RfcTestPatterns
        {
            get
            {
                yield return new object[] {"", ""};
                yield return new object[] {"f", "66"};
                yield return new object[] {"fo", "666F"};
                yield return new object[] {"foo", "666F6F"};
                yield return new object[] {"foob", "666F6F62"};
                yield return new object[] {"fooba", "666F6F6261"};
                yield return new object[] {"foobar", "666F6F626172"};
            }
        }

        [Theory, MemberData(nameof(RfcTestPatterns))]
        [InlineData(null, "")]
        public void Base16_Encode_ReturnsCorrectEncodedResult(string stringToEncode, string expected) 
        {
            Assert.Equal(expected, stringToEncode.ToBase16().ToString());
        }

        [Theory, MemberData(nameof(RfcTestPatterns))]
        [InlineData("", null)]
        public void Base16_Decode_ReturnsCorrectDecodedResult(string expected, string stringToDecode) 
        {
            Assert.Equal(expected, stringToDecode.AsBase16().FromBaseN());
        }
    }
}
