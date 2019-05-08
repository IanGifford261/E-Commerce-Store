using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerceStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICart _cart;
        private readonly ICartItems _cartItems;
        private readonly IOrder _order;
        private UserManager<ApplicationUser> _userManager;

        /*
        public async Task<IActionResult> Checkout()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            string userID = _userManager.GetUserId(User);
            Cart cart = await _cart.GetCartByID(userID);

            cart.CartItems = await _cartItems.GetAllCartItems(cart.CartID);

            Models.Order order = await _order.OrderCheckout(order.OrderID)
        }
        */
    }
}