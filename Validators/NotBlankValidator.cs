using System.Reflection;
using ValidationFramework.Attributes;
using ValidationFramework.Validations;

namespace ValidationFramework.Validators
{
    public class NotBlankValidator : ValidatorStrategy
    {
        protected override string getMessage(PropertyInfo property)
        {
            setAttribute(property);
            return _attribute.ErrorMessage;
        }

        protected override bool invalid(PropertyInfo property, object value)
        {
            return value.ToString().IndexOf(' ') > -1;
        }

        protected override void setAttribute(PropertyInfo property)
        {
            Object[] attributes = property.GetCustomAttributes(false);
            foreach (Object attribute in attributes)
            {
                NotBlankAttribute notBlankValidation = attribute as NotBlankAttribute;
                if (notBlankValidation != null)
                {
                    _attribute = notBlankValidation;
                    return;
                }
            }
        }
    }
}
