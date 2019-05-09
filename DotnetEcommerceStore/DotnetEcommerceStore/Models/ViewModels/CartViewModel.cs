using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public decimal CartTotal { get; set; }
    }
}
