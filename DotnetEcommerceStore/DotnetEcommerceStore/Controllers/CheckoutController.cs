using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerceStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICart _cart;
        private readonly ICartItems _cartItems;
        private readonly ICheckout _checkout;
        private UserManager<ApplicationUser> _userManager;

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async void Checkout(Checkout order)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            string userID = await _userManager.GetUserIdAsync(user);
            Cart cart = await _cart.GetCartByID(userID);

            cart.CartItems = await _cartItems.GetAllCartItems(cart.CartID);

            Checkout potato = await _checkout.OrderCheckout(userID);

            foreach (CartItems item in cart.CartItems)
            {
                await _checkout.AddPurchase(potato, item);
            }

            ConfirmOrder();
            MakePayment();
            CheckoutEmail();
            CloseOutCart();
            CheckoutReceipt();
        }

        public void ConfirmOrder()
        {

        }

        public void MakePayment()
        {

        }

        public void CheckoutEmail()
        {
            
        }

        public void CloseOutCart()
        {

        }

        public void CheckoutReceipt()
        {

        }
        
    }
}