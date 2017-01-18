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

namespace Franzmayr.BaseNTypes
{
    using Validate;

    /// <summary>  
    /// Represents Base32 extended hex encoded data specified in <see cref="https://tools.ietf.org/html/rfc4648#page-10" />
    /// </summary>  
    public class Base32Hex : BaseN
    {
        protected const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
        
        /// <summary>  
        /// Returns the default Decoding/Encoding instance for Base32Hex Objects
        /// </summary>  
        public readonly static BaseNCoder Coder = new BaseNCoder(Alphabet);
        protected override Func<byte[], string> DefaultEncodingFunction => Coder.Encode;
        protected override Func<string, byte[]> DefaultDecodingFunction => Coder.Decode;

        /// <summary>  
        /// Create a Base32 extended hex encoded representation from an other BaseN representation
        /// </summary>  
        /// <param name="baseN">An other BaseN instance (i. e. Base16)</param>
        public Base32Hex(BaseN baseN) : base(baseN) {}

        /// <summary>  
        /// Create a Base32 extended hex encoded representation from a byte array
        /// </summary>  
        /// <param name="inArray">Any byte array (can also be null or empty)</param>
        public Base32Hex(byte[] inArray) : base(inArray) {}

        /// <summary>  
        /// Create a Base32 extended hex encoded representation from base32 hex encoded string
        /// </summary>  
        /// <param name="base32HexEncodedString">A empty, null or valid Base32 extended hex encoded string</param>
        public Base32Hex(string base32HexEncodedString) : base(base32HexEncodedString) {}

        protected override BaseNValidator Validate(string base32HexEncodedString)
        {
            return new Base32HexValidator(base32HexEncodedString);
        }
    }
}