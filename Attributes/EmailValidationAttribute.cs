using System.ComponentModel.DataAnnotations;

namespace ValidationFramework.Attributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().IndexOf('@') > -1;
        }
    }
}
