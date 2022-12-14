using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using ValidationFramework.Attributes;

namespace ValidationFramework.Models
{
    public class User
    {
        [NotNullCustom(ErrorMessage = "Email must not be null")]
        [NotBlank(ErrorMessage = "Email must not have blank")]
        [RegexChecking("^[A-Za-z0-9+_.-]+@(.+)$", ErrorMessage = "Email must be valid")]
        public string? Email { get; set; }

        [NotNullCustom(ErrorMessage = "Password must not be null")]
        [RegexChecking("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,32}$", ErrorMessage = "Password must have between 6 and 32 characters, include uppercase, lowercase, number and special characters")]
        public string? Password { get; set; }

        [PhoneValidation(ErrorMessage = "Phone is not valid")]
        public string? Phone { get; set; }

        [DoBValidation(ErrorMessage = "Date of Birth is not valid")]
        public DateTime DoB { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Email: {Email}\n");
            stringBuilder.Append($"Password: {Password}\n");
            stringBuilder.Append($"Phone: {Phone}\n");
            stringBuilder.Append($"Date of Birth: {DoB}\n");
            return stringBuilder.ToString();
        }
    }
}
