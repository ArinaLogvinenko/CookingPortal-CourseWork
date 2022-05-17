namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class AddUserDTOValidator : AbstractValidator<AddUserDTO>
    {
        public AddUserDTOValidator()
        {
            RuleFor(a => a.FullName).NotNull().Matches(@"^[a-zA-Z\s\-]+$").Length(2, 20);
            RuleFor(a => a.Email).NotNull().EmailAddress();
            RuleFor(a => a.Password).NotNull().Length(5, 26).Equal(a => a.ConfirmPassword);
        }
    }
}
