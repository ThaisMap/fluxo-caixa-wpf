using System.Windows.Controls;

namespace Caixa.Componentes
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double i;
            if (double.TryParse(value.ToString().Replace(',','.'), out i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Insira um valor numérico");
        }
    }
}
