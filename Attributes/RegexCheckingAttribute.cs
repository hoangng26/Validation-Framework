using System.ComponentModel.DataAnnotations;
using ValidationFramework.Services;

namespace ValidationFramework.Attributes
{
    public class RegexCheckingAttribute : ValidationAttribute
    {
        public string _pattern { get; set; }
        public RegexCheckingAttribute(string pattern)
        {
            _pattern = pattern;
        }
        public override bool IsValid(object value)
        {
            return ValidationService.checkRegex(value.ToString(), _pattern);
        }
    }
}
