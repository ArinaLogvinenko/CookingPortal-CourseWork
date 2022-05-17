namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class EditUserDTOValidator : AbstractValidator<EditUserDTO>
    {
        public EditUserDTOValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.FullName).Matches(@"^[a-zA-Z\s\-]+$").Length(2, 20);
            RuleFor(e => e.Status).MaximumLength(15);
            RuleFor(e => e.Password).Length(5, 26).Equal(e => e.ConfirmPassword);
        }
    }
}
