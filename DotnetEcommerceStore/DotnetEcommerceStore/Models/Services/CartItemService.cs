using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Services
{
    public class CartItemService : ICartItems
    {
        private EComerceDbContext _cartItems;

        /// <summary>
        /// Brings in Database
        /// </summary>
        /// <param name="cartItems">Cart Items Table</param>
        public CartItemService(EComerceDbContext cartItems)
        {
            _cartItems = cartItems;
        }

        /// <summary>
        /// (Create) Adds an Item to the Cart
        /// </summary>
        /// <param name="cart">Shopping Cart</param>
        /// <param name="cartItem">Item to be added</param>
        /// <returns>Created (if successful)</returns>
        public async Task<HttpStatusCode> AddCartItem(Cart cart, CartItems cartItem)
        {
            cartItem.CartID = cart.CartID;
            await _cartItems.CartItems.AddAsync(cartItem);
            await _cartItems.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        /// <summary>
        /// (Read) Gets a Cart Item by ID
        /// </summary>
        /// <param name="id">Cart Item ID</param>
        /// <returns>Cart Item</returns>
        public async Task<CartItems> GetCartItemByID(int id)
        {
            var cartItem = await _cartItems.CartItems.FirstOrDefaultAsync(x => x.CartItemsID == id);
            cartItem.Product = await _cartItems.Products.FindAsync(cartItem.ProductID);
            return cartItem;
        }

        /// <summary>
        /// (Read) Gets all the items in the Shopping Cart
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <returns>All Shopping Cart Items</returns>
        public async Task<List<CartItems>> GetAllCartItems(int id)
        {
            var cartItems = await _cartItems.CartItems.Where(ci => ci.CartID == id).ToListAsync();

            foreach (var product in cartItems)
            {
                product.Product = await _cartItems.Products.FindAsync(product.ProductID);
            }

            return cartItems;
        }

        /// <summary>
        /// (Update) Updates Shopping Cart Item
        /// </summary>
        /// <param name="id">Cart ID</param>
        /// <param name="cartItem">Cart Item</param>
        /// <returns>Cart Item</returns>
        public async Task<CartItems> UpdateCartItem(int id, CartItems cartItem)
        {
            cartItem.CartID = id;
            _cartItems.CartItems.Update(cartItem);
            await _cartItems.SaveChangesAsync();
            return cartItem;
        }

        /// <summary>
        /// (Delete) Removes an item from the Shopping Cart
        /// </summary>
        /// <param name="id">Cart Item ID</param>
        /// <returns>OK (if successful)</returns>
        public async Task<HttpStatusCode> RemoveCartItem(int id)
        {
            var cartItem = await _cartItems.CartItems.FindAsync(id);

            _cartItems.CartItems.Remove(cartItem);
            await _cartItems.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        /// <summary>
        /// (Delete) Removes all the items in the Shopping Cart
        /// </summary>
        /// <param name="id">Shopping Cart ID</param>
        /// <returns>Deletes all items in Shopping Cart</returns>
        public async Task DeleteAllCartItems(int id)
        {
            var cart = await _cartItems.Cart.FindAsync(id);
            var cartItems = await _cartItems.CartItems.Where(cid => cid.CartID == id).ToListAsync();
            _cartItems.CartItems.RemoveRange(cartItems);
            await _cartItems.SaveChangesAsync();
        }
    }
}
