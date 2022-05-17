namespace CookingPortal.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Application.Interfaces;
    using CookingPortal.Controllers.BaseControllerNamespace;
    using ModelResult;
    using Application.DTO;
    using System.Collections.Generic;

    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;
        private readonly IUserService userService;

        public RecipeController(IRecipeService recipeService, IUserService userService)
        {
            this.recipeService = recipeService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index(int recipeId)
        {
            try
            {
                var result = await recipeService.GetRecipes();

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> FollowingRecipes()
        {
            try
            {
                var user = await userService.GetByName(User.Identity.Name);
                var result = await recipeService.GetRecipesByFollowingUsers(user.Id);
                if (result == null)
                {
                    return View(new List<RecipeDTO>());
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> SavedRecipes()
        {
            try
            {
                var user = await userService.GetByName(User.Identity.Name);
                var result = await recipeService.GetSavedRecipes(user.Id);
                if (result == null)
                {
                    return View(new List<RecipeDTO>());
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipes()
        {
            try
            {
                var result = await recipeService.GetRecipes();
                if (result == null)
                {
                    return ActionResult(HandleResult.NoContent());
                }

                return ActionResult(HandleResult.Ok(content: result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>This API returns recipes of people that the user follows.</summary>
        /// <response code="200">Returns recipes of following people.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipesByFollowingUsers(int id)
        {
            try
            {
                var result = await recipeService.GetRecipesByFollowingUsers(id);
                if (result == null)
                {
                    return ActionResult(HandleResult.NoContent());
                }

                return ActionResult(HandleResult.Ok(content: result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> OwnRecipes()
        {
            var user = await userService.GetByName(User.Identity.Name);
            var result = await recipeService.GetOwnRecipes(user.Id);
            if (result == null)
            {
                return View(new List<RecipeDTO>());
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int recipeId)
        {
            await recipeService.DeleteOwnRecipe(recipeId);

            return RedirectToAction("OwnRecipes");
        }

        public ActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromForm] AddRecipeDto addRecipeDto)
        {
            var userId = (await userService.GetByName(User.Identity.Name)).Id;
            addRecipeDto.UserId = userId;

            await recipeService.AddRecipe(addRecipeDto);

            return RedirectToAction("OwnRecipes", "Recipe");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int recipeId)
        {
            var userId = (await userService.GetByName(User.Identity.Name)).Id;
            var recipe = await recipeService.GetRecipeDetailsByIdAsync(recipeId,userId);
            var editOrderModel = new AddRecipeDto()
            {
                Description = recipe.Description,
                Name = recipe.Name,
                Image = recipe.Image,
                Ingredients = recipe.Ingredients,
                NutritionFacts = recipe.NutritionFacts,
                ServingTime = recipe.ServingTime,
                Id = recipe.Id
            };

            return View(editOrderModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] AddRecipeDto editRecipeDto)
        {
            await recipeService.EditRecipe(editRecipeDto);

            return RedirectToAction("OwnRecipes", "Recipe");
        }
    }
}
