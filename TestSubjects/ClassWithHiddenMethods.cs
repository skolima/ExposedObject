﻿// Author:
// Leszek Ciesielski (skolima@gmail.com)
// Manuel Josupeit-Walter (info@josupeit.com)
//
// (C) 2013 Cognifide
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

using System;
using System.Globalization;

namespace TestSubjects
{
#pragma warning disable CA1708 // Identifiers should differ by more than case
    public class ClassWithHiddenMethods
#pragma warning restore CA1708 // Identifiers should differ by more than case
    {
        private int _count;

#pragma warning disable IDE0051 // Remove unused private members
        private int Count { get { return _count; } set { _count = value; } }
#pragma warning restore IDE0051 // Remove unused private members

#pragma warning disable CA1051 // Do not declare visible instance fields
        protected string password;
#pragma warning restore CA1051 // Do not declare visible instance fields

        protected string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        protected string GeneratePassword(int seed)
        {
            var random = new Random(seed);
#pragma warning disable CA5394 // Do not use insecure randomness
            return password = random.Next().ToString(CultureInfo.InvariantCulture);
#pragma warning restore CA5394 // Do not use insecure randomness
        }

#pragma warning disable IDE0051 // Remove unused private members
        private void SetPassword(string newPassword)
#pragma warning restore IDE0051 // Remove unused private members
        {
            password = newPassword;
        }
    }
}
