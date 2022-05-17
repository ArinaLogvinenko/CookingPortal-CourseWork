namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(e => e.Id).NotNull();
            RuleFor(e => e.FullName).Matches(@"^[a-zA-Z\s\-]+$").Length(2, 20);
            RuleFor(e => e.Status).MaximumLength(20);
        }
    }
}
