using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ValidationFramework.Attributes;
using ValidationFramework.Validations;

namespace ValidationFramework.Validators
{
    public class NotNullValidator : ValidatorStrategy
    {
        protected override string getMessage(PropertyInfo property)
        {
            setAttribute(property);
            return _attribute.ErrorMessage;
        }

        protected override bool invalid(PropertyInfo property, object value)
        {
            return string.IsNullOrEmpty(value.ToString().Trim());
        }

        protected override void setAttribute(PropertyInfo property)
        {
            Object[] attributes = property.GetCustomAttributes(false);
            foreach (Object attribute in attributes)
            {
                NotNullCustomAttribute notNullValidation = attribute as NotNullCustomAttribute;
                if (notNullValidation != null)
                {
                    _attribute = notNullValidation;
                    return;
                }
            }
        }
    }
}
