using System.Diagnostics.CodeAnalysis;
using ValidationFramework.Attributes;

namespace ValidationFramework.Validations
{
    public class ValidatorType
    {
        public enum Attribute
        {
            NONE = -1,
            EMAIL,
            NOT_NULL,
            NOT_BLANK,
            PHONE,
            REGEX,
            DOB,
        }
        private static Dictionary<Type, Attribute> mapAttributes = new Dictionary<Type, Attribute>()
        {
            { typeof(EmailValidationAttribute) ,  Attribute.EMAIL },
            { typeof(NotNullCustomAttribute) ,  Attribute.NOT_NULL },
            { typeof(NotBlankAttribute) ,  Attribute.NOT_BLANK },
            { typeof(PhoneValidationAttribute), Attribute.PHONE },
            { typeof(RegexCheckingAttribute), Attribute.REGEX },
            { typeof(DoBValidationAttribute), Attribute.DOB },
        };

        public static int getType(Type attributeType)
        {
            Attribute result;
            bool valid = mapAttributes.TryGetValue(attributeType, out result);
            if (!valid)
            {
                return (int)Attribute.NONE;
            }
            return (int)result;
        }
    }
}
