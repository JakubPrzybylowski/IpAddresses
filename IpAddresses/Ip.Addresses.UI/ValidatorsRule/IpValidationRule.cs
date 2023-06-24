using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ip.Addresses.UI.ViewModels.ValidatorsRule
{
    internal class IpValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Regular expression pattern for IP address validation
            string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

            Regex regex = new Regex(pattern);

            bool isValid = regex.IsMatch(value.ToString());
            if (!isValid)
            {
                return new ValidationResult(false, "Please provide correct IP Address");
            }
            return new ValidationResult(true, null);
        }
    }
}
