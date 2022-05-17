using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class LoginUserDTO
    {
        [MaxLength(15)]
        public string FullName { get; set; }

        [MinLength(5)]
        [MaxLength(26)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FullNameError { get; set; }

        public string PasswordError { get; set; }

        public string EnterError { get; set; }
    }
}
