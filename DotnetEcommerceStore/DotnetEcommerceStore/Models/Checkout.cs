using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class Checkout
    {
        public int CheckoutID { get; set; }
        public string UserID { get; set; }
        public List<CheckoutItems> OrderItems { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Total")]
        public decimal PurchaseTotal { get; set; }
    }
}
