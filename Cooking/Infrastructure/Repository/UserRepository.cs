namespace Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Application.Interfaces;
    using Domain.Entities;
    using Infrastructure.Persistence;
    using System.Linq;
    using Application.DTO;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> expression)
        {
            return await Context.Users.Include(t => t.Following).Include(t => t.Followers).FirstOrDefaultAsync(expression);
        }

        public IEnumerable<User> GetAll()
        {
            return Context.Users.Include(t => t.Following).Include(t => t.Followers);
        }

        public User GetByNamePassword(string name, string password)
        {
            return Context.Users.FirstOrDefault(u => u.Email == name && u.Password == password);
        }

        public async Task<List<User>> GetFollowingUsers(int userId)
        {
            var followingsIds = Context.UsersFollowings
                .Where(x => x.FollowerId == userId)
                .Select(x => x.FollowingsId);

            return await Context.Users
                .Where(x => followingsIds.Contains(x.Id))
                .ToListAsync();
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await Context.Message.ToListAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            await Context.Message.AddAsync(message);
            await Context.SaveChangesAsync();
        }

        public async Task FollowRecipeAuthor(int userId, int authorId)
        {
            await Context.UsersFollowings.AddAsync(new UsersFollowings()
            {
                FollowerId = userId,
                FollowingsId = authorId
            });

            await Context.SaveChangesAsync();
        }

        public async Task UnFollowRecipeAuthor(int userId, int authorId)
        {
            var usersFollowings = Context.UsersFollowings.Where(x => x.FollowerId == userId && x.FollowingsId == authorId).FirstOrDefault();
            Context.UsersFollowings.Remove(usersFollowings);

            await Context.SaveChangesAsync();
        }
    }
}
