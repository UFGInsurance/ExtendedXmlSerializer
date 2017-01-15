// MIT License
// 
// Copyright (c) 2016 Wojciech Nag�rski
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

using System.Collections.Generic;
using ExtendedXmlSerialization.Conversion.ElementModel;
using ExtendedXmlSerialization.Conversion.Read;
using ExtendedXmlSerialization.Conversion.TypeModel;
using ExtendedXmlSerialization.Conversion.Write;
using ExtendedXmlSerialization.Core.Sources;

namespace ExtendedXmlSerialization.Conversion.Legacy
{
    sealed class ConverterOptions : IParameterizedSource<IConverter, IEnumerable<IConverterOption>>
    {
        public static ConverterOptions Default { get; } = new ConverterOptions();
        ConverterOptions() {}

        public IEnumerable<IConverterOption> Get(IConverter parameter)
        {
            yield return KnownConverters.Default;
            yield return new ConverterOption<IDictionaryElement>(new LegacyDictionaryTypeConverter(parameter));
            yield return new ConverterOption<IArrayElement>(new ArrayTypeConverter(parameter));
            yield return new ConverterOption<ICollectionElement>(new LegacyEnumerableTypeConverter(parameter)); 
            yield return new ConverterOption<IActivatedElement>(new LegacyInstanceTypeConverter(parameter));
        }

        sealed class LegacyEnumerableTypeConverter : TypeConverter
        {
            public LegacyEnumerableTypeConverter(IConverter converter)
                : base(
                    IsCollectionTypeSpecification.Default, new ListReader(converter),
                    new EnumerableBodyWriter(LegacyElementNames.Default, converter)
                ) {}
        }
    }
}