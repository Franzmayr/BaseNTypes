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

using System.Collections;
using System.Collections.Generic;

namespace Franzmayr.BaseNTypes.Tests
{
    public class Base64RfcTestPatterns : IEnumerable<object[]>
    {
        // IETF RFC 4648 Test Patterns (https://tools.ietf.org/html/rfc4648)
        private IEnumerable<object[]> Patterns
        {
            get
            {
                yield return new object[] {"", ""};
                yield return new object[] {"f", "Zg=="};
                yield return new object[] {"fo", "Zm8="};
                yield return new object[] {"foo", "Zm9v"};
                yield return new object[] {"foob", "Zm9vYg=="};
                yield return new object[] {"fooba", "Zm9vYmE="};
                yield return new object[] {"foobar", "Zm9vYmFy"};
            }
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Patterns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
