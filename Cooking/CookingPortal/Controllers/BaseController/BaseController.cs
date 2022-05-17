namespace CookingPortal.Controllers.BaseControllerNamespace
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using ModelResult;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected string userName;

        protected IActionResult ActionResult(HandleResult result)
        {
            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                return new NoContentResult();
            }

            return new JsonResult(result) { StatusCode = (int)result.StatusCode };
        }
    }
}
