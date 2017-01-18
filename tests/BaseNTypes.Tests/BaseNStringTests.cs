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
    public class BaseNTests
    {
        private BaseNTestDummy CreateSut(byte[] bytes, bool defaultCoderEnabled = false)
        {
            BaseNTestDummy.DefaultCoderEnabled = defaultCoderEnabled;
            return new BaseNTestDummy(bytes);
        }

        private BaseNTestDummy CreateSut(BaseN baseNString, bool defaultCoderEnabled = false)
        {
            BaseNTestDummy.DefaultCoderEnabled = defaultCoderEnabled;
            return new BaseNTestDummy(baseNString);
        }

        private BaseNTestDummy CreateSut(string encodedString, bool defaultCoderEnabled = false)
        {
            BaseNTestDummy.DefaultCoderEnabled = defaultCoderEnabled;
            return new BaseNTestDummy(encodedString);
        }

        [Fact]
        public void BaseN_CreateWithNullByteArray_ReturnsEmptyString() 
        {
            var sut = CreateSut((byte[]) null);

            Assert.Equal(string.Empty, sut.ToString());
        }

        [Fact]
        public void BaseN_CreateWithNullByteArray_ReturnsEmptyDecodedBytes() 
        {
            var sut = CreateSut((byte[]) null);

            Assert.Empty(sut.DecodedBytes);
        }

        [Fact]
        public void BaseN_CreateWithEmptyArray_ReturnsEmptyString() 
        {
            var sut = CreateSut(Array.Empty<byte>());

            Assert.Equal(string.Empty, sut.ToString());
        }

        [Fact]
        public void BaseN_CreateWithNullBaseNStringObject_ReturnsEmptyString() 
        {
            var sut = CreateSut((BaseN) null);

            Assert.Equal(string.Empty, sut.ToString());
        }

        [Fact]
        public void BaseN_CreateWithNullBaseNStringObject_ReturnsEmptyDecodedBytes() 
        {
            var sut = CreateSut((BaseN) null);

            Assert.Empty(sut.DecodedBytes);
        }

        [Fact]
        public void BaseN_CreateWithNullString_ReturnsEmptyString() 
        {
            var sut = CreateSut((string) null);

            Assert.Equal(string.Empty, sut.ToString());
        }

        [Fact]
        public void BaseN_CreateWithNullString_ReturnsEmptyDecodedBytes() 
        {
            var sut = CreateSut((string) null);

            Assert.Empty(sut.DecodedBytes);
        }

        [Fact]
        public void BaseN_CreateWithoutDefaultEncoder_EncodeWithEmptyEncoder() 
        {
            var sut = CreateSut(BaseNTestDummy.TestBytes);

            var result = sut.ToString();

            Assert.Equal(string.Empty, result);
            Assert.Null(sut.LastEncoderByteArrayParameter);
        }

        [Fact]
        public void BaseN_CreateWithoutDefaultDecoder_DecodeWithEmptyDecoder() 
        {
            var sut = CreateSut(BaseNTestDummy.TestString);

            var result = sut.DecodedBytes;

            Assert.Empty(result);
            Assert.Null(sut.LastDecoderStringParameter);
        }

        [Fact]
        public void BaseN_CreateWithDefaultEncoder_EncodeWithDefaultEncoder() 
        {
            var sut = CreateSut(BaseNTestDummy.TestBytes, true);

            var result = sut.ToString();

            Assert.Equal(BaseNTestDummy.TestString, result);
            Assert.Equal(BaseNTestDummy.TestBytes, sut.LastEncoderByteArrayParameter);
        }

        [Fact]
        public void BaseN_CreateWithDefaultDecoder_DecodeWithDefaultDecoder() 
        {
            var sut = CreateSut(BaseNTestDummy.TestString, true);

            var result = sut.DecodedBytes;

            Assert.Equal(BaseNTestDummy.TestBytes, result);
            Assert.Equal(BaseNTestDummy.TestString, sut.LastDecoderStringParameter);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BaseN_CreateWithOptionalEncoder_EncodeWithOptionalEncoder(bool defaultCoderEnabled) 
        {
            var bytesToEncode = new byte[] { 102, 103, 104 };
            var expected = "OptionalEncoderResult";
            var sut = CreateSut(bytesToEncode, defaultCoderEnabled);
            byte[] lastEncoderParameter = null;
            sut.Encode = x => { lastEncoderParameter = x; return expected; };

            var result = sut.ToString();

            Assert.Equal(expected, result);
            Assert.Equal(bytesToEncode, lastEncoderParameter);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BaseN_CreateWithOptionalDecoder_DecodeWithOptionalDecoder(bool defaultCoderEnabled) 
        {
            var stringToDecode = "Optional_DecoderParameter";
            var expected = new byte[] { 102, 103, 104 };
            var sut = CreateSut(stringToDecode, defaultCoderEnabled);
            string lastDecoderParameter = null;
            sut.Decode = x => { lastDecoderParameter = x; return expected; };

            var result = sut.DecodedBytes;

            Assert.Equal(expected, result);
            Assert.Equal(stringToDecode, lastDecoderParameter);
        }
    }
}
