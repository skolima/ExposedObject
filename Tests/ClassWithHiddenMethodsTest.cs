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

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

using ExposedObject;

using TestSubjects;

using Xunit;

namespace Tests
{
    public class ClassWithHiddenMethodsTest
    {
        [Fact]
        public void FieldTest()
        {
            dynamic exposed = Exposed.From(new ClassWithHiddenMethods());
            string password = exposed.password;
            Assert.Null(password);

            exposed.password = "TestValue";
            password = exposed.password;
            Assert.Equal("TestValue", password);
        }

        [Fact]
        public void MethodTest()
        {
            dynamic exposed = Exposed.New(typeof(ClassWithHiddenMethods));
            string password = exposed.GeneratePassword(8);

            Assert.Equal(password, exposed.Password);
        }

        [Fact]
        public void PropertyTest()
        {
            dynamic exposed = Exposed.From(new ClassWithHiddenMethods());
            int count = exposed.Count;
            Assert.Equal(0, count);

            exposed.Count = 9;
            count = exposed.Count;
            Assert.Equal(9, count);
        }

        [Fact]
        public void ReturnVoidMethodTest()
        {
            dynamic exposed = Exposed.From(new ClassWithHiddenMethods());
            exposed.SetPassword("new test password");

            Assert.Equal("new test password", exposed.password);
        }

        [Fact]
        public void ThreadingSafetySimpleTest()
        {
            var results = new ConcurrentDictionary<int, bool>();
            const int threadsCount = 100;
            var threads = new List<Thread>(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                var thread = new Thread(
                    o =>
                        {
                            var password = o.ToString();
                            var number = (int)o;
                            var exposed = Exposed.From(new ClassWithHiddenMethods());
                            Thread.Sleep(threadsCount - number);
                            exposed.SetPassword(password);
                            Thread.Sleep(threadsCount - number);
                            string read = exposed.Password;
                            results[number] = password == read;
                        });
                threads.Add(thread);
                thread.Start(i);
            }
            for (int i = 0; i < threadsCount; i++)
            {
                threads[i].Join();
                Assert.True(results[i]);
            }
            Assert.Equal(threadsCount, results.Count);
        }
    }
}
