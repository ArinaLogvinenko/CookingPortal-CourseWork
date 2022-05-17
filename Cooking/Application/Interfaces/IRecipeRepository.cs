namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.DTO;
    using Domain.Entities;
    using Domain.Interfaces;

    public interface IRecipeRepository : IRepository<Recipe>
    {
        public Task<IEnumerable<Recipe>> GetAllWithAuthorsAsync();

        Task<Recipe> GetRecipeDetailsByIdAsync(int id);

        Task FollowRecipe(int userId, int recipeId);

        Task<List<Recipe>> GetSubscibedRecipes(int userId);

        Task FollowRecipeAuthor(int userId, int authorId);

        Task<List<Recipe>> GetRecipesByFollowingUsers(int userId);

        Task AddRecipe(AddRecipeDto addRecipeDto);

        Task<List<Recipe>> GetOwnRecipes(int userId);

        Task UnscribeRecipe(int recipeId, int followerId);

        Task DeleteOwnRecipe(int recipeId);

        Task UnFollowRecipeAuthor(int userId, int authorId);

        Task EditRecipe(AddRecipeDto editRecipeDto);
    }
}
