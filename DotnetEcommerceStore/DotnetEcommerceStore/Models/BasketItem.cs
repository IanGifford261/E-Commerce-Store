using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class BasketItem
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        [Range(0, 20, ErrorMessage = "Please Enter A Desired Purchase Quantity between 0 and 20.")]
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
