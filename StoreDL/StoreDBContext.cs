using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext() : base() { }
        public StoreDBContext(DbContextOptions options) : base(options) { }

        public DbSet<CCustomers> Customers { get; set; }
        public DbSet<Order> OrderDetails { get; set; }
        public DbSet<CProduct> Products { get; set; }
    }
}
