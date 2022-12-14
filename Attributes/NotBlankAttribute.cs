using System.ComponentModel.DataAnnotations;

namespace ValidationFramework.Attributes
{
    public class NotBlankAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().IndexOf(" ") == -1;
        }
    }
}
