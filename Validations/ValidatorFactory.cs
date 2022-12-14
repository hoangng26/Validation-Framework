using ValidationFramework.Validators;

namespace ValidationFramework.Validations
{
    public class ValidatorFactory
    {
        private static Dictionary<int, ValidatorStrategy> validatorDictionary = new Dictionary<int, ValidatorStrategy>();
        public static ValidatorStrategy create(int validatorType)
        {
            ValidatorStrategy validator = null;
            validatorDictionary.TryGetValue(validatorType, out validator);
            if (validator == null)
            {
                switch (validatorType)
                {
                    case (int)ValidatorType.Attribute.EMAIL:
                        validator = new EmailValidator();
                        break;
                    case (int)ValidatorType.Attribute.NOT_NULL:
                        validator = new NotNullValidator();
                        break;
                    case (int)ValidatorType.Attribute.NOT_BLANK:
                        validator = new NotBlankValidator();
                        break;
                    case (int)ValidatorType.Attribute.PHONE:
                        validator = new PhoneValidatior();
                        break;
                    case (int)ValidatorType.Attribute.REGEX:
                        validator = new RegexCheckingValidator();
                        break;
                    case (int)ValidatorType.Attribute.DOB:
                        validator = new DoBValidator();
                        break;
                    default:
                        return validator;
                }
                validatorDictionary.Add(validatorType, validator);
            }
            return validator;
        }
    }
}
