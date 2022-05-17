namespace CookingPortal.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Application.DTO;
    using Application.Interfaces;
    using CookingPortal.Controllers.BaseControllerNamespace;
    using ModelResult;
    using System.Collections.Generic;

    public class SettingsController : BaseController
    {
        private readonly ISettingsService settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var result = await settingsService.GetSettings(id);
                if (result == null)
                {
                    return View();
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>This API returns User by Id.</summary>
        /// <response code="200">Returns User by Id.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSettings(int id)
        {
            try
            {
                var result = await settingsService.GetSettings(id);
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

        /// <summary>This API updates Settings by User Id.</summary>
        /// <response code="200">Updates Settings by User Id.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateSettings(int id, SettingsDTO settingsDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid input");
                }

                settingsService.UpdateUserSettings(id, settingsDTO);
                return ActionResult(HandleResult.Ok());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
