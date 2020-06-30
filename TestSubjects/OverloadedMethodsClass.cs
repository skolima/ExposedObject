// Author:
// Leszek Ciesielski (skolima@gmail.com)
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

namespace TestSubjects
{
#pragma warning disable CA1812 // Class is never instantiated
    class OverloadedMethodsClass
#pragma warning restore CA1812 // Class is never instantiated
    {
#pragma warning disable CA1822 // Mark members as static
        public string SuperMethod()
#pragma warning restore CA1822 // Mark members as static
        {
            return "SuperMethod";
        }

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1801 // Review unused parameters
        protected string SuperMethod(int var)
#pragma warning restore CA1801 // Review unused parameters
#pragma warning restore CA1822 // Mark members as static
        {
            return "SuperMethod_int";
        }

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1801 // Review unused parameters
        private string SuperMethod(string value)
#pragma warning restore CA1801 // Review unused parameters
#pragma warning restore CA1822 // Mark members as static
        {
            return "SuperMethod_string";
        }
    }
}
