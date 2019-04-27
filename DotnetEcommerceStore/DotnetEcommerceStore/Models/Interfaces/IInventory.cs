using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface IInventory
    {
        Task Create(Product product);
        Task<List<Product>> GetProductList();
        Task<Product> GetProduct(int id);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        bool ProductExists(int id);
    }
}
