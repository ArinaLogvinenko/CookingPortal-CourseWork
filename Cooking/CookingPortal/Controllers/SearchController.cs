namespace CookingPortal.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Application.Interfaces;
    using CookingPortal.Controllers.BaseControllerNamespace;
    using ModelResult;
    using System.Collections.Generic;
    using Application.DTO;

    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IActionResult> Index(string expression)
        {
            try
            {
                //if (expression.Length < 3)
                //{
                //    ModelState.AddModelError(expression, "Query string must contain at least 3 symbols.");
                //    return ActionResult(HandleResult.BadRequest(ModelState));
                //}

                var result = await searchService.GetUserAndRecipeByString(expression);

                if (result.ToList().Count == 0)
                {
                    return View(new List<UserRecipeDTO>());
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>This API takes string as a parameter and returns all users and recipes containing that string.</summary>
        /// <response code="200">Returns all users and recipes containing string.</response>
        /// <param name="expression">String: 3+ characters as a search query</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string expression)
        {
            try
            {
                if (expression.Length < 3)
                {
                    ModelState.AddModelError(expression, "Query string must contain at least 3 symbols.");
                    return ActionResult(HandleResult.BadRequest(ModelState));
                }

                var result = await searchService.GetUserAndRecipeByString(expression);

                if (result.ToList().Count == 0)
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
    }
}
