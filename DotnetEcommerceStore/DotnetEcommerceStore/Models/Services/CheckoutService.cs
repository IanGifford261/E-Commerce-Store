using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models.Interfaces;
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

        public Task<Checkout> OrderCheckout(string userID)
        {
            throw new NotImplementedException();
        }

        public async Task AddPurchase(Checkout order, CartItems item)
        {
            CheckoutItems orderItem = new CheckoutItems
            {
                CheckoutItemsID = item.CartItemsID,
                OrderID = order.CheckoutID,
                ProductID = item.ProductID,
                Quantity = item.Quantity
            };

            await _checkout.CheckoutItems.AddAsync(orderItem);
            await _checkout.SaveChangesAsync();
        }
    }
}
