using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FinancialControl.Utils.Converters
{
    /// <summary>
    /// Converter for using in Entry fields for masked input of currency.
    /// <b>The binded property must be of type decimal, and must invoke the
    /// PropertyChangedEventArgs event whenever the value is changed, so that the desired mask behavior is kept.</b>
    /// </summary>
    public class CurrencyConverter : IValueConverter
    {
        //"N", new CultureInfo("pt-BR",false)
        public object Convert(object Value, Type targetType, object parameter, CultureInfo culture)
        {
            if(Value is null) { Value = "0"; }

            return Decimal.Parse(Value.ToString()).ToString("N", new CultureInfo("pt-BR", false));
        }

        public object ConvertBack(object Value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(Value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        }
    }
}
