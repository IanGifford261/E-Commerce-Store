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
    public class ProductController : Controller
    {
        private readonly IInventory _product;

        /// <summary>
        /// Brings in the Database
        /// </summary>
        /// <param name="inventory">Product Inventory</param>
        public ProductController(IInventory product)
        {
            _product = product;
        }

        /// <summary>
        /// (Get) Gets All Products
        /// </summary>
        /// <returns>Product View</returns>
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _product.GetProductList();
            return View(products);
        }

        //TODO: Get by Instrument

        //TODO: Get by Instrument Type

        //TODO: Get by Product Type

        /// <summary>
        /// (Get) Gets Product by ID
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Product View</returns>
        [Route("Products/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var product = await _product.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}