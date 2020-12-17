using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace StockViewerUI.Converter
{
    public class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                bool positiveChange = (bool)value;
                if (positiveChange)
                {
                    return new SolidColorBrush(Colors.DarkGreen);
                }
                return new SolidColorBrush(Colors.DarkRed);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new SolidColorBrush(Colors.Black);
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
