namespace Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using DTO;
    using Interfaces;
    using Domain.Entities;

    public class RecipeService : Service, IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly IUserRepository userRepository;
        private readonly IRecipeCommentRepository commentRepository;

        public RecipeService(IUserRepository userRepository, IRecipeRepository recipeRepository,
            IMapper mapper,
            IRecipeCommentRepository commentRepository)
            : base(mapper)
        {
            this.recipeRepository = recipeRepository;
            this.userRepository = userRepository;
            this.commentRepository = commentRepository;
        }

        public async Task<IEnumerable<RecipeDTO>> GetRecipes()
        {
            try
            {
                var recipes = await recipeRepository.GetAllWithAuthorsAsync();
                return Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeDTO>>(recipes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddComment(AddRecipeCommentDTO model)
        {
            await commentRepository.Add(model);
        }

        public async Task FollowRecipe(int userId, int recipeId)
        {
            await recipeRepository.FollowRecipe(userId, recipeId);
        }

        public async Task FollowAuthor(int userId, int authorId)
        {
            await recipeRepository.FollowRecipeAuthor(userId, authorId);
        }

        public async Task<RecipeDTO> GetRecipeDetailsByIdAsync(int recipeId, int userId)
        {
            try
            {
                var recipe = await recipeRepository.GetRecipeDetailsByIdAsync(recipeId);
                var recipeDto = Mapper.Map<RecipeDTO>(recipe);

                recipeDto.IsSaved = recipe.RecipeFollowings.Any(x => x.FollowerId == userId);
                recipeDto.IsFollowToAuthor = recipe.Author.UserFollowings.Any(x => x.FollowerId == userId);

                return recipeDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RecipeDTO>> GetRecipesByFollowingUsers(int id)
        {
            try
            {
                var user = await userRepository.FindAsync(t => t.Id == id);
                if (user == null)
                {
                    return null;
                }

                var recipes = await recipeRepository.GetRecipesByFollowingUsers(id);
                return Mapper.Map<IEnumerable<RecipeDTO>>(recipes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RecipeDTO>> GetSavedRecipes(int userId)
        {
            try
            {
                return Mapper.Map<List<RecipeDTO>>(await recipeRepository.GetSubscibedRecipes(userId)); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddRecipe(AddRecipeDto addRecipeDto)
        {
            try
            {
                await recipeRepository.AddRecipe(addRecipeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RecipeDTO>> GetOwnRecipes(int userId)
        {
            try
            {
                return Mapper.Map<List<RecipeDTO>>(await recipeRepository.GetOwnRecipes(userId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UnscribeRecipe(int recipeId, int followerId)
        {
            try
            {
                await recipeRepository.UnscribeRecipe(recipeId, followerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteOwnRecipe(int recipeId)
        {
            try
            {
                await recipeRepository.DeleteOwnRecipe(recipeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UnFollowRecipeAuthor(int userId, int authorId)
        {
            try
            {
                await recipeRepository.UnFollowRecipeAuthor(userId, authorId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditRecipe(AddRecipeDto editRecipeDto)
        {
            try
            {
                await recipeRepository.EditRecipe(editRecipeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
