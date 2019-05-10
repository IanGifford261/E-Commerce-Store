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
        private readonly EComerceDbContext _cart;
        private readonly ApplicationDbContext _user;

        /// <summary>
        /// Connects Class to the database
        /// </summary>
        /// <param name="cart">store database</param>
        public CartService(EComerceDbContext cart, ApplicationDbContext user)
        {
            _cart = cart;
            _user = user;
        }

        /// <summary>
        /// (Create) Creates a new Shopping Cart
        /// </summary>
        /// <param name="user">Logged In User</param>
        /// <returns>Created (if successful)</returns>
        public async Task<HttpStatusCode> CreateCart(string id)
        {
            Cart cart = new Cart()
            {
                UserID = id
            };

            await _cart.Cart.AddAsync(cart);
            await _cart.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// (Read) Gets a Cart by Cart ID
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <returns>Cart</returns>
        public async Task<Cart> GetCartByID(string id)
        {

            var cart = await _cart.Cart.FirstOrDefaultAsync(u => u.UserID == id);



            if (cart == null)
            {
                await CreateCart(id);
            }

            return cart;
        }

        /// <summary>
        /// (Update) Updates Shopping Cart
        /// </summary>
        /// <param name="cart">Shopping Cart</param>
        /// <returns>Shopping Cart</returns>
        public async Task<Cart> UpdateCart(Cart cart)
        {
            _cart.Cart.Update(cart);
            await _cart.SaveChangesAsync();
            return cart;
        }
    }
}
