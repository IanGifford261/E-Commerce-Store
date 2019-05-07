using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserID { get; set; }
        public decimal Price { get; set; }
        public List<CartItems> CartItems { get; set; }
}
}
