namespace Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTO;

    public interface IRecipeService : IService
    {
        public Task<IEnumerable<RecipeDTO>> GetRecipesByFollowingUsers(int id);
        public Task<IEnumerable<RecipeDTO>> GetRecipes();

        Task AddComment(AddRecipeCommentDTO model);

        Task<RecipeDTO> GetRecipeDetailsByIdAsync(int recipeId, int userId);

        Task FollowRecipe(int userId, int recipeId);

        Task<List<RecipeDTO>> GetSavedRecipes(int userId);

        Task FollowAuthor(int userId, int authorId);

        Task AddRecipe(AddRecipeDto addRecipeDto);

        Task<List<RecipeDTO>> GetOwnRecipes(int userId);

        Task UnscribeRecipe(int recipeId, int followerId);

        Task DeleteOwnRecipe(int recipeId);

        Task UnFollowRecipeAuthor(int userId, int authorId);

        Task EditRecipe(AddRecipeDto editRecipeDto);
    }
}
