namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class UserRecipeDTOValidator : AbstractValidator<UserRecipeDTO>
    {
        public UserRecipeDTOValidator()
        {
            RuleFor(u => u.FullName).Matches(@"^[a-zA-Z\s\-]+$").Length(2, 20);
            RuleFor(u => u.Status).MaximumLength(20);
            RuleFor(u => u.Name).Matches(@"^[a-zA-Z\s\-]+$").MaximumLength(20);
            RuleFor(u => u.Description).MaximumLength(500);
            RuleFor(u => u.ServingTime).MaximumLength(500);
        }
    }
}
