using CorsoEnaip2018_ProjectManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CorsoEnaip2018_ProjectManagement.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get;  set; }
    }
}
