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
using System;
using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    public enum TestEnum
    {
        EnumValue1,
        EnumValue2
    }
    public class TestClassPrimitiveTypes
    {
        public void Init()
        {
            PropString = "TestString";
            PropInt = -1;
            PropuInt = 2234;

            PropDecimal = 3.346m;
            PropDecimalMinValue = decimal.MinValue;
            PropDecimalMaxValue = decimal.MaxValue;

            PropFloat = 7.4432f;
            PropFloatNaN = float.NaN;
            PropFloatPositiveInfinity = float.PositiveInfinity;
            PropFloatNegativeInfinity = float.NegativeInfinity;
            PropFloatMinValue = float.MinValue;
            PropFloatMaxValue = float.MaxValue;

            PropDouble = 3.4234;
            PropDoubleNaN = double.NaN;
            PropDoublePositiveInfinity = double.PositiveInfinity;
            PropDoubleNegativeInfinity = double.NegativeInfinity;
            PropDoubleMinValue = double.MinValue;
            PropDoubleMaxValue = double.MaxValue;

            PropEnum = TestEnum.EnumValue1;
            PropLong = 234234142;
            PropUlong = 2345352534;
            PropShort = 23;
            PropUshort = 2344;
            PropDateTime = new DateTime(2014,01,23);
            PropByte = 23;
            PropSbyte = 33;
            PropChar = 'g';
        }

		[XmlElement]
        public string PropString { get; set; }

		[XmlElement]
		public int PropInt { get; set; }

		[XmlElement]
		public uint PropuInt { get; set; }

		[XmlElement]
		public decimal PropDecimal { get; set; }

		[XmlElement]
		public decimal PropDecimalMinValue { get; set; }

		[XmlElement]
		public decimal PropDecimalMaxValue { get; set; }

		[XmlElement]
		public float PropFloat { get; set; }

		[XmlElement]
		public float PropFloatNaN { get; set; }

		[XmlElement]
		public float PropFloatPositiveInfinity { get; set; }

		[XmlElement]
		public float PropFloatNegativeInfinity { get; set; }

		[XmlElement]
		public float PropFloatMinValue { get; set; }

		[XmlElement]
		public float PropFloatMaxValue { get; set; }

		[XmlElement]
		public double PropDouble { get; set; }

		[XmlElement]
		public double PropDoubleNaN { get; set; }

		[XmlElement]
		public double PropDoublePositiveInfinity { get; set; }

		[XmlElement]
		public double PropDoubleNegativeInfinity { get; set; }

		[XmlElement]
		public double PropDoubleMinValue { get; set; }

		[XmlElement]
		public double PropDoubleMaxValue { get; set; }

		[XmlElement]

		public TestEnum PropEnum { get; set; }

		[XmlElement]
		public long PropLong { get; set; }

		[XmlElement]
		public ulong PropUlong { get; set; }

		[XmlElement]
		public short PropShort { get; set; }

		[XmlElement]
		public ushort PropUshort { get; set; }

		[XmlElement]
		public DateTime PropDateTime { get; set; }

		[XmlElement]
		public byte PropByte { get; set; }

		[XmlElement]
		public sbyte PropSbyte { get; set; }

		[XmlElement]
		public char PropChar { get; set; }
    }
}
