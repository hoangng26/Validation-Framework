using System.ComponentModel.DataAnnotations;
using ValidationFramework.Services;

namespace ValidationFramework.Attributes
{
    public class DoBValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ValidationService.isDateOfBirth((DateTime)value);
        }
    }
}
