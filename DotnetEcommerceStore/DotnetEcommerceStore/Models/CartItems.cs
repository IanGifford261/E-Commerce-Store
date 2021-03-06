﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class CartItems
    {
        public int CartItemsID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        [Range(0, 20, ErrorMessage = "Please Enter A Desired Purchase Quantity between 0 and 20.")]
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }


        //        public int CartID { get; set; }
        //        public int ProductID { get; set; }
        //        public string Name { get; set; }
        //        public string SKU { get; set; }
        //        public string Img { get; set; }
        //        public string Description { get; set; }        
        //        [Range(0, 20, ErrorMessage = "Please Enter A Desired Purchase Quantity between 0 and 20.")]
        //        public int Quantity { get; set; }
        //        public decimal Price { get; set; }
        //        public decimal ProductTotal { get; set; }
        //        public decimal TotalCost { get; set; }
        //        public Product Product { get; set; }
    }
}
