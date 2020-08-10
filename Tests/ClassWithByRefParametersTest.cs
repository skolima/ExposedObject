// Author:
// Manuel Josupeit-Walter (info@josupeit.com)
//
// (C) 2011 Cognifide
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using ExposedObject;
using TestSubjects;
using Xunit;

namespace Tests
{
    public class ClassWithByRefParametersTest
    {
        [Fact]
        public void PublicMethodTest()
        {
            var exposed = Exposed.From(new ClassWithByRefParameters());

            var param1 = 123;
            string param2 = null;
            var param3 = 2937842L;
            byte param4 = 111;

            int result = exposed.PublicMethod(param1, ref param2, ref param3, ref param4);

            Assert.Equal(0, result);
            Assert.Equal("2937842", param2);
            Assert.Equal(123, param4);
        }

        [Fact]
        public void ProtectedMethodTest()
        {
            var exposed = Exposed.From(new ClassWithByRefParameters());

            var param1 = 123;
            string param2 = null;
            var param3 = 2937842L;
            byte param4 = 111;

            int result = exposed.ProtectedMethod(param1, ref param2, ref param3, ref param4);

            Assert.Equal(0, result);
            Assert.Equal("2937842", param2);
            Assert.Equal(123, param4);
        }
    }
}