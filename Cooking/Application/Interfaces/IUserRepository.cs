namespace Application.Interfaces
{
    using Application.DTO;
    using Domain.Entities;
    using Domain.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetFollowingUsers(int userId);

        Task<List<Message>> GetMessagesAsync();

        Task AddMessageAsync(Message message);

        Task FollowRecipeAuthor(int userId, int authorId);

        Task UnFollowRecipeAuthor(int userId, int authorId);
    }
}
