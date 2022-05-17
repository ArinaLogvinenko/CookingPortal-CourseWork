using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class EditUserDTO
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string FullName { get; set; }

        [MaxLength(15)]
        public string Status { get; set; }

        public string Image { get; set; }

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
    }
}
