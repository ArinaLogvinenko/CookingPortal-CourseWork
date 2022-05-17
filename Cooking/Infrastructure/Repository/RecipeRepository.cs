namespace Infrastructure.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Application.Interfaces;
    using Domain.Entities;
    using Infrastructure.Persistence;
    using System.Linq;
    using Application.DTO;

    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recipe>> GetAllWithAuthorsAsync()
        {
            return await Context.Recipes.Include(t => t.Author).ToListAsync();
        }

        public async Task<Recipe> GetRecipeDetailsByIdAsync(int id)
        {
            return await Context.Recipes
                .Where(x => x.Id == id)
                .Include(t => t.Author)
                .ThenInclude(y => y.UserFollowings)
                .Include(t => t.RecipeFollowings)
                .Include(t => t.Followers)
                .Include(t => t.Comments)
                .ThenInclude(y => y.Author)
                .FirstOrDefaultAsync();
        }

        public async Task FollowRecipe(int userId, int recipeId)
        {
            var recipe = await Context.Recipes.Where(x => x.Id == recipeId).FirstAsync();
            recipe.RecipeFollowings.Add(new RecipesFollowings()
            {
                FollowerId = userId,
            });

            recipe.Likes++;

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

        public async Task<List<Recipe>> GetRecipesByFollowingUsers(int userId)
        {
            var folIds = Context.UsersFollowings.Where(x => x.FollowerId == userId).Select(x => x.FollowingsId).ToList();

            return await Context.Recipes.Where(x => folIds.Contains(x.Author.Id)).ToListAsync();
        }

        public async Task<List<Recipe>> GetSubscibedRecipes(int userId)
        {
            var recipeIds = Context.RecipesFollowings
                .Where(x => x.FollowerId == userId)
                .Select(x => x.RecipeId);

            return await Context.Recipes
                .Where(x => recipeIds.Contains(x.Id))
                .Include(t => t.Author)
                .Include(t => t.Comments)
                .ThenInclude(y => y.Author).ToListAsync();
        }

        public async Task UnscribeRecipe(int recipeId, int followerId)
        {
            var recipeFollowings = Context.RecipesFollowings.Where(x => x.RecipeId == recipeId && x.FollowerId == followerId).FirstOrDefault();
            Context.RecipesFollowings.Remove(recipeFollowings);

            var recipe = await Context.Recipes.Where(x => x.Id == recipeId).FirstAsync();
            recipe.Likes--;

            await Context.SaveChangesAsync();
        }

        public async Task AddRecipe(AddRecipeDto addRecipeDto)
        {
            var user = Context.Users.Where(x => x.Id == addRecipeDto.UserId).FirstOrDefault();
            await Context.Recipes.AddAsync(new Recipe()
            {
                Name = addRecipeDto.Name,
                Description = addRecipeDto.Description,
                Image = addRecipeDto.Image,
                Likes = 0,
                NutritionFacts = addRecipeDto.NutritionFacts,
                Ingredients = addRecipeDto.Ingredients,
                ServingTime = addRecipeDto.ServingTime,
                Author = user
            });

            await Context.SaveChangesAsync();
        }

        public async Task EditRecipe(AddRecipeDto editRecipeDto)
        {
            var recipe = Context.Recipes.Where(x => x.Id == editRecipeDto.Id).FirstOrDefault();

            recipe.ServingTime = editRecipeDto.ServingTime;
            recipe.Image = editRecipeDto.Image;
            recipe.Description = editRecipeDto.Description;
            recipe.Name = editRecipeDto.Name;
            recipe.Ingredients = editRecipeDto.Ingredients;
            recipe.NutritionFacts = editRecipeDto.NutritionFacts;

            await Context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetOwnRecipes(int userId)
        {
            return await Context.Recipes.Where(x => x.Author.Id == userId).ToListAsync();
        }

        public async Task DeleteOwnRecipe(int recipeId)
        {
            var recipe = Context.Recipes
                .Where(x => x.Id == recipeId)
                .Include(x => x.Comments)
                .FirstOrDefault();
            
            Context.Recipes.Remove(recipe);

            await Context.SaveChangesAsync();
        }
    }
}
