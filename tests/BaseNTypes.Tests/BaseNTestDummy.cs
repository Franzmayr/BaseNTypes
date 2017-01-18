// The MIT License:
//
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

namespace Franzmayr.BaseNTypes.Tests
{
    internal class BaseNTestDummy : BaseN
    {
        internal static readonly byte[] TestBytes = new byte[] { 25, 26, 27 };
        internal const string TestString = "TestString";
        internal static bool DefaultCoderEnabled = false;
        internal string LastDecoderStringParameter = null;
        internal byte[] LastEncoderByteArrayParameter = null;
        protected override Func<byte[], string> DefaultEncodingFunction => GetDefaultEncoder();
        protected override Func<string, byte[]> DefaultDecodingFunction => GetDefaultDecoder();

        private Func<byte[], string> GetDefaultEncoder()
        {
            if (DefaultCoderEnabled)
                return x => { LastEncoderByteArrayParameter = x; return TestString; };
            return null;
        }

        private Func<string, byte[]> GetDefaultDecoder()
        {
            if (DefaultCoderEnabled)
                return x => { LastDecoderStringParameter = x; return TestBytes; };
            return null;
        }

        public BaseNTestDummy(BaseN baseNString) : base(baseNString) {}
        public BaseNTestDummy(byte[] inArray) : base(inArray) {}
        public BaseNTestDummy(string baseNEncodedString) : base(baseNEncodedString) {}
    }
}