using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerceStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Brings in the User Manager and the Sign-In Manager into the class
        /// </summary>
        /// <param name="userManager">User Manager</param>
        /// <param name="signInManager">Sign-In Manager</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// (Get) Gets the Register information
        /// </summary>
        /// <returns>View action</returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// (Post) Posts the registeration of the User
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns>Register View Model View</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("Full Name", $"{user.FirstName} {user.LastName}");

                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> claims = new List<Claim> { nameClaim, email };

                    await _userManager.AddClaimsAsync(user, claims);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
            }

            return View(registerViewModel);
        }
    }
}