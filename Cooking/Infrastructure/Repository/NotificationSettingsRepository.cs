namespace Infrastructure.Repository
{
    using Application.Interfaces;
    using Domain.Entities;
    using Infrastructure.Persistence;

    public class NotificationSettingsRepository : Repository<NotificationSettings>, INotificationSettingsRepository
    {
        public NotificationSettingsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
