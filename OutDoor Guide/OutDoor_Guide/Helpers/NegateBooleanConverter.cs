﻿using System;
using Xamarin.Forms;

namespace OutDoor_Guide.Helpers
{
    public class NegateBooleanConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)value);
        }

        #endregion
    }
}
