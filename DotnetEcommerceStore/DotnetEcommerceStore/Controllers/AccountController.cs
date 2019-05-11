using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid;

namespace DotnetEcommerceStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;

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
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim favInst = new Claim("Favorite Instrument", $"{user.FavInstrument}");

                    Claim proMusician = new Claim("Professional Musician", user.ProMusician.ToString());
                    
                    List<Claim> claims = new List<Claim> { nameClaim, email, favInst, proMusician };
            
                    await _userManager.AddClaimsAsync(user, claims);

                    if (registerViewModel.Email.ToLower() == "amanda@codefellows.com" || registerViewModel.Email.ToLower() ==  "ntibbals@outlook.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("<h1>Welcome to the Music Store!</h1>");
                    //sb.AppendLine("Thank you for registering with our site. We appreciate your business.");
                    //sb.AppendLine("Remember, Dont give your password to anyone");
                    //sb.ToString();
                    await _emailSender.SendEmailAsync(registerViewModel.Email, "Thank you for registering", "<p> Welcome to our Music Store </p>");

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registerViewModel);
        }

        /// <summary>
        /// (Get) Gets the Login view
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// (Post) Loggs the User into the website
        /// </summary>
        /// <param name="lvm">Log View Model</param>
        /// <returns>Logs into Site</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Information");
            }
            return View(lvm);
        }

        /// <summary>
        /// Logs the user off the site
        /// </summary>
        /// <returns>Home View</returns>
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

//StringBuilder sb = new StringBuilder();
//sb.AppendLine("<h1>Welcome to the Music Store!</h1>");
//sb.AppendLine("The Items that you have purchased are: <ul>");
// Foreach loop over all the basket items.....                    sb.Append("<li>NAME OF ITEM and PRICE</li>");
//sb.AppendLine("");
//sb.ToString();