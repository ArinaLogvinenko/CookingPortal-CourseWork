using Application.Interfaces;
using CookingPortal.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RecipeIndex()
        {
            return RedirectToAction("Index", "Recipe");
        }

        public async Task<IActionResult> Chat()
        {
            var currentUser = await userService.GetEntityUserByName(User.Identity.Name);
            ViewBag.CurrentUserName = currentUser.FullName;
            var messages = await userService.GetMessageAsync();
            return View(messages);
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await userService.GetEntityUserByName(User.Identity.Name);
                message.UserId = sender.Id;
                await userService.AddMessageAsync(message);
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
