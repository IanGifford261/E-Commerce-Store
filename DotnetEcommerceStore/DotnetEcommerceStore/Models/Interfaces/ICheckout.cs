using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface ICheckout
    {
        Task<Checkout> OrderCheckout(Cart cart);
        Task AddPurchase(Checkout order, CartItems item);
        Checkout GetCheckoutByID(string id);
        Task<List<CheckoutItems>> GetAllCartItems(int id);
    }
}
