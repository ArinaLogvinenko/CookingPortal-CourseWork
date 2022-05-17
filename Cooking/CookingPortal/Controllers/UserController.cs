namespace CookingPortal.Controllers
{
    using Application.Mappings;
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Application.DTO;
    using Application.Interfaces;
    using CookingPortal.Controllers.BaseControllerNamespace;
    using ModelResult;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Identity;
    using Domain.Entities;
    using Microsoft.AspNetCore.Hosting;

    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IWebHostEnvironment appEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment appEnvironment)
        {
            this.userService = userService;
            this.appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index(int id)
        {
            try
            {
                var result = await userService.GetUser(id);
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginUserDTO loginUser)
        {
            try
            {
                loginUser.PasswordError = loginUser.PasswordError = (loginUser.Password.Length < 5 || loginUser.Password.Length > 25) ? "Enter correct password" : string.Empty;
                loginUser.FullNameError = string.IsNullOrEmpty(loginUser.FullName) ? "Enter your name" : string.Empty;

                if (!string.IsNullOrEmpty(loginUser.PasswordError)
                    || !string.IsNullOrEmpty(loginUser.FullNameError))
                {
                    return View(loginUser);
                }

                var user = await userService.GetByNamePassword(loginUser.FullName, loginUser.Password);

                if (user != null)
                {
                    await Authenticate(loginUser.FullName);
                    return RedirectToAction("Index", "Recipe");
                }
                else
                {
                    loginUser.EnterError = "User doesn't exist";
                }

                return View(loginUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserDTO registerUser)
        {
            try
            {
                registerUser.PasswordError = (registerUser.Password.Length < 5 || registerUser.Password.Length > 25) ? "Enter correct password" : string.Empty;
                registerUser.ConfirmPasswordError = registerUser.Password == registerUser.ConfirmPassword ? string.Empty : "The passwords don't match";
                registerUser.FullNameError = string.IsNullOrEmpty(registerUser.FullName) ? "Enter your name" : string.Empty;
                registerUser.EmailError = string.IsNullOrEmpty(registerUser.Email) ? "Enter your email" : string.Empty;

                if (!string.IsNullOrEmpty(registerUser.ConfirmPasswordError)
                    || !string.IsNullOrEmpty(registerUser.PasswordError)
                    || !string.IsNullOrEmpty(registerUser.FullNameError) 
                    || !string.IsNullOrEmpty(registerUser.EmailError))
                {
                    return View(registerUser);
                }

                await userService.RegisterUser(registerUser);

                var loginDTO = new LoginUserDTO() 
                { 
                    FullName = registerUser.FullName, 
                    Password = registerUser.Password 
                };

                return await Login(loginDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> Profile()
        {
            try
            {
                var result = await userService.GetByName(User.Identity.Name);

                if (result == null)
                {
                    return Login();
                }

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> UserProfile(int userId)
        {
            try
            {
                var result = await userService.GetUser(userId);

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> FollowingAuthors()
        {
            try
            {
                var user = await userService.GetByName(User.Identity.Name);
                var result = await userService.GetFollowingUsers(user.Id);

                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                var sender =  await userService.GetEntityUserByName(User.Identity.Name);
                message.UserId = sender.Id;
                await userService.AddMessageAsync(message);
            }

            return Ok();
        }

        /// <summary>This API returns User by Id.</summary>
        /// <response code="200">Returns User by Id.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var result = await userService.GetUser(id);
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

        /// <summary>This API returns users that can be followed.</summary>
        /// <param name="id">User id.</param>
        /// <param name="count">Count of might be follow users.</param>
        /// <response code="200">Returns users that can be followed.</response>
        [HttpGet("GetUsersMightBeFollow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersMightBeFollow(int id, int? count)
        {
            try
            {
                var result = await userService.GetUsersMightBeFollow(id, count);
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

        /// <summary>This API register and add a user to the database.</summary>
        /// <param name="addUserDTO">User DTO.</param>
        /// <response code="200">Register and add a user to the database.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddUser([FromBody] AddUserDTO addUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Unsuccessful attempt to add user: invalid model.");
                }

                userService.AddUser(addUserDTO);
                return ActionResult(HandleResult.Ok());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> EditUser()
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user != null)
            {
                EditUserDTO model = new EditUserDTO { FullName = user.FullName, Image = user.Image, Status = user.Status};

                return View(model);
            }

            return RedirectToAction("Profile", "User");
        }

        /// <summary>This API edit user in database.</summary>
        /// <param name="editUserDTO">User DTO.</param>
        /// <response code="200">Edit user in database.</response>
        [HttpPost]
        public async Task<IActionResult> EditUser([FromForm] EditUserDTO editUserDTO)
        {
            try
            {
                var user = await userService.GetByName(User.Identity.Name);
                editUserDTO.Id = user.Id;

                editUserDTO.PasswordError = (editUserDTO.Password is null || editUserDTO.Password.Length < 5 || editUserDTO.Password.Length > 25) ? "Enter correct password" : string.Empty;
                editUserDTO.ConfirmPasswordError = editUserDTO.Password == editUserDTO.ConfirmPassword ? string.Empty : "The passwords don't match";
                editUserDTO.FullNameError = string.IsNullOrEmpty(editUserDTO.FullName) ? "Enter your name" : string.Empty;

                if (!string.IsNullOrEmpty(editUserDTO.ConfirmPasswordError)
                     || !string.IsNullOrEmpty(editUserDTO.PasswordError)
                     || !string.IsNullOrEmpty(editUserDTO.FullNameError))                     
                {
                    return View(editUserDTO);
                }

                await userService.EditUser(editUserDTO);

                await Authenticate(editUserDTO.FullName);

                return RedirectToAction("Profile", "User");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost]
        public async Task<IActionResult> FollowRecipeAuthor([FromBody] int authorId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await userService.FollowAuthor(user.Id, authorId);
            }

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> UnFollowRecipeAuthor([FromBody] int authorId)
        {
            var user = await userService.GetByName(User.Identity.Name);
            if (user is not null)
            {
                await userService.UnFollowRecipeAuthor(user.Id, authorId);
            }

            return Ok();
        }
    }
}
