using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using CookingPortal.Controllers.BaseControllerNamespace;
using CookingPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CookingPortal.Controllers
{
    public class RecipeDetailsController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public RecipeDetailsController(IRecipeService recipeService, IUserService userService, IMapper mapper)
        {
            this.recipeService = recipeService;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(int recipeId)
        {
            var userId = (await userService.GetByName(User.Identity.Name)).Id;
            var recipe = await recipeService.GetRecipeDetailsByIdAsync(recipeId, userId);

            return View(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] AddRecipeCommentModel recipeComment)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                recipeComment.AuthorId = user.Id;
                if (!string.IsNullOrEmpty(recipeComment.Comment))
                {
                    await recipeService.AddComment(mapper.Map<AddRecipeCommentDTO>(recipeComment));
                }
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> FollowRecipe([FromBody] int recipeId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await recipeService.FollowRecipe(user.Id, recipeId);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UnFollowRecipe([FromBody] int recipeId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await recipeService.UnscribeRecipe(recipeId, user.Id);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> FollowRecipeAuthor([FromBody] int authorId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await recipeService.FollowAuthor(user.Id, authorId);
            }

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> UnFollowRecipeAuthor([FromBody] int authorId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await recipeService.UnFollowRecipeAuthor(user.Id, authorId);
            }

            return Ok();
        }
    }
}
