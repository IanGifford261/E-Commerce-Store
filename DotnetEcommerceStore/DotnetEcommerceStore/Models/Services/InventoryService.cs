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

        public async Task Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        //public async Task<Product> GetProduct(int id)
        //{
        //    return await _context.Product            
        //}

        public async Task UpdateProduct(int id, Product product)
        {
            if (product.ID == id)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = _context.Products.Where(i => i.ID == id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
