using RyaScape.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace RyaScape.Converters
{
    internal class SkillToImageConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            if (!Enum.TryParse<SkillType>(value.ToString(), out var attachmentType)) return string.Empty;

            return $"/RyaScape;component/Resources/07skill-icons/{attachmentType}-icon.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
