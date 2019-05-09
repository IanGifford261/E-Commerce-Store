using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models.Interfaces
{
    public interface IOrder
    {
      
        Task<Order> OrderCheckout(ApplicationUser user);

    }
}
