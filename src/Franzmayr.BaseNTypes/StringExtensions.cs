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
    public static class StringExtensions
    {
        private static byte[] EncodedBytes(this string sourceString, Encoding encoding = null)
        {
            return (encoding ?? Encoding.UTF8).GetBytes(sourceString ?? "");
        }

        /// <summary>  
        /// Creates a Base16 instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base16 encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base16encodedString = "fooba".ToBase16().ToString();
        /// </code>
        /// Result: "666F6F6261"
        /// </example>
        public static Base16 ToBase16(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase16();
        }

        /// <summary>  
        /// Creates a Base32 instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base32 encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base32encodedString = "fooba".ToBase32().ToString();
        /// </code>
        /// Result: "MZXW6YTB"
        /// </example>
        public static Base32 ToBase32(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase32();
        }

        /// <summary>  
        /// Creates a Base32Hex instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base32 extended hex encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base32HexEncodedString = "fooba".ToBase32Hex().ToString();
        /// </code>
        /// Result: "CPNMUOJ1"
        /// </example>
        public static Base32Hex ToBase32Hex(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase32Hex();
        }

        /// <summary>  
        /// Creates a Base64 instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base64 encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base64EncodedString = "fooba".ToBase64().ToString();
        /// </code>
        /// Result: "Zm9vYmE="
        /// </example>
        public static Base64 ToBase64(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase64();
        }

        /// <summary>  
        /// Creates a Base64 instance from an unicode string by using the specified encoding and the integrated .Net-Encoding function Convert.ToBase64String
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base64 encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base64EncodedString = "fooba".ToBase64String().ToString();
        /// </code>
        /// Result: "Zm9vYmE="
        /// </example>
        public static Base64 ToBase64String(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase64String();
        }

        /// <summary>  
        /// Creates a Base64Url instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base64 Url safe encoded string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base64UrlEncodedString = "fooba".ToBase64Url().ToString();
        /// </code>
        /// Result: "Zm9vYmE="
        /// </example>
        public static Base64Url ToBase64Url(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase64Url();
        }

        /// <summary>  
        /// Creates a Base64Jws instance from an unicode string by using the specified encoding
        /// </summary>  
        /// <param name="encoding">The desired encoding. If no encoding is specified, the UTF8 encoding will be used</param>
        /// <example> 
        /// This example shows how to create a Base64 Url safe encoded jws string representation from the unicode string "fooba" by using the default encoding UTF8
        /// <code>
        /// var base64JwsEncodedString = "fooba".ToBase64Jws().ToString();
        /// </code>
        /// Result: "Zm9vYmE"
        /// </example>
        public static Base64Jws ToBase64Jws(this string sourceString, Encoding encoding = null)
        {
            return sourceString.EncodedBytes(encoding).ToBase64Jws();
        }

        /// <summary>  
        /// Creates a Base16 instance from a Base16 encoded string
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base16 instance from the Base16 encoded string "666F6F6261"
        /// <code>
        /// var base16Instance = "666F6F6261".AsBase16();
        /// </code>
        /// </example>
        public static Base16 AsBase16(this string sourceString)
        {
            return new Base16(sourceString);
        }

        /// <summary>  
        /// Creates a Base32 instance from a Base32 encoded string
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32 instance from the Base32 encoded string "MZXW6YTB"
        /// <code>
        /// var base32Instance = "MZXW6YTB".AsBase32();
        /// </code>
        /// </example>
        public static Base32 AsBase32(this string sourceString)
        {
            return new Base32(sourceString);
        }

        /// <summary>  
        /// Creates a Base32Hex instance from a Base32 enhanced hex encoded string
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base32Hex instance from the Base32 enhanced hex encoded string "CPNMUOJ1"
        /// <code>
        /// var base32HexInstance = "CPNMUOJ1".AsBase32Hex();
        /// </code>
        /// </example>
        public static Base32Hex AsBase32Hex(this string sourceString)
        {
            return new Base32Hex(sourceString);
        }

        /// <summary>  
        /// Creates a Base64 instance from a Base64 encoded string
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 instance from the Base64 encoded string "Zm9vYmE="
        /// <code>
        /// var base64Instance = "Zm9vYmE=".AsBase64();
        /// </code>
        /// </example>
        public static Base64 AsBase64(this string sourceString)
        {
            return new Base64(sourceString);
        }

        /// <summary>  
        /// Creates a Base64 instance from a Base64 encoded string using the integrated .Net-Decoding function Convert.FromBase64String
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64 instance from the Base64 encoded string "Zm9vYmE="
        /// <code>
        /// var base64Instance = "Zm9vYmE=".AsBase64();
        /// </code>
        /// </example>
        public static Base64 AsBase64String(this string sourceString)
        {
            return new Base64(sourceString) { Decode = Convert.FromBase64String };
        }

        /// <summary>  
        /// Creates a Base64Url instance from a Base64 url safe encoded string
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64Url instance from the Base64 url safe encoded string "Zm9vYmE="
        /// <code>
        /// var base64UrlInstance = "Zm9vYmE=".AsBase64Url();
        /// </code>
        /// </example>
        public static Base64Url AsBase64Url(this string sourceString)
        {
            return new Base64Url(sourceString);
        }

        /// <summary>  
        /// Creates a Base64Jws instance from a Base64 url safe encoded jws string representation
        /// </summary>  
        /// <example> 
        /// This example shows how to create a Base64Jws instance from the Base64 url safe encoded jws string "Zm9vYmE"
        /// <code>
        /// var base64JwsInstance = "Zm9vYmE".AsBase64Jws();
        /// </code>
        /// </example>
        public static Base64Jws AsBase64Jws(this string sourceString)
        {
            return new Base64Jws(sourceString);
        }
    }
}