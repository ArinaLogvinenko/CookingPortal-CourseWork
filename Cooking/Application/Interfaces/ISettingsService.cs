namespace Application.Interfaces
{
    using System.Threading.Tasks;
    using DTO;
    using Domain.Entities;

    public interface ISettingsService : IService
    {
        public Task<SettingsDTO> GetSettings(int id);

        public Task UpdateUserSettings(int id, SettingsDTO settingsDTO);
    }
}
