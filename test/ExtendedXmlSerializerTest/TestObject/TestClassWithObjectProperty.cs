using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    public class TestClassWithObjectProperty
    {
		[XmlElement]
		public object TestProperty { get; set; }
    }
}
