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
    /// Validates a base64 encoded string which is passed to the constructor
    /// </summary>  
    public class Base64Validator : BaseNValidator
    {
        protected override int LengthDivider => 4;
        protected override string LengthErrorMessage => "base64EncodedString: Invalid length for a Base64 encoded string (must be a multiple of 4 chars)";
        protected override string ValidCharMatch => @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
        protected override string CharMatchErrorMessage => "base64EncodedString: Invalid chars for a Base64 encoded string (only A-Z, a-z, 1-9, +, /, and one or two fillcharacter '=' at end allowed)";
        
        public Base64Validator(string base64EncodedString) : base(base64EncodedString) {}
    }
}