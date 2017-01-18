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
    public class StringExtensionsAsTests
    {
        private const string TestString = null;

        [Fact]
        public void StringExtensions_AsBase16_WithNullString_ReturnsEmptyBase16String() 
        {
            var result = TestString.AsBase16();

            Assert.IsType<Base16>(result);
            Assert.Empty(result.DecodedBytes);
        }

        [Fact]
        public void StringExtensions_AsBase32_WithNullString_ReturnsEmptyBase32String() 
        {
            var result = TestString.AsBase32();

            Assert.IsType<Base32>(result);
            Assert.Empty(result.DecodedBytes);
        }

        [Fact]
        public void StringExtensions_AsBase32Hex_WithNullString_ReturnsEmptyBase32HexString() 
        {
            var result = TestString.AsBase32Hex();

            Assert.IsType<Base32Hex>(result);
            Assert.Empty(result.DecodedBytes);
        }

        [Fact]
        public void StringExtensions_AsBase64_WithNullString_ReturnsEmptyBase64String() 
        {
            var result = TestString.AsBase64();

            Assert.IsType<Base64>(result);
            Assert.Empty(result.DecodedBytes);
        }

        [Fact]
        public void StringExtensions_AsBase64String_WithNullString_ReturnsEmptyBase64StringWithDotNetDecoder() 
        {
            var result = TestString.AsBase64String();

            Assert.IsType<Base64>(result);
            Assert.Empty(result.DecodedBytes);
            Assert.Equal(Convert.FromBase64String, result.Decode);
        }

        [Fact]
        public void StringExtensions_AsBase64Url_WithNullString_ReturnsEmptyBase64UrlString() 
        {
            var result = TestString.AsBase64Url();

            Assert.IsType<Base64Url>(result);
            Assert.Empty(result.DecodedBytes);
        }

        [Fact]
        public void StringExtensions_AsBase64Jws_WithNullString_ReturnsEmptyBase64JwsString() 
        {
            var result = TestString.AsBase64Jws();

            Assert.IsType<Base64Jws>(result);
            Assert.Empty(result.DecodedBytes);
        }
    }
}
