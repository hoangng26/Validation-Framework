using System.Reflection;
using ValidationFramework.Attributes;
using ValidationFramework.Validations;

namespace ValidationFramework.Validators
{
    public class DoBValidator : ValidatorStrategy
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
                DoBValidationAttribute doBValidation = attribute as DoBValidationAttribute;
                if (doBValidation != null)
                {
                    _attribute = doBValidation;
                    return;
                }
            }
        }
    }
}
