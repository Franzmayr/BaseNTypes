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

using System.Linq;
using Xunit;

namespace Franzmayr.BaseNTypes.Tests
{
    using Franzmayr.BaseNTypes.Validate;
    
    public class BaseNValidatorTests 
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 0)]
        [InlineData("MY======", 1)]
        [InlineData("1 ", 1)]
        public void Base16Validator_IsValid_ReturnsCorrectResult(string base16EncodedString, int expectedErrorCount) 
        {
            var sut = new Base16Validator(base16EncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 2)]
        [InlineData("MY======", 0)]
        [InlineData("MZXQ====", 0)]
        [InlineData("MZXW6===", 0)]
        [InlineData("MZXW6YQ=", 0)]
        [InlineData("MZXW6YTB", 0)]
        [InlineData("MZXW6YTBOI======", 0)]
        [InlineData("MZXW1YQ=", 1)]
        [InlineData("MZXW6Y==", 1)]
        [InlineData("MZX=====", 1)]
        public void Base32Validator_IsValid_ReturnsCorrectResult(string base32EncodedString, int expectedErrorCount) 
        {
            var sut = new Base32Validator(base32EncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 2)]
        [InlineData("CO======", 0)]
        [InlineData("CPNG====", 0)]
        [InlineData("CPNMU===", 0)]
        [InlineData("CPNMUOG=", 0)]
        [InlineData("CPNMUOJ1", 0)]
        [InlineData("CPNMUOJ1E8======", 0)]
        [InlineData("CPNMUOJX", 1)]
        [InlineData("CPNMUO==", 1)]
        [InlineData("CPN=====", 1)]
        public void Base32HexValidator_IsValid_ReturnsCorrectResult(string base32HexEncodedString, int expectedErrorCount) 
        {
            var sut = new Base32HexValidator(base32HexEncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 2)]
        [InlineData("Fo==", 0)]
        [InlineData("Foo=", 0)]
        [InlineData("F/+b", 0)]
        [InlineData("F===", 1)]
        [InlineData("Foöb", 1)]
        public void Base64Validator_IsValid_ReturnsCorrectResult(string base64EncodedString, int expectedErrorCount) 
        {
            var sut = new Base64Validator(base64EncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 2)]
        [InlineData("Fo==", 0)]
        [InlineData("Foo=", 0)]
        [InlineData("F-_b", 0)]
        [InlineData("F===", 1)]
        [InlineData("F/ob", 1)]
        public void Base64UrlValidator_IsValid_ReturnsCorrectResult(string base64UrlEncodedString, int expectedErrorCount) 
        {
            var sut = new Base64UrlValidator(base64UrlEncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("F", 0)]
        [InlineData("Fo", 0)]
        [InlineData("Fo==", 1)]
        [InlineData("Foo=", 1)]
        [InlineData("Foo", 0)]
        [InlineData("F-_b", 0)]
        [InlineData("FooBa", 0)]
        [InlineData("Foöb", 1)]
        [InlineData("F/ob", 1)]
        public void Base64JwsValidator_IsValid_ReturnsCorrectResult(string base64JwsEncodedString, int expectedErrorCount) 
        {
            var sut = new Base64JwsValidator(base64JwsEncodedString);

            var result = sut.Errors.Count();

            Assert.Equal(expectedErrorCount, result);
        }

    }
}
