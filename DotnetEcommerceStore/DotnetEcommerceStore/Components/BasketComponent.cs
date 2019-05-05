using DotnetEcommerceStore.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Components
{ 
    //Issa mini controller
    public class BasketComponent : ViewComponent
    {
        private EComerceDbContext _context;

        public BasketComponent(EComerceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int number)
        {
            var basket = _context.Products.OrderByDescending(x => x.ID)
                                                .Take(number)
                                                .ToList();
            return View(basket);
        }
    }
}
