﻿using System.Xml.Serialization;

namespace ExtendedXmlSerialization.Test.TestObject
{
    [XmlRoot(ElementName = "TestClass")]
    public class TestClassWithXmlRootAttribute
    {
		[XmlElement]
		public int Id { get; set; }
    }
}
