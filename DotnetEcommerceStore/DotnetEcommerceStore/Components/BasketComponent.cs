using DotnetEcommerceStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var basket = await _context.Products.OrderByDescending(x => x.ID)
                                                .Take(number)
                                                .ToListAsync();
            return View(basket);
        }
    }
}
