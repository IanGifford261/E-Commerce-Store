using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetEcommerceStore.Pages.Admin
{
    [Authorize(Policy = "Admin Access")]
    public class AdminDashboardModel : PageModel
    {
        private readonly ICheckout _checkout;

        public AdminDashboardModel(ICheckout checkout)
        {
            _checkout = checkout;
        }

        public void GetOrders()
        {

        }
    }
}