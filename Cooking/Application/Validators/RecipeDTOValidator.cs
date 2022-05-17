namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class RecipeDTOValidator : AbstractValidator<RecipeDTO>
    {
        public RecipeDTOValidator()
        {
            RuleFor(r => r.Name).Matches(@"^[a-zA-Z\s\-]+$").MaximumLength(100);
            RuleFor(r => r.Description).MaximumLength(500);
            RuleFor(r => r.Ingredients).MaximumLength(500);
            RuleFor(r => r.ServingTime).MaximumLength(500);
            RuleFor(r => r.NutritionFacts).MaximumLength(500);
        }
    }
}
