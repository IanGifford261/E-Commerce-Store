using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace DotnetEcommerceStore.Models.ViewModels
{
    public class BasketProductViewModel
    {
        public int BasketID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }        
        [Range(0, 20, ErrorMessage = "Please Enter A Desired Purchase Quantity between 0 and 20.")]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ProductTotal { get; set; }
        public decimal TotalCost { get; set; }
    }
}
