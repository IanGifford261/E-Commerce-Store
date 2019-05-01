using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DotnetEcommerceStore.Data;
using DotnetEcommerceStore.Models;
using DotnetEcommerceStore.Models.Services;
using DotnetEcommerceStore.Models.Interfaces;
using DotnetEcommerceStore.Models.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace DotnetEcommerceStore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // products
            var conProducts = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:EComerceDbContext"]
                : Configuration["ConnectionStrings:ProductionEComerceDbContext"];

            services.AddDbContext<EComerceDbContext>(options => options.UseSqlServer(conProducts));

            // users
            var conUsers = Environment.IsDevelopment()
                ? Configuration["ConnectionStrings:DefaultApplicationDb"]
                : Configuration["ConnectionStrings:ProductionApplicationDb"];

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conUsers));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Professional Musician", policy => policy.Requirements.Add(new ProMusicianRequirment(true)));
            });

            services.AddScoped<IInventory, InventoryService>();
            services.AddScoped<IAuthorizationHandler, ProMusicianHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();


            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
/*
--Code from origional ConfigureServices  just in case--
 
services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultApplicationDb")));

            services.AddDbContext<EComerceDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("ProductionEComerceDb")));

            services.AddScoped<IInventory, InventoryService>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

*/
