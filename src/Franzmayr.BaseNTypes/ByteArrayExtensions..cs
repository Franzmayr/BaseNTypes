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
    public static class ByteArrayExtensions
    {
        /// <summary>  
        /// Creates a Base16 instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base16 instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base16Instance = byteArray.ToBase16();
        /// </code>
        /// </example>
        public static Base16 ToBase16(this byte[] bytesToEncode)
        {
            return new Base16(bytesToEncode);
        }

        /// <summary>  
        /// Creates a Base32 instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32 instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base32Instance = byteArray.ToBase32();
        /// </code>
        /// </example>
        public static Base32 ToBase32(this byte[] bytesToEncode)
        {
            return new Base32(bytesToEncode);
        }

        /// <summary>  
        /// Creates a Base32Hex instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32Hex instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base32HexInstance = byteArray.ToBase32Hex();
        /// </code>
        /// </example>
        public static Base32Hex ToBase32Hex(this byte[] bytesToEncode)
        {
            return new Base32Hex(bytesToEncode);
        }

        /// <summary>  
        /// Creates a Base64 instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base64Instance = byteArray.ToBase64();
        /// </code>
        /// </example>
        public static Base64 ToBase64(this byte[] bytesToEncode)
        {
            return new Base64(bytesToEncode);
        }

        /// <summary>  
        /// Creates a Base64 instance from a byte array using the integrated .Net-Encoding function Convert.ToBase64String
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base64Instance = byteArray.ToBase64String();
        /// </code>
        /// </example>
        public static Base64 ToBase64String(this byte[] bytesToEncode)
        {
            return new Base64(bytesToEncode) { Encode = Convert.ToBase64String };
        }

        /// <summary>  
        /// Creates a Base64Url instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64Url instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base64UrlInstance = byteArray.ToBase64Url();
        /// </code>
        /// </example>
        public static Base64Url ToBase64Url(this byte[] bytesToEncode)
        {
            return new Base64Url(bytesToEncode);
        }

        /// <summary>  
        /// Creates a Base64Jws instance from a byte array
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64Jws instance from the byte array { 125, 126 }
        /// <code>
        /// var byteArray = new byte[] { 125, 126 };
        /// var base64JwsInstance = byteArray.ToBase64Jws();
        /// </code>
        /// </example>
        public static Base64Jws ToBase64Jws(this byte[] bytesToEncode)
        {
            return new Base64Jws(bytesToEncode);
        }
    }
}