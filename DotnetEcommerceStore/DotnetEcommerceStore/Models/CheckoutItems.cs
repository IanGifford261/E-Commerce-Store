using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class CheckoutItems
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Checkout Checkout { get; set; }
    }
}
