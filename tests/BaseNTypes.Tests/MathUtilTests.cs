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
using Franzmayr.Utils;
using Xunit;

namespace Franzmayr.BaseNTypes.Tests
{
    public class MathUtilTests
    {
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(6, 8, 2)]
        [InlineData(8, 6, 2)]
        [InlineData(5, 8, 1)]
        [InlineData(8, 5, 1)]
        [InlineData(30, 21, 3)]
        [InlineData(21, 30, 3)]
        public void GreatestCommonDivisor_ReturnsExpectedValue(int number1, int number2, int expected)
        {
            Assert.Equal(expected, MathUtils.GreatestCommonDivisor(number1, number2));
        }

        [Fact]
        public void GreatestCommonDivisor_WithZeroNumber2_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathUtils.GreatestCommonDivisor(5, 0));
        }
    }
}