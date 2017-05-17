using RyaScape.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace RyaScape.ViewModel {
  class SkillToImageConverter : MarkupExtension, IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      var attachmentType = (SkillTypes)Enum.Parse(typeof(SkillTypes), value.ToString());

      return string.Format("/RyaScape;component/Resources/07skill-icons/{0}-icon.png", attachmentType);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      throw new NotSupportedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider) {
      return this;
    }
  }
}
