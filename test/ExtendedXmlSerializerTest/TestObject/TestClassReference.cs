// MIT License
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
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    public class TestClassReferenceWithDictionary
    {
		[XmlElement]
		public IReference Parent { get; set; }

		[XmlElement]
		public Dictionary<int, IReference> All { get; set; }
    }

    public class TestClassReferenceWithList
    {
		[XmlElement]
		public IReference Parent { get; set; }

		[XmlElement]
		public List<IReference> All { get; set; }
    }
    public interface IReference
    {
		[XmlElement]
		int Id { get; set; }
    }
    public class TestClassReference : IReference
    {
		[XmlElement]
		public int Id { get; set; }
		[XmlElement]
		public IReference CyclicReference { get; set; }
		[XmlElement]
		public IReference ObjectA { get; set; }

		[XmlElement]
		public IReference ReferenceToObjectA { get; set; }

		[XmlElement]
		public List<IReference> Lists { get; set; }
    }

    public class TestClassConcreteReferenceWithDictionary
    {
		[XmlElement]
		public TestClassConcreteReference Parent { get; set; }

		[XmlElement]
		public Dictionary<int, TestClassConcreteReference> All { get; set; }
    }


    public class TestClassConcreteReferenceWithList
    {
		[XmlElement]
		public TestClassConcreteReference Parent { get; set; }

		[XmlElement]
		public List<TestClassConcreteReference> All { get; set; }
    }

    public class TestClassConcreteReference : IReference
    {
		[XmlElement]
		public int Id { get; set; }

		[XmlElement]
		public TestClassConcreteReference CyclicReference { get; set; }

		[XmlElement]
		public TestClassConcreteReference ObjectA { get; set; }

		[XmlElement]
		public TestClassConcreteReference ReferenceToObjectA { get; set; }

		[XmlElement]
		public List<TestClassConcreteReference> Lists { get; set; }
    }
}
