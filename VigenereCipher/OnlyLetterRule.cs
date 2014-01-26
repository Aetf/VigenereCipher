using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VigenereCipher
{
    class OnlyLetterRule: ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String str = value as String;
            foreach (var c in str)
            {
                if (!Char.IsLetter(c))
                    return new ValidationResult(false, "Only leter is accepted.");
            }

            return new ValidationResult(true, null);
        }
    }
}
