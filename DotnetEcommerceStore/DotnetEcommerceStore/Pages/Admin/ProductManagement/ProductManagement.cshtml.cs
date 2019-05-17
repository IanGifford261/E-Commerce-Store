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

        public async Task OnGet()
        {
            Product = await _inventory.GetProduct(ID.GetValueOrDefault()) ?? new Product();
        }

        public async Task<IActionResult> OnPost()
        {
            var postProduct = await _inventory.GetProduct(ID.GetValueOrDefault()) ?? new Product();
            postProduct.Name = Product.Name;
            postProduct.SKU = Product.SKU;
            postProduct.Description = Product.Description;
            postProduct.Price = Product.Price;

            if (ID != null)
            {
                await _inventory.UpdateProduct(postProduct.ID, postProduct);
            }
            if (ID == null)
            {
                await _inventory.Create(postProduct);
            };
            return RedirectToPage("ProductManagement");
        }

        public async Task<IActionResult> Delete()
        {
            await _inventory.DeleteProduct(ID.Value);
            return RedirectToPage("ProductManagement");
        }
    }
}