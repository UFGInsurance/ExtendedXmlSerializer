// MIT License
// 
// Copyright (c) 2016 Wojciech Nag�rski
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
using System.Reflection;
using System.Xml.Serialization;
using ExtendedXmlSerialization.Test.Tools;

namespace ExtendedXmlSerialization.Test
{
    public class BaseTest
    {
        protected ExtendedXmlSerializer Serializer { get; } = new ExtendedXmlSerializer();
#if NET451
        private const string CoreLib = "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
#else
        private const string CoreLib = "System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";
#endif

        private static string SerializeObject(object toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);

                return textWriter.ToString();
            }
        }

        public void CheckCompatibilityWithDefaultSerializator(object obj)
        {
            var standardXml = SerializeObject(obj);
            var obj2 = Serializer.Deserialize(standardXml, obj.GetType());
			var serializedObj = SerializeObject(obj2);
			XmlAssert.AreEqual(standardXml, serializedObj);
        }

        public void CheckSerializationAndDeserialization(string xmlPath, object obj)
        {
            var xml = EmbeddedResources.Get(xmlPath);
            xml = ReplaceVariable(xml);
            XmlAssert.AreEqual(xml, Serializer.Serialize(obj));
            var obj2 = Serializer.Deserialize(xml, obj.GetType());
            XmlAssert.AreEqual(xml, Serializer.Serialize(obj2));
        }

        private static string ReplaceVariable(string xml)
        {
            xml = xml.Replace("[CORELIB]", CoreLib);
            xml = xml.Replace("[EXTENDEDXMLSERIALIZER_VERSION]",
                typeof(ExtendedXmlSerializer).GetTypeInfo().Assembly.GetName().Version.ToString());
            return xml;
        }

        public void CheckSerializationAndDeserializationByXml(string xml, object obj)
        {
            xml = ReplaceVariable(xml);
            var stuff = Serializer.Serialize(obj);
            XmlAssert.AreEqual(xml, stuff);
            var obj2 = Serializer.Deserialize(xml, obj.GetType());
            XmlAssert.AreEqual(xml, Serializer.Serialize(obj2));
        }
    }
}