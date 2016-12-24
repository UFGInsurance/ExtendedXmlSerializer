﻿// MIT License
// 
// Copyright (c) 2016 Wojciech Nagórski
//                    Michael DeMond
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
using System.Xml;
using ExtendedXmlSerialization.Configuration.Write;
using ExtendedXmlSerialization.Core;
using ExtendedXmlSerialization.Model.Write;

namespace ExtendedXmlSerialization.Processing.Write
{
    public class Writer : IWriter
    {
        private readonly XmlWriter _writer;
        private readonly IObjectSerializer _serializer;
        private readonly ITypeDefinitions _definitions;
        private readonly INamespaces _name;
        private readonly IDisposable _end;

        public Writer(XmlWriter writer, INamespaces name, IObjectSerializer serializer, ITypeDefinitions definitions)
        {
            _writer = writer;
            _serializer = serializer;
            _definitions = definitions;
            _name = name;
            _end = new DelegatedDisposable(End);
        }

        private void End() => _writer.WriteEndElement();

        public void Emit(object instance) => _writer.WriteString(_serializer.Serialize(instance));

        public IDisposable New(IElement element)
        {
            switch (_writer.WriteState)
            {
                case WriteState.Start:
                    _writer.WriteStartDocument();
                    break;
            }

            var ns = _name.Get(element.Instance.Type);
            _writer.WriteStartElement(element.Name, ns);
            return _end;
        }

        public void Emit(IElement element)
        {
            var ns = _name.Get(element.Instance.Type);
            var value = element.Instance.Value;
            var type = value as Type;
            if (type != null)
            {
                var definition = _definitions.Get(type);
                _writer.WriteStartAttribute(element.Name, ns);
                _writer.WriteQualifiedName(definition.Name, _name.Get(definition.Type));
                _writer.WriteEndAttribute();
                return;
            }
            var text = _serializer.Serialize(value);
            _writer.WriteAttributeString(element.Name, ns, text);
        }

        public void Dispose() => _writer.Dispose();
    }
}