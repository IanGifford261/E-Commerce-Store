﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetEcommerceStore.Models;

namespace DotnetEcommerceStore.Data
{
    public class EComerceDbContext : DbContext
    {
        public EComerceDbContext(DbContextOptions<EComerceDbContext> options) : base(options)
        {

        }

        public DbSet MyProperty { get; set; }
    }
}
