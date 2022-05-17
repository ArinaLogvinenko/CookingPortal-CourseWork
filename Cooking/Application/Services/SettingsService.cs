namespace Application.Services
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using DTO;
    using Interfaces;
    using Domain.Entities;

    public class SettingsService : ISettingsService
    {
        private readonly INotificationSettingsRepository notificationSettingsRepository;
        private readonly IPersonalSettingsRepository personalSettingsRepository;
        private readonly IMapper mapper;

        public SettingsService(INotificationSettingsRepository notificationSettingsRepository, IPersonalSettingsRepository personalSettingsRepository, IMapper mapper)
        {
            this.notificationSettingsRepository = notificationSettingsRepository;
            this.personalSettingsRepository = personalSettingsRepository;
            this.mapper = mapper;
        }

        public async Task<SettingsDTO> GetSettings(int id)
        {
            try
            {
                var notificationSettings = await notificationSettingsRepository.FindAsync(t => t.UserId == id);
                var personalSettings = await personalSettingsRepository.FindAsync(t => t.UserId == id);
                var map = mapper.Map<SettingsDTO>(notificationSettings);
                return mapper.Map(personalSettings, map);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUserSettings(int id, SettingsDTO settingsDTO)
        {
            try
            {
                var notificationSettings = await notificationSettingsRepository.FindAsync(t => t.UserId == id);
                var personalSettings = await personalSettingsRepository.FindAsync(t => t.UserId == id);
                if (notificationSettings == null || personalSettings == null)
                {
                    return;
                }

                notificationSettings = mapper.Map<SettingsDTO, NotificationSettings>(settingsDTO);
                personalSettings = mapper.Map<SettingsDTO, PersonalSettings>(settingsDTO);
                await notificationSettingsRepository.Update(notificationSettings);
                await personalSettingsRepository.Update(personalSettings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
