namespace Infrastructure.Repository
{
    using Application.Interfaces;
    using Domain.Entities;
    using Infrastructure.Persistence;

    public class PersonalSettingsRepository : Repository<PersonalSettings>, IPersonalSettingsRepository
    {
        public PersonalSettingsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
