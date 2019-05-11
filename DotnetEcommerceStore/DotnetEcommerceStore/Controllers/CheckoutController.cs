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

        /// <summary>
        /// Connects the injections to the controller
        /// </summary>
        /// <param name="cart">ICart</param>
        /// <param name="cartItems">ICartItems</param>
        /// <param name="checkout">ICheckout</param>
        /// <param name="userManager">IUserManager</param>
        public CheckoutController(ICart cart, ICartItems cartItems, ICheckout checkout, UserManager<ApplicationUser> userManager)
        {
            _cart = cart;
            _cartItems = cartItems;
            _checkout = checkout;
            _userManager = userManager;
        }

        /// <summary>
        /// View the checkout page
        /// </summary>
        /// <returns>Checkout View</returns>
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// Controls the flow of the Checkout Process
        /// </summary>
        /// <param name="order">Order</param>
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

        /// <summary>
        /// Will confirm that the order is what the customer wants (may be removed because it might be duplicated)
        /// </summary>
        public void ConfirmOrder()
        {

        }

        /// <summary>
        /// 
        /// </summary>
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