﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetEcommerceStore.Controllers
{
    public class BasketController : Controller
    {
        private readonly IInventory _inventory;
        private readonly ICart _cart;
        private readonly ICartItems _cartItems;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// Connect to both databases
        /// </summary>
        /// <param name="inventory">Inventory Table</param>
        /// <param name="cart">Cart Table</param>
        /// <param name="userManager">User Manager</param>
        /// <param name="signInManager">Sign-In Manager</param>
        public BasketController(IInventory inventory, ICart cart, ICartItems cartItems, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _inventory = inventory;
            _cart = cart;
            _cartItems = cartItems;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// (GET) Displays all the items in the Shopping Cart
        /// </summary>
        /// <returns>Shop Cart View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            string UserID = user.Id;
            var cart = await _cart.GetCartByID(UserID);

            var shoppingCart = _cartItems.GetAllCartItems(cart.CartID);

            return View(shoppingCart);
        }
        
        /// <summary>
        /// (Post) Add an item to the Shopping Cart
        /// </summary>
        /// <param name="id">Inventory ID</param>
        /// <param name="quantity">Quantity of Items to add</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            string UserID = user.Id;
            var cart = await _cart.GetCartByID(UserID);

            var product = await _cartItems.GetCartItemByID(id);

            if (product != null)
            {
                product.Quantity += quantity;
                await _cartItems.UpdateCartItem(id, product);
            }
            else
            {
                await _cartItems.AddCartItem(cart, product);
            }


            return RedirectToAction("Index", "Basket");
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateCartItem(int id, int quantity)
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            string UserID = user.Id;
            var cart = await _cart.GetCartByID(UserID);

            CartItems cartItem = await _cartItems.GetCartItemByID(id);
            cartItem.Quantity = quantity;
            await _cartItems.UpdateCartItem(cartItem.CartID, cartItem);
            return RedirectToAction("Index", "Basket");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            string UserID = user.Id;
            var cart = await _cart.GetCartByID(UserID);

            CartItems cartItem = await _cartItems.GetCartItemByID(id);
            await _cartItems.RemoveCartItem(id);
            return RedirectToAction("Index", "Basket");
        }
    }
}