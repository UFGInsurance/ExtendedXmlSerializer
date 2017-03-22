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

    public abstract class TestAbstractBase
    {
        private string _answer = nameof(TestAbstractBase);

        [XmlElement]
        public virtual string Answer
        {
            get { return this._answer; }
            set
            {
                // Do nothing 
            }
        }
    }

    public abstract class TestAbstractBaseWithOverriddenProperty : TestAbstractBase
    {
        public override string Answer { get; set; }
    }

    public class TestChildClassInheritOverriddenProperty : TestAbstractBaseWithOverriddenProperty
    {
    }
}