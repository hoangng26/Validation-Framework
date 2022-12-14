using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ValidationFramework.Validations
{
    public abstract class ValidatorStrategy
    {
        protected ValidationAttribute _attribute = null;
        public IConstraintViolation validate(PropertyInfo prop, Object obj)
        {
            Object value = getValueFromObject(prop, obj);

            IConstraintViolation constraint = createConstraintViolation(prop.Name, value);

            if (invalid(prop, value))
            {
                constraint.setMessage(getMessage(prop));
                constraint.setIsValid(valid: false);
            }

            return constraint;
        }
        private IConstraintViolation createConstraintViolation(string property, Object value)
        {
            IConstraintViolation constraintViolation = new ConstraintViolation();

            constraintViolation.setProperty(property);
            constraintViolation.setValue(value);

            return constraintViolation;
        }
        private Object getValueFromObject(PropertyInfo property, Object obj)
        {
            Object value = property.GetValue(obj);
            return value;
        }
        protected abstract bool invalid(PropertyInfo property, Object value);
        protected abstract String getMessage(PropertyInfo property);
        protected abstract void setAttribute(PropertyInfo property);
    }
}
