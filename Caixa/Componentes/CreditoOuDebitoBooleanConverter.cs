using System;
using System.Windows.Data;

namespace Caixa.Componentes
{
    public class CreditoOuDebitoBooleanConverter : IValueConverter
	{
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            return (value.ToString().ToLower()) switch
            {
                "Crédito" => true,
                "Débito" => false,
                _ => false,
            };
        }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool boolean)
			{
				if (boolean == true)
					return "Crédito";
				else
					return "Débito";
			}
			return "Débito";
		}
	}
}
