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

    public class SearchService : ISearchService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IRecipeRepository recipeRepository;

        public SearchService(IMapper mapper, IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<UserRecipeDTO>> GetUserAndRecipeByString(string expression)
        {
            try
            {
                IEnumerable<User> users = await userRepository.FindAllAsync(u => (u.FullName).Contains(expression));
                IEnumerable<Recipe> recipes = await recipeRepository.FindAllAsync(r => r.Name.Contains(expression)
                || r.Description.Contains(expression));
                var map = mapper.Map<IEnumerable<UserRecipeDTO>>(users.OrderByDescending(p => p.Followers.Count));
                return map.Concat(mapper.Map<IEnumerable<UserRecipeDTO>>(recipes.OrderByDescending(p => p.Likes)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
