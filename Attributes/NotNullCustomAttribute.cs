using System.ComponentModel.DataAnnotations;

namespace ValidationFramework.Attributes
{
    public class NotNullCustomAttribute : ValidationAttribute
    {
        public NotNullCustomAttribute() { }
        public override bool IsValid(object value)
        {
            return string.IsNullOrEmpty(value.ToString());
        }
    }
}
