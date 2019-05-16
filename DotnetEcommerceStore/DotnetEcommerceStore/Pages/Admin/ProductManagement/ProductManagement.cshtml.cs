using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetEcommerceStore.Pages.Admin.ProductManagement
{
    [Authorize(Policy = "Admin Access")]
    public class ProductManagementModel : PageModel
    {
        private readonly IInventory _inventory;

        public ProductManagementModel(IInventory inventory)
        {
            _inventory = inventory;
        }
        
        public int? ID { get; set; }
        public Product Product { get; set; }

        public void OnGet()
        {
            
        }
    }
}