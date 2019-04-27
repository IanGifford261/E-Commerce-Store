using DotnetEcommerceStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Data;

namespace DotnetEcommerceStore.Models.Services
{
    public class InventoryService : IInventory
    {
        private EComerceDbContext _context;

        public InventoryService(EComerceDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        
    }
}
