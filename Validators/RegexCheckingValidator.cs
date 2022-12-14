using System.Reflection;
using ValidationFramework.Attributes;
using ValidationFramework.Validations;

namespace ValidationFramework.Validators
{
    public class RegexCheckingValidator : ValidatorStrategy
    {
        protected override string getMessage(PropertyInfo property)
        {
            setAttribute(property);
            return _attribute.ErrorMessage;
        }

        protected override bool invalid(PropertyInfo property, object value)
        {
            setAttribute(property);
            return !_attribute.IsValid(value);
        }

        protected override void setAttribute(PropertyInfo property)
        {
            Object[] attributes = property.GetCustomAttributes(false);
            foreach (Object attribute in attributes)
            {
                RegexCheckingAttribute regexValidation = attribute as RegexCheckingAttribute;
                if (regexValidation != null)
                {
                    _attribute = regexValidation;
                    return;
                }
            }
        }
    }
}
