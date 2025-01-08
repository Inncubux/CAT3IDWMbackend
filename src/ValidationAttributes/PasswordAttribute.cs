using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API.src.ValidationAttributes
{
    public class PasswordAttribute: ValidationAttribute
    {
        private readonly int _minLength;

    public PasswordAttribute(int minLength)
    {
        _minLength = minLength;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str)
            {
                if (str.Length < _minLength)
                {
                    return new ValidationResult($"The field must be at least {_minLength} characters long.");
                }

                if (!Regex.IsMatch(str, @"\d"))
                {
                    return new ValidationResult("The field must contain at least one number.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid input.");
        }
    }
}