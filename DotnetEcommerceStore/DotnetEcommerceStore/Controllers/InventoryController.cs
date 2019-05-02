using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using DotnetEcommerceStore.Models.Services;
using DotnetEcommerceStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetEcommerceStore.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventory _inventory;

        /// <summary>
        /// Brings in the Database
        /// </summary>
        /// <param name="inventory">Product Inventory</param>
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// (Get) Gets All Products
        /// </summary>
        /// <returns>Product View</returns>
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _inventory.GetProductList();
            return View(products);
        }

        /// <summary>
        /// (Get) Gets Product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product View</returns>
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _inventory.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// (Get) (Create) Product
        /// </summary>
        /// <returns>Product Create</returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// (Post) Create New product
        /// </summary>
        /// <param name="product">New Inventory Item</param>
        /// <returns>Create Action</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SKU,Name,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _inventory.Create(product);
                return RedirectToAction(nameof(Index));
                
            }
            return View(product);
        }

        /*
        /// <summary>
        /// (Get) Edit Product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product</returns>
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _inventory.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SKU,Name,Description,Price")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.UpdateProduct(id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public bool ProductExists(int id)
        {
            return _inventory.Products.Any(e => e.ID == id);
        }
        */
    }
}