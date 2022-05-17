namespace Application.Mappings
{
    using AutoMapper;
    using DTO;
    using Domain.Entities;

    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<NotificationSettings, SettingsDTO>();
            CreateMap<PersonalSettings, SettingsDTO>();
        }
    }
}
