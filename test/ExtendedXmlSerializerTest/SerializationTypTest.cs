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
using System.IO;
using ExtendedXmlSerialization.Test.TestObject;
using Xunit;

namespace ExtendedXmlSerialization.Test
{
    public class SerializationTypTest : BaseTest
    {
        [Fact]
        public void ClassPrimitiveTypes()
        {
            var obj = new TestClassPrimitiveTypes();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassPrimitiveTypes.xml", obj);
            CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void ClassPrimitiveTypesNullable()
        {
            var obj = new TestClassPrimitiveTypesNullable();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassPrimitiveTypesNullable.xml", obj);
            CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void ClassPrimitiveTypesNullableSetNull()
        {
            var obj = new TestClassPrimitiveTypesNullable();
            obj.InitNull();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassPrimitiveTypesNullableSetNull.xml", obj);
            CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void ClassWithList()
        {
            var obj = new TestClassWithList();
            obj.Init();
			CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassWithList.xml", obj);
			//CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void ClassWithHashSet()
        {
            var obj = new TestClassWithHashSet();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassWithHashSet.xml", obj);
            //CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void TestClassWithListWithClass()
        {
            var obj = new TestClassWithListWithClass();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassWithListWithClass.xml", obj);
//            CheckCompatibilityWithDefaultSerializator(obj);
        }


        [Fact]
        public void TestClassPropIsInterface()
        {
            var obj = new TestClassPropIsInterface();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassPropIsInterface.xml", obj);
            //CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void TestClassGuid()
        {
            var obj = new TestClassGuid();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassGuid.xml", obj);
            CheckCompatibilityWithDefaultSerializator(obj);
        }

        [Fact]
        public void TestClassTimeSpan()
        {
            var obj = new TestClassTimeSpan();
            obj.Init();

            CheckSerializationAndDeserialization("ExtendedXmlSerializerTest.Resources.TestClassTimeSpan.xml", obj);
            CheckCompatibilityWithDefaultSerializator(obj);
        }
    }
}
