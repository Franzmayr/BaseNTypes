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
    /// Represents Base64 URL and Filename safe encoded data in Jws-Representation (without padding chars)
    /// </summary>  
    public class Base64Jws : BaseN
    {
        protected const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-_";
        
        /// <summary>  
        /// Returns the default Decoding/Encoding instance for Base64Jws Objects
        /// </summary>  
        public readonly static BaseNCoder Coder = new BaseNCoder(Alphabet, false);
        protected override Func<byte[], string> DefaultEncodingFunction => Coder.Encode;
        protected override Func<string, byte[]> DefaultDecodingFunction => Coder.Decode;

        /// <summary>  
        /// Create a Base64 URL safe encoded Jws representation from an other BaseN representation
        /// </summary>  
        /// <param name="baseN">An other BaseN instance (i. e. Base64Url)</param>
        public Base64Jws(BaseN baseN) : base(baseN) {}

        /// <summary>  
        /// Create a Base64 URL safe encoded Jws representation from a byte array
        /// </summary>  
        /// <param name="inArray">Any byte array (can also be null or empty)</param>
        public Base64Jws(byte[] inArray) : base(inArray) {}

        /// <summary>  
        /// Create a Base64 URL safe encoded Jws representation from base64 jws encoded string
        /// </summary>  
        /// <param name="base64JwsEncodedString">A empty, null or valid Base64 URL safe encoded string without padding-chars</param>
        public Base64Jws(string base64JwsEncodedString) : base(base64JwsEncodedString) {}

        protected override BaseNValidator Validate(string base64JwsEncodedString)
        {
            return new Base64JwsValidator(base64JwsEncodedString);
        }
    }
}