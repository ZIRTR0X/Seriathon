using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using static Sérieathon.converter.NavProfil;

namespace Sérieathon.converter
{
    class func2WindowPartConverterProfil : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Etat e = (Etat)value;
            return NavProfil.ProfilUC[e]();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
