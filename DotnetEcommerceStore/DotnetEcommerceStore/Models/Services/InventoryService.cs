using DotnetEcommerceStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetEcommerceStore.Models.Services
{
    public class InventoryService : IInventory
    {
        private readonly EComerceDbContext _context;

        public InventoryService(EComerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }


        //public async Task<Product> GetProduct(int id)
        //{
        //    return await _context.Product
            
        //}
    }
}
