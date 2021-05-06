using BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication
{
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //return View(_userService.GetUsers());
            return RedirectToAction("ListPerformance", "Performance", new { });
        }

        public IActionResult Registration()
        {
            return View("Registration2");
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationPost(RegistrationViewModel viewModel)
        {
            await _userService.Registration(viewModel.Login, viewModel.Password, viewModel.Fio, viewModel.Mail, viewModel.Age);
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login() //????
        {
            if (!User.Identity.IsAuthenticated)
                return View("Login2");
            else
                return RedirectToAction("ViewPerformances", "Performance", new { });
        }
        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginViewModel viewModel)
        {
            User user = _userService.Login(viewModel.Login, viewModel.Password);
            if (user != null)
            {
                await Authenticate(user);
            }
            _ = User.Identity.IsAuthenticated;
            if(User.IsInRole("Admin"))
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction("ViewPerformances", "Performance", new { });
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                new Claim("id", user.Id.ToString()),
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
