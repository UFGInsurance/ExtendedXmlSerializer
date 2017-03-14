﻿// MIT License
// 
// Copyright (c) 2016 Wojciech Nagórski
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    public interface ITestInterface
    {
		[XmlElement]
		string PropFromInterface { get; set; }
    }

    public class TestClassInheritInterface1 : ITestInterface
    {
		[XmlElement]
		public string PropFromInterface { get; set; }
    }

    public class TestClassInheritInterface2 : ITestInterface
    {
		[XmlElement]
		public string PropFromInterface { get; set; }
		[XmlElement]
		public string PropFromClass { get; set; }
    }

    public class TestClassPropIsInterface 
    {
        public void Init()
        {
            PropInter1 = new TestClassInheritInterface1 {PropFromInterface = "PropInter1"};
            PropInter2 = new TestClassInheritInterface2 { PropFromInterface = "PropInter2", PropFromClass = "PropClass1"};
        }

		[XmlElement]
		public ITestInterface PropInter1 { get; set; }
		[XmlElement]
		public ITestInterface PropInter2 { get; set; }
    }
}
