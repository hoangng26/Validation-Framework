using System.ComponentModel.DataAnnotations;
using ValidationFramework.Services;

namespace ValidationFramework.Attributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ValidationService.isPhoneNumber(value.ToString());
        }
    }
}
