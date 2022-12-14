using System.Reflection;
using ValidationFramework.Attributes;
using ValidationFramework.Validations;

namespace ValidationFramework.Validators
{
    public class EmailValidator : ValidatorStrategy
    {
        protected override string getMessage(PropertyInfo property)
        {
            setAttribute(property);
            return _attribute.ErrorMessage;
        }

        protected override bool invalid(PropertyInfo property, object value)
        {
            if (_attribute == null)
            {
                setAttribute(property);
            }
            bool res = _attribute.IsValid(value);
            return !res;
        }

        protected override void setAttribute(PropertyInfo property)
        {
            Object[] attributes = property.GetCustomAttributes(false);
            foreach (Object attribute in attributes)
            {
                EmailValidationAttribute emailValidation = attribute as EmailValidationAttribute;
                if (emailValidation != null)
                {
                    _attribute = emailValidation;
                    return;
                }
            }
        }
    }
}
