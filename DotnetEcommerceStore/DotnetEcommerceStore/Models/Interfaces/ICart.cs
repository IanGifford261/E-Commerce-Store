using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Services;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface ICart
    {
        Task CreateCart(string id);

        Task<Cart> GetCartByID(string id);

        Task<Cart> UpdateCart(Cart cart);
    }
}
