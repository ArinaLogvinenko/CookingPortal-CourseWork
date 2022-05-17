namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;
    using DTO;

    public interface IUserService : IService
    {
        public Task<UserDTO> GetUser(int id);

        public Task<IEnumerable<UserDTO>> GetUsersMightBeFollow(int id, int? count);

        public Task<UserDTO> GetByNamePassword(string name, string password);

        public Task<UserDTO> GetByName(string name);

        public Task RegisterUser(RegisterUserDTO registerUser);

        public Task AddUser(AddUserDTO addUserDTO);

        public Task EditUser(EditUserDTO editUserDTO);

        Task<List<UserDTO>> GetFollowingUsers(int userId);

        Task<List<Message>> GetMessageAsync();

        Task AddMessageAsync(Message message);

        Task<User> GetEntityUserByName(string name);

        Task FollowAuthor(int userId, int authorId);

        Task UnFollowRecipeAuthor(int userId, int authorId);
    }
}
