using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerceStore.Controllers
{
    public class MusicianController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public MusicianController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Policy = "Professional Musician")]
        public async Task<IActionResult> Musician()
        {
            return View();
        }
    }
}