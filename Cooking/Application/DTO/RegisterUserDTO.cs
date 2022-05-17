using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class RegisterUserDTO
    {
        [MaxLength(15)]
        public string FullName { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(5)]
        [MaxLength(26)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MinLength(5)]
        [MaxLength(26)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string FullNameError { get; set; }

        public string PasswordError { get; set; }

        public string ConfirmPasswordError { get; set; }

        public string EmailError { get; set; }
    }
}
