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
using System.Linq;

namespace Franzmayr.BaseNTypes
{
    using Validate;

    /// <summary>  
    /// Represents the common BaseN implementation
    /// </summary>  
    public abstract class BaseN
    {
        protected BaseN(BaseN baseN) : this(baseN?.DecodedBytes ?? null)
        {
        }

        protected BaseN(byte[] inArray)
        {
            _decodedBytes = inArray;
        }

        protected BaseN(string baseNEncodedString)
        {
            var validationResult = Validate(baseNEncodedString);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.First());
            _encodedString = baseNEncodedString;
        }

        private Func<byte[], string> _optionalEncodingFunction;
        /// <summary>  
        /// Returns a valid Encode function.
        /// Sets an optional Encode function. If no function is specified, the default encode function will be used
        /// </summary>  
        public Func<byte[], string> Encode
        {
            get 
            {
                if (OptionalEncodingIsSpecified) return _optionalEncodingFunction;
                if (DefaultEncodingIsSpecified) return DefaultEncodingFunction;
                return IfNoEncodingSpecified => "";
            }
            set
            {
                _optionalEncodingFunction = value;
            }
            
        }

        private bool OptionalEncodingIsSpecified => _optionalEncodingFunction != null;
        private bool DefaultEncodingIsSpecified => DefaultEncodingFunction != null;

        private Func<string, byte[]> _optionalDecodingFunction;
        /// <summary>  
        /// Returns a valid Decode function.
        /// Sets an optional Decode function. If no function is specified, the default decode function will be used
        /// </summary>  
        public Func<string, byte[]> Decode
        {
            get 
            {
                if (OptionalDecodingIsSpecified) return _optionalDecodingFunction;
                if (DefaultDecodingIsSpecified) return DefaultDecodingFunction;
                return IfNoDecodingSpecified => new byte[] {};
            }
            set
            {
                _optionalDecodingFunction = value;
            }
            
        }
        private bool OptionalDecodingIsSpecified => _optionalDecodingFunction != null;
        private bool DefaultDecodingIsSpecified => DefaultDecodingFunction != null;

        protected virtual BaseNValidator Validate(string baseNEncodedString)
        {
            return new BaseNValidator("");
        }
        
        protected abstract Func<byte[], string> DefaultEncodingFunction { get; }
        protected abstract Func<string, byte[]> DefaultDecodingFunction { get; }

        private string _encodedString = null;
        private string EncodedString 
        { 
            get 
            { 
                if (EncodingIsRequired) DoEncoding();
                return _encodedString;
            }
        }
        private bool EncodingIsRequired => _encodedString == null;
        private void DoEncoding()
        {
            if (NoDataToEncode)
                SetEncodedStringTo(string.Empty); 
            else
                SetEncodedStringTo(Encode(_decodedBytes)); 
        }
        private bool NoDataToEncode => (_decodedBytes == null) || (_decodedBytes.Length == 0);
        private void SetEncodedStringTo(string value)
        {
            _encodedString = value ?? "";
        }

        private byte[] _decodedBytes = null;
        /// <summary>  
        /// Returns the decoded byte array from the concrete implementation
        /// </summary>  
        public byte[] DecodedBytes 
        {
            get 
            { 
                if (DecodingIsRequired) DoDecoding();
                return _decodedBytes;
            }
        }
        private bool DecodingIsRequired => _decodedBytes == null;
        private void DoDecoding()
        {
            if (NoDataToDecode)
                SetDecodedByteArrayTo(new byte[] {});
            else
                SetDecodedByteArrayTo(Decode(_encodedString));
        }
        private bool NoDataToDecode => string.IsNullOrEmpty(_encodedString);
        private void SetDecodedByteArrayTo(byte[] value)
        {
            _decodedBytes = value ?? new byte[] {};
        }

        /// <summary>  
        /// Returns the encoded string specified in the concrete implementation
        /// </summary>  
        public override string ToString() 
        {
            return EncodedString;
        }
    }
}