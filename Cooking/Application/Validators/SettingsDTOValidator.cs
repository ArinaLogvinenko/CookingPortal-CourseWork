namespace Application.Validators
{
    using FluentValidation;
    using Application.DTO;

    public class SettingsDTOValidator : AbstractValidator<SettingsDTO>
    {
        public SettingsDTOValidator()
        {
            RuleFor(s => s.FollowerSeeFollowers).NotNull();
            RuleFor(s => s.FollowerSeeSavedRecipe).NotNull();
            RuleFor(s => s.PushLikeNotify).NotNull();
            RuleFor(s => s.PushNewFollowerNotify).NotNull();
            RuleFor(s => s.PushNewMessageNotify).NotNull();
            RuleFor(s => s.TimeZone).NotNull();
        }
    }
}
