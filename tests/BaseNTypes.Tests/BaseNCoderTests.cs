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
using System.Linq;
using Xunit;

namespace Franzmayr.BaseNTypes.Tests
{
    public class BaseNCoderTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BaseNCoder_CreateWithEmptyAlphabetString_ThrowsArgumentNullException(string alphabet) 
        {
            Assert.Throws<ArgumentNullException>(() => new BaseNCoder(alphabet));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        [InlineData(17)]
        [InlineData(256)]
        public void BaseNCoder_CreateWithInvalidAlphabetStringLength_ThrowsArgumentException(int alphabetLength) 
        {
            var alphabet = new string(Enumerable.Repeat('A', alphabetLength).ToArray());

            Assert.Throws<ArgumentException>(() => new BaseNCoder(alphabet));
        }

        private BaseNCoder CreateSut() 
        {
            return new BaseNCoder("1234567890123456");
        }

        [Fact]
        public void BaseNCoder_InvokeEncodingWithNullByteArray_ReturnsEmptyString() 
        {
            var sut = CreateSut();

            var result = sut.Encode(null);

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void BaseNCoder_InvokeEncodingWithEmptyByteArray_ReturnsEmptyString() 
        {
            var sut = CreateSut();

            var result = sut.Encode(Array.Empty<byte>());

            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void BaseNCoder_InvokeDecodingWithNullOrEmptyString_ReturnsEmptyByteArray(string stringToDecode) 
        {
            var sut = CreateSut();

            var result = sut.Decode(stringToDecode);

            Assert.Empty(result);
        }
    }
}
