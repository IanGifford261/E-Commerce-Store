﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface ICartItems
    {
        Task<HttpStatusCode> AddCartItem(int cartID, int id);

        Task<CartItems> GetCartItemByID(int id);

        Task<List<CartItems>> GetAllCartItems(int id);

        Task<CartItems> UpdateCartItem(int id, CartItems cartItem);

        //Task<HttpStatusCode> RemoveCartItem(CartItems cartItem);

        int RemoveCartItem(CartItems product);




    }
}
