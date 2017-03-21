using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    public class TestClassWithObjectProperty
    {
		[XmlElement]
		public object TestProperty { get; set; }
    }

	public class TestParentClassWithoutXmlElementAttribute
	{
		public TestChildClass TestChildClass1 { get; set; }

		public TestChildClass TestChildClass2 { get; set; }
	}

	public class TestParentClassWithXmlElementAttribute
	{
		[XmlElement]
		public TestChildClass TestChildClass1 { get; set; }

		[XmlElement]
		public TestChildClass TestChildClass2 { get; set; }
	}

	public class TestChildClass
	{
		[XmlElement]
		public int Something { get; set; }
	}
}
