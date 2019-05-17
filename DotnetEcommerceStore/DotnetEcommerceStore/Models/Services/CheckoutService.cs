using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly EComerceDbContext _checkout;

        public CheckoutService(EComerceDbContext checkout)
        {
            _checkout = checkout;
        }

        public async Task<Checkout> OrderCheckout(Cart cart)
        {
            Checkout checkout = new Checkout();
            //checkout.ID = cart.CartID;
            checkout.UserID = cart.UserID;
            checkout.PurchaseDate = DateTime.Today;
            
            //await _checkout.SaveChangesAsync();

            decimal cost = 0;

            foreach (CartItems item in cart.CartItems)
            {
                CheckoutItems orderItem = new CheckoutItems
                {
                   // ID = item.CartItemsID,
                    OrderID = checkout.ID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity

                };
                _checkout.Add(orderItem);
                _checkout.Remove(item);
                
            }
            checkout.PurchaseTotal = cost;
            _checkout.Checkout.Add(checkout);
            //_checkout.Update(checkout);

            await _checkout.SaveChangesAsync();

            return checkout;
        }

        public async Task AddPurchase(Checkout order, CartItems item)
        {
            CheckoutItems orderItem = new CheckoutItems
            {
                ID = item.CartItemsID,
                OrderID = order.ID,
                ProductID = item.ProductID,
                Quantity = item.Quantity
            };

            //_checkout.CheckoutItems.Add(orderItem);
            await _checkout.SaveChangesAsync();
        }

        /// <summary>
        /// (Read) Gets a Checkout by UserID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Checkout</returns>
        public Checkout GetCheckoutByID(string id)
        {

            Checkout checkout = _checkout.Checkout.FirstOrDefault(u => u.UserID == id);
            

            return checkout;
        }

        public async Task<List<Checkout>>GetLastTenCheckouts()
        {
            var co = await _checkout.Checkout.ToListAsync();
            var lastTen = co.OrderByDescending(x => x.ID).Take(10).ToList();
            return lastTen;
        }
        /// <summary>
        /// (Read) Gets all the items in the Checkout
        /// </summary>
        /// <param name="id">Checkout ID</param>
        /// <returns>All Checkout Items</returns>
        public async Task<List<CheckoutItems>> GetAllCartItems(int id)
        {
            var products = await _checkout.CheckoutItems.Where(ci => ci.OrderID == id).ToListAsync();

            foreach (var product in products)
            {
                product.Product = await _checkout.Products.FindAsync(product.ProductID);
            }

            return products;
        }
    }
}
