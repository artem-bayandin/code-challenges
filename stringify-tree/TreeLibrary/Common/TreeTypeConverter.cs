using System;
using System.ComponentModel;
using System.Globalization;

namespace TreeLibrary.Common
{
    public class TreeTypeConverter<T>
    {
        private readonly TypeConverter Converter;

        public TreeTypeConverter(Type destinationType)
        {
            Converter = TypeDescriptor.GetConverter(destinationType);
        }

        public bool TryParse(string inValue, out T value)
        {
            try
            {
                value = (T)Converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
            }
            catch (ArgumentException ex)
            {
                value = default;
                return false;
            }

            return true;
        }
    }

}
