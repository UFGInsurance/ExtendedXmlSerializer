using System;
using System.Collections.Generic;
using ExtendedXmlSerialization.Test.TestObject;
using Xunit;

namespace ExtendedXmlSerialization.Test
{
    public class SerializationObjectProperty :BaseTest
    {
        [Fact]
        public void TestClassWithObjectProperty()
        {
            var obj = new List<TestClassWithObjectProperty>
            {
                new TestClassWithObjectProperty {TestProperty = 1234},
                new TestClassWithObjectProperty {TestProperty = "Abc"},
                new TestClassWithObjectProperty {TestProperty = new Guid(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 2)}
            };
            //CheckCompatibilityWithDefaultSerializator(obj);
            CheckSerializationAndDeserializationByXml(
 @"<ArrayOfTestClassWithObjectProperty>
  <TestClassWithObjectProperty type=""ExtendedXmlSerialization.Test.TestObject.TestClassWithObjectProperty"">
    <TestProperty type=""System.Int32"">1234</TestProperty>
  </TestClassWithObjectProperty>
  <TestClassWithObjectProperty type=""ExtendedXmlSerialization.Test.TestObject.TestClassWithObjectProperty"">
    <TestProperty type=""System.String"">Abc</TestProperty>
  </TestClassWithObjectProperty>
  <TestClassWithObjectProperty type=""ExtendedXmlSerialization.Test.TestObject.TestClassWithObjectProperty"">
    <TestProperty type=""System.Guid"">00000001-0002-0003-0405-060708090002</TestProperty>
  </TestClassWithObjectProperty>
</ArrayOfTestClassWithObjectProperty>", obj);
        }

	    [Fact]
	    public void TestParentClassWithXmlElementAttribute()
	    {
		    var obj = new TestParentClassWithXmlElementAttribute
		    {
			    TestChildClass1 = new TestChildClass {Something = 123},
			    TestChildClass2 = new TestChildClass {Something = 456}
		    };

			CheckSerializationAndDeserializationByXml(TestParentClassWithXmlElementAttributeXml, obj);
	    }

	    private const string TestParentClassWithXmlElementAttributeXml = @"<TestParentClassWithXmlElementAttribute type=""ExtendedXmlSerialization.Test.TestObject.TestParentClassWithXmlElementAttribute"">
  <TestChildClass1 type=""ExtendedXmlSerialization.Test.TestObject.TestChildClass"">
    <Something>123</Something>
  </TestChildClass1>
  <TestChildClass2 type=""ExtendedXmlSerialization.Test.TestObject.TestChildClass"">
    <Something>456</Something>
  </TestChildClass2>
</TestParentClassWithXmlElementAttribute>";

		[Fact]
		public void TestParentClassWithoutXmlElementAttribute()
		{
			var obj = new TestParentClassWithoutXmlElementAttribute
			{
				TestChildClass1 = new TestChildClass { Something = 123 },
				TestChildClass2 = new TestChildClass { Something = 456 }
			};

			CheckSerializationAndDeserializationByXml(TestParentClassWithoutXmlElementAttributeXml, obj);
		}

		private const string TestParentClassWithoutXmlElementAttributeXml = @"<TestParentClassWithoutXmlElementAttribute type=""ExtendedXmlSerialization.Test.TestObject.TestParentClassWithoutXmlElementAttribute"">
  <TestChildClass1 type=""ExtendedXmlSerialization.Test.TestObject.TestChildClass"">
    <Something>123</Something>
  </TestChildClass1>
  <TestChildClass2 type=""ExtendedXmlSerialization.Test.TestObject.TestChildClass"">
    <Something>456</Something>
  </TestChildClass2>
</TestParentClassWithoutXmlElementAttribute>";

        [Fact]
        public void TestChildClassInheritOverriddenProperty()
        {
            var obj = new TestChildClassInheritOverriddenProperty { Answer = "Test" };

            CheckSerializationAndDeserializationByXml(TestChildClassInheritOverriddenPropertyXml, obj);
        }

        private const string TestChildClassInheritOverriddenPropertyXml =
            @"<TestChildClassInheritOverriddenProperty type=""ExtendedXmlSerialization.Test.TestObject.TestChildClassInheritOverriddenProperty""><Answer>Test</Answer></TestChildClassInheritOverriddenProperty>";
    }
}
