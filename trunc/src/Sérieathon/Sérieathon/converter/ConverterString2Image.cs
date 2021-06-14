using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;

namespace Sérieathon.converter
{
    public class ConverterString2Image : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string nomImage = (value as string);

            if (string.IsNullOrWhiteSpace(nomImage))
            {
                nomImage = "void.jpg";
            }

            string dossierImage = Path.Combine(Directory.GetCurrentDirectory(), "image\\affiche\\");
            string cheminImage = Path.Combine(dossierImage, nomImage);

            return new Uri(cheminImage, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
