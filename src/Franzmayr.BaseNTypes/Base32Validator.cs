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

namespace Franzmayr.BaseNTypes.Validate
{
    /// <summary>  
    /// Validates a base32 encoded string which is passed to the constructor
    /// </summary>  
    public class Base32Validator : BaseNValidator
    {
        protected override int LengthDivider => 8;
        protected override string LengthErrorMessage => "base32EncodedString: Invalid length for a Base32 encoded string (must be a multiple of 8 chars)";
        protected override string ValidCharMatch => @"^(?:[A-Z2-7]{8})*(?:[A-Z2-7]{2}={6}|[A-Z2-7]{4}={4}|[A-Z2-7]{5}={3}|[A-Z2-7]{7}=)?$";
        protected override string CharMatchErrorMessage => "base32EncodedString: Invalid chars for a Base32 encoded string (only A-Z, 2-7 and 1, 3, 4 or 6 fillcharacter '=' at end allowed)";

        public Base32Validator(string base32EncodedString) : base(base32EncodedString) {}
    }
}