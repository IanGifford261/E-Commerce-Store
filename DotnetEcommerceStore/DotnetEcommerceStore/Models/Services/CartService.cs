using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models.Interfaces;
using DotnetEcommerceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace DotnetEcommerceStore.Models.Services
{
    public class CartService : ICart
    {
        private readonly EComerceDbContext _context;

        /// <summary>
        /// Connects Class to the database
        /// </summary>
        /// <param name="cart">store database</param>
        private CartService(EComerceDbContext cart)
        {
            _context = cart;
        }

        /// <summary>
        /// (Create) Creates a new Shopping Cart
        /// </summary>
        /// <param name="user">Logged In User</param>
        /// <returns>Created (if successful)</returns>
        public async Task<HttpStatusCode> CreateCart(ApplicationUser user)
        {
            Cart cart = new Cart()
            {
                UserID = user.Id
            };

            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// (Read) Gets a Cart by Cart ID
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <returns>Cart</returns>
        public async Task<Cart> GetCartByID(string id)
        {
            var cart = await _context.Cart.FirstOrDefaultAsync(u => u.UserID == id);

            return cart;
        }

        /// <summary>
        /// (Update) Updates Shopping Cart
        /// </summary>
        /// <param name="cart">Shopping Cart</param>
        /// <returns>Shopping Cart</returns>
        public async Task<Cart> UpdateCart(Cart cart)
        {
            _context.Cart.Update(cart);
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}
