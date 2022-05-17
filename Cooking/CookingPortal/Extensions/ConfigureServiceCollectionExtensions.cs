namespace CookingPortal.Extensions
{
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using Application.Validators;

    public static class ConfigureServiceCollectionExtensions
    {
        /// <summary>This method connects validators.</summary>
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddUserDTOValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EditUserDTOValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SettingsDTOValidator>());
        }
    }
}
