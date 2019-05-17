using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using DotnetEcommerceStore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotnetEcommerceStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICart _cart;
        private readonly ICartItems _cartItems;
        private readonly ICheckout _checkout;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;

        private IConfiguration Configuration { get; set; }
        

        /// <summary>
        /// Connects the injections to the controller
        /// </summary>
        /// <param name="cart">ICart</param>
        /// <param name="cartItems">ICartItems</param>
        /// <param name="checkout">ICheckout</param>
        /// <param name="userManager">IUserManager</param>
        public CheckoutController(IConfiguration configuration, ICart cart, ICartItems cartItems, ICheckout checkout, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _cart = cart;
            _cartItems = cartItems;
            _checkout = checkout;
            Configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;

        }

        /// <summary>
        /// View the checkout page
        /// </summary>
        /// <returns>Checkout View</returns>
        [HttpGet]
        [Authorize]
        public IActionResult CheckoutSumary()
        {
            return View();
        }

        /// <summary>
        /// Controls the flow of the Checkout Process
        /// </summary>
        /// <param name="order">Order</param>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(string userID)
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //string userID = cart.UserID;
            //ApplicationUser user = await _userManager.GetUserAsync(User);
            //string userID = await _userManager.GetUserIdAsync(user);
            Cart cart = await _cart.GetCartByID(userID);

            cart.CartItems = await _cartItems.GetAllCartItems(cart.CartID);

            Checkout potato = await _checkout.OrderCheckout(cart);

            return RedirectToAction("Confirm", "Checkout");
        }

        /// <summary>
        /// (GET) Displays all the items in the Shopping Cart
        /// </summary>
        /// <returns>Shop Cart View</returns>
        [HttpGet]
        public async Task<IActionResult> Confirm()
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            string UserID = user.Id;

            var order = _checkout.GetCheckoutByID(userName);

            var purchases = await _checkout.GetAllCartItems(order.ID);

            return View(purchases);
        }
        
        
        public async Task<IActionResult> Billing(string userID)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> MakePayment([Bind("UserID,FirstName,LastName,Address,City,ZipCode")]PaymentViewModel pvm)
        {
            creditCardType creditCard = new creditCardType
            {
                cardNumber = Configuration["CreditCardNumber"],
                expirationDate = Configuration["ExpirationDate"]
            };

            var billingAddress = new customerAddressType
            {
                firstName = pvm.FirstName,
                lastName = pvm.LastName,
                address = pvm.Address,
                city = pvm.City,
                zip = pvm.ZipCode
            };

            decimal amount = 3.23m;

            Payment payment = new Payment(Configuration);

            bool result = payment.SwipeCard(creditCard, pvm.UserID, billingAddress, amount);

            if (result)
            {
                CheckoutEmail();
                CheckoutReceipt();
                return RedirectToAction("Receipt", "Checkout");
            }
            else
            {
                return RedirectToAction("Confirm", "Checkout");
            }
        }

        public async void CheckoutEmail()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1>Thank You for your Patronage</h1>");
            sb.AppendLine("The Items that you have purchased are: <ul>");

            string userID = await _userManager.GetUserIdAsync(user);
            Cart cart = await _cart.GetCartByID(userID);

            cart.CartItems = await _cartItems.GetAllCartItems(cart.CartID);

            foreach (CartItems item in cart.CartItems)
            {
                sb.AppendLine($"<li>You purchased {item.Quantity} {item.Product.Name} for ${item.Product.Price} each and ${item.Quantity * item.Product.Price} total.</li>");
            };
            sb.Append("</ul>");

            await _emailSender.SendEmailAsync(user.Email, $"Thank you {user.FirstName} {user.LastName} for your purchase", sb.ToString());
        }

        public void CloseOutCart()
        {

        }

        public void CheckoutReceipt()
        {

        }
        
    }
}