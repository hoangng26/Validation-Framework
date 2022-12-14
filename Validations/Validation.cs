namespace ValidationFramework.Validations
{
    public class Validation
    {
        private Validation() { }
        private static Validation _instance;
        public static Validation getInstance()
        {
            if (_instance == null)
            {
                _instance = new Validation();
            }
            return _instance;
        }
        public HashSet<IConstraintViolation> validate(Object obj)
        {
            HashSet<IConstraintViolation> validations = new HashSet<IConstraintViolation>();
            var clazz = obj.GetType();
            var props = clazz.GetProperties();

            foreach (var prop in props)
            {
                Object[] attributes = prop.GetCustomAttributes(false);

                foreach (var attribute in attributes)
                {
                    int validatorType = ValidatorType.getType(attribute.GetType());
                    if (validatorType == -1)
                    {
                        continue;
                    }

                    ValidatorStrategy validator = ValidatorFactory.create(validatorType);
                    if (validator == null)
                    {
                        continue;
                    }

                    IConstraintViolation constraint = validator.validate(prop, obj);
                    if (!constraint.isValid())
                    {
                        validations.Add(constraint);
                    }
                }
            }
            return validations;
        }
    }
}
