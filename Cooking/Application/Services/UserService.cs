namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using DTO;
    using Interfaces;
    using Domain.Entities;
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ISettingsService settingsService;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, ISettingsService settingsService, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.settingsService = settingsService;
            this.mapper = mapper;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.Id == id);
                return mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetByNamePassword(string name, string password)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.FullName == name && t.Password == password);
                return mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetByName(string name)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.FullName == name);
                return mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetEntityUserByName(string name)
        {
            try
            {
                return await userRepository.FindAsync(t => t.FullName == name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetUsersMightBeFollow(int id, int? count)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.Id == id);
                if (user == null)
                {
                    return null;
                }

                var allUsers = userRepository.GetAll();
                var mightBeFollow = allUsers.Except(user.Following).Except(new List<User>() { user }).OrderByDescending(t => t.Followers.Count);
                if (count == null)
                {
                    return mapper.Map<IOrderedEnumerable<User>, IEnumerable<UserDTO>>(mightBeFollow);
                }
                else
                {
                    return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(mightBeFollow.Take((int)count));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RegisterUser(RegisterUserDTO registerUser)
        {
            try
            {
                var user = mapper.Map<RegisterUserDTO, User>(registerUser);
                user.NotificationSettings = new NotificationSettings();
                user.PersonalSettings = new PersonalSettings()
                {
                    TimeZone = TimeZoneInfo.Utc.DisplayName
                };
                userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddUser(AddUserDTO addUserDTO)
        {
            try
            {
                var user = mapper.Map<AddUserDTO, User>(addUserDTO);
                user.NotificationSettings = new NotificationSettings();
                user.PersonalSettings = new PersonalSettings()
                {
                    TimeZone = TimeZoneInfo.Utc.DisplayName
                };
                userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditUser(EditUserDTO editUserDTO)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.Id == editUserDTO.Id);
                await userRepository.Update(mapper.Map<EditUserDTO, User>(editUserDTO, user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> GetFollowingUsers(int userId)
        {
            var users = await userRepository.GetFollowingUsers(userId);
            return mapper.Map<List<UserDTO>>(users);    
        }

        public async Task<List<Message>> GetMessageAsync()
        {
            return await userRepository.GetMessagesAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await userRepository.AddMessageAsync(message);
        }

        public async Task FollowAuthor(int userId, int authorId)
        {
            await userRepository.FollowRecipeAuthor(userId, authorId);
        }

        public async Task UnFollowRecipeAuthor(int userId, int authorId)
        {
            try
            {
                await userRepository.UnFollowRecipeAuthor(userId, authorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
