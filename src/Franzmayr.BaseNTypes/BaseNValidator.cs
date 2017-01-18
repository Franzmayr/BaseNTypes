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
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Franzmayr.BaseNTypes.Validate
{
    public class BaseNValidator
    {
        private readonly List<string> _errors = new List<string>();
        
        public bool IsValid => !_errors.Any();
        public IEnumerable<string> Errors => _errors;

        protected Action<string> ErrorDescription => _errors.Add;

        protected virtual int LengthDivider => 0;
        protected virtual string LengthErrorMessage => "";
        protected virtual string ValidCharMatch => "";
        protected virtual string CharMatchErrorMessage => "";

        public BaseNValidator(string base64EncodedString)
        {
            CheckForValidLength(base64EncodedString, ErrorDescription);
            CheckForValidChars(base64EncodedString, ErrorDescription);
        }

        protected virtual void CheckForValidLength(string baseNEncodedString, Action<string> errorDescription)
        {
            if ((LengthDivider <= 0) || (string.IsNullOrEmpty(LengthErrorMessage)))
                return;
            if ((baseNEncodedString ?? "").Length % 4 == 0)
                return;
            errorDescription(LengthErrorMessage);
        }

        protected virtual void CheckForValidChars(string baseNEncodedString, Action<string> errorDescription)
        {
            if ((string.IsNullOrEmpty(ValidCharMatch)) || (string.IsNullOrEmpty(CharMatchErrorMessage)))
                return;
            if (string.IsNullOrEmpty(baseNEncodedString) ||
                Regex.Match(baseNEncodedString, ValidCharMatch).Success)
                return;
            errorDescription(CharMatchErrorMessage);
        }
    }
}