// The encoding and decoding routine is based on 
// Albireo.Base32 (https://github.com/kappa7194/base32/blob/master/Albireo.Base32/Base32.cs)
// which also is licensed under the MIT License
// Copyright © 2014 Albireo
//
// Adapted Code:
//
// Copyright (C) 2016-2017 Franzmayr Peter (peter@franzmayr.at)
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
using Franzmayr.Utils;

namespace Franzmayr.BaseNTypes
{
    
    /// <summary>  
    /// Implements an universal encoding and decoding algorithm in managed code
    /// </summary>  
    public class BaseNCoder
    {
        private const char PaddingChar = '=';
        private const byte BitsPerByte = 8;

        /// <summary>  
        /// Returns the Alphabet used for encoding and decoding
        /// </summary>  
        public readonly string Alphabet;

        private readonly byte _bitsPerChar;
        private readonly byte _leftoverBits;

        /// <summary>  
        /// Returns whether padding is enabled or not
        /// </summary>  
        public readonly bool Padding;

        public BaseNCoder(string alphabet, bool padding = true)
        {
            if (string.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentNullException(nameof(alphabet));
            if (alphabet.Length < 16)
                throw new ArgumentException($"Length of {nameof(alphabet)} must have at least 16 chars");
            if (alphabet.Length > 128)
                throw new ArgumentException($"Length of {nameof(alphabet)} cannot exceed 128 chars");
            _bitsPerChar = GetBitsPerChar(alphabet);
            _leftoverBits = (byte) (BitsPerByte - _bitsPerChar);
            Alphabet = alphabet;
            Padding = padding;
        }

        private static byte GetBitsPerChar(string alphabet)
        {
            var bits = Math.Log(alphabet.Length) / Math.Log (2);
            if (bits % 1 != 0)
                throw new ArgumentException($"Length of {nameof(alphabet)} must be a power of 2");
            return (byte) bits;
        }

        public string Encode(byte[] bytesToEncode)
        {
            if ((bytesToEncode == null) || (bytesToEncode.Length == 0))
                return "";
            byte charsPerBlock = (byte) (BitsPerByte / MathUtils.GreatestCommonDivisor(BitsPerByte, _bitsPerChar));
            int blocksPerByte = BitsPerByte / charsPerBlock;
            byte bitMask = (byte) (Alphabet.Length - 1);
            var alphabetChars = Alphabet.ToCharArray();
            var result = new char[(int) Math.Ceiling(bytesToEncode.Length * blocksPerByte / (double) _bitsPerChar) * charsPerBlock];
            var position = 0;
            byte workingByte = 0, remainingBits = _bitsPerChar;

            foreach (var currentByte in bytesToEncode)
            {
                workingByte = (byte) (workingByte | (currentByte >> (BitsPerByte - remainingBits)));
                result[position++] = alphabetChars[workingByte];

                if (remainingBits < _leftoverBits)
                {
                    workingByte = (byte) ((currentByte >> (_leftoverBits - remainingBits)) & bitMask);
                    result[position++] = alphabetChars[workingByte];
                    remainingBits += _bitsPerChar;
                }

                remainingBits -= _leftoverBits;
                workingByte = (byte) ((currentByte << remainingBits) & bitMask);
            }

            if (position != result.Length)
            {
                result[position++] = alphabetChars[workingByte];
            }

            while (position < result.Length)
            {
                result[position++] = PaddingChar;
            }

            if (Padding)
                return new String(result);
            return new String(result).TrimEnd(PaddingChar);
        }

        public virtual byte[] Decode(string stringToDecode)
        {
            if (string.IsNullOrEmpty(stringToDecode))
                return new byte[] {};
            stringToDecode = stringToDecode.TrimEnd(PaddingChar);
            var bytes = new byte[stringToDecode.Length * _bitsPerChar / BitsPerByte];
            var position = 0;
            byte workingByte = 0, bitsRemaining = BitsPerByte;

            foreach (var currentChar in stringToDecode.ToCharArray())
            {
                int bitMask;
                var currentCharPosition = Alphabet.IndexOf(currentChar);

                if (bitsRemaining > _bitsPerChar)
                {
                    bitMask = currentCharPosition << (bitsRemaining - _bitsPerChar);
                    workingByte = (byte) (workingByte | bitMask);
                    bitsRemaining -= _bitsPerChar;
                }
                else
                {
                    bitMask = currentCharPosition >> (_bitsPerChar - bitsRemaining);
                    workingByte = (byte) (workingByte | bitMask);
                    bytes[position++] = workingByte;
                    workingByte = (byte) (currentCharPosition << (_leftoverBits + bitsRemaining));
                    bitsRemaining += _leftoverBits;
                }
            }
            return bytes;
        }
    }
}