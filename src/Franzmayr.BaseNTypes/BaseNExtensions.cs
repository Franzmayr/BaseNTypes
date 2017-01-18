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
using System.Text;

namespace Franzmayr.BaseNTypes
{
    /// <summary>  
    /// BaseN Extension Methods for simpler and more readable usage
    /// </summary>  
    public static class BaseNExtensions
    {
        /// <summary>  
        /// Returns an unicode string from a BaseN instance by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        public static string FromBaseN(this BaseN baseN, Encoding encoding = null)
        {
            var bytes = baseN?.DecodedBytes ?? new byte[] {};
            return (encoding ?? Encoding.UTF8).GetString(bytes, 0, bytes.Length);
        }

        /// <summary>  
        /// Creates a Base16 instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base16 encoded string from the Base64 encoded string "Zm9vYg==" by using extension methods
        /// <code>
        /// var base16encodedString = "Zm9vYg==".AsBase64().ToBase16().ToString();
        /// </code>
        /// Result: "666F6F62"
        /// </example>
        public static Base16 ToBase16(this BaseN baseN)
        {
            return new Base16(baseN);
        }

        /// <summary>  
        /// Creates a Base32 instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32 encoded string from the Base64 encoded string "Zm9vYg==" by using extension methods
        /// <code>
        /// var base32encodedString = "Zm9vYg==".AsBase64().ToBase32().ToString();
        /// </code>
        /// Result: "MZXW6YQ="
        /// </example>
        public static Base32 ToBase32(this BaseN baseN)
        {
            return new Base32(baseN);
        }

        /// <summary>  
        /// Creates a Base32Hex instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32 extended hex encoded string from the Base64 encoded string "Zm9vYg==" by using extension methods
        /// <code>
        /// var base32HexEncodedString = "Zm9vYg==".AsBase64().ToBase32Hex().ToString();
        /// </code>
        /// Result: "CPNMUOG="
        /// </example>
        public static Base32Hex ToBase32Hex(this BaseN baseN)
        {
            return new Base32Hex(baseN);
        }

        /// <summary>  
        /// Creates a Base64 instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 encoded string from the Base32 encoded string "MZXW6YQ=" by using extension methods
        /// <code>
        /// var base64encodedString = "MZXW6YQ=".AsBase32().ToBase64().ToString();
        /// </code>
        /// Result: "Zm9vYg=="
        /// </example>
        public static Base64 ToBase64(this BaseN baseN)
        {
            return new Base64(baseN);
        }

        /// <summary>  
        /// Creates a Base64 instance from any desired BaseN instance using the integrated .Net-Encoding function Convert.ToBase64String
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 encoded string from the Base32 encoded string "MZXW6YQ=" by using extension methods
        /// <code>
        /// var base64encodedString = "MZXW6YQ=".AsBase32().ToBase64String().ToString();
        /// </code>
        /// Result: "Zm9vYg=="
        /// </example>
        public static Base64 ToBase64String(this BaseN baseN)
        {
            return new Base64(baseN) { Encode = Convert.ToBase64String };
        }

        /// <summary>  
        /// Creates a Base64Url instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 url safe encoded string from the Base64 encoded string "F+/bFw==" by using extension methods
        /// <code>
        /// var base64UrlencodedString = "F+/bFw==".AsBase64().ToBase64Url().ToString();
        /// </code>
        /// Result: "F-_bFw=="
        /// </example>
        public static Base64Url ToBase64Url(this BaseN baseN)
        {
            return new Base64Url(baseN);
        }

        /// <summary>  
        /// Creates a Base64Jws instance from any desired BaseN instance
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 url safe encoded jws string representation from the Base64 encoded string "F+/bFw==" by using extension methods
        /// <code>
        /// var base64JwsencodedString = "F+/bFw==".AsBase64().ToBase64Jws().ToString();
        /// </code>
        /// Result: "F-_bFw"
        /// </example>
        public static Base64Jws ToBase64Jws(this BaseN baseN)
        {
            return new Base64Jws(baseN);
        }
    }
}