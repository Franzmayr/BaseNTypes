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
    public class BaseNExtensionsTests
    {
        private static readonly BaseN TestObject = null;

        [Fact]
        public void BaseNExtensions_FromBaseN_WithNullObject_ReturnsEmptyString() 
        {
            var result = TestObject.FromBaseN();

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void BaseNExtensions_ToBase16_WithNullObject_ReturnsEmptyBase16String() 
        {
            var result = TestObject.ToBase16();

            Assert.IsType<Base16>(result);
            Assert.Equal(string.Empty, result.ToString());
        }

        [Fact]
        public void BaseNExtensions_ToBase32_WithNullObject_ReturnsEmptyBase32String() 
        {
            var result = TestObject.ToBase32();

            Assert.IsType<Base32>(result);
            Assert.Equal(string.Empty, result.ToString());
        }

        [Fact]
        public void BaseNExtensions_ToBase32Hex_WithNullObject_ReturnsEmptyBase32HexString() 
        {
            var result = TestObject.ToBase32Hex();

            Assert.IsType<Base32Hex>(result);
            Assert.Equal(string.Empty, result.ToString());
        }

        [Fact]
        public void BaseNExtensions_ToBase64_WithNullObject_ReturnsEmptyBase64String() 
        {
            var result = TestObject.ToBase64();

            Assert.IsType<Base64>(result);
            Assert.Equal(string.Empty, result.ToString());
        }

        [Fact]
        public void BaseNExtensions_ToBase64String_WithNullObject_ReturnsEmptyBase64StringWithDotNetEncoder() 
        {
            var result = TestObject.ToBase64String();

            Assert.IsType<Base64>(result);
            Assert.Equal(string.Empty, result.ToString());
            Assert.Equal(Convert.ToBase64String, result.Encode);
        }

        [Fact]
        public void BaseNExtensions_ToBase64Url_WithNullObject_ReturnsEmptyBase64UrlString() 
        {
            var result = TestObject.ToBase64Url();

            Assert.IsType<Base64Url>(result);
            Assert.Equal(string.Empty, result.ToString());
        }

        [Fact]
        public void BaseNExtensions_ToBase64Jws_WithNullObject_ReturnsEmptyBase64JwsString() 
        {
            var result = TestObject.ToBase64Jws();

            Assert.IsType<Base64Jws>(result);
            Assert.Equal(string.Empty, result.ToString());
        }
    }
}
