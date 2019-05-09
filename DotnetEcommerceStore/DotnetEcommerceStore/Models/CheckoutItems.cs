using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class CheckoutItems
    {
        public int CheckoutItemsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
