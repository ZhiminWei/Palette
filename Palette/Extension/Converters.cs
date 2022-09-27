using Palette.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Palette.Extension
{
    public class SoilderBrushToRGBStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is SolidColorBrush brush)
            {
                return $"{brush.Color.R},{brush.Color.G},{brush.Color.B}";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                RGBColor rgb = new RGBColor(value?.ToString());
                return rgb;
            }
            catch (Exception ex)
            {
                MessageExtension.Show(ex.Message);
                return null;
            }
        }
    }

    public class SoilderBrushToHSBStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is SolidColorBrush brush)
            {
                RGBColor rgb = new RGBColor(255, brush.Color.R, brush.Color.G, brush.Color.B);

                HSBColor hsb = rgb.Hsb;

                return $"{(int)hsb.H},{(int)(hsb.S * 100)}%,{(int)(hsb.B * 100)}%";
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class HEXStringRestructuringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null && value is SolidColorBrush brush)
            {
                var hex = brush.Color.ToString();

                return hex.Substring(0, 1) + hex.Substring(3, 6);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                RGBColor rgb = new RGBColor(value?.ToString());
                return rgb;
            }
            catch (Exception ex)
            {
                MessageExtension.Show(ex.Message);
                return null;
            }
        }
    }
}
