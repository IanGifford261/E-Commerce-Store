using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetEcommerceStore.Models
{
    public class RoleInitializer
    {
        private static List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = ApplicationRoles.Admin, NormalizedName=ApplicationRoles.Admin.ToUpper() },
            new IdentityRole{Name = ApplicationRoles.Member, NormalizedName=ApplicationRoles.Member.ToUpper() }
        };

        public static void SeedData(IServiceProvider servicesProvider)
        {
            using (var dbContext = new ApplicationDbContext(servicesProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
            }
        }

        private static void AddRoles(ApplicationDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }
            foreach (var role in Roles)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

    }

}











