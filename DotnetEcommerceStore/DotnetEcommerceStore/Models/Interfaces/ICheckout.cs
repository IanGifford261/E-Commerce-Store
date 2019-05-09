using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface ICheckout
    {
        Task<Checkout> OrderCheckout(string userID);
        Task AddPurchase(Checkout order, CartItems item);
    }
}
