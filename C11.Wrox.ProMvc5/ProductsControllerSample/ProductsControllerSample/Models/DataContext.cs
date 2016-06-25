using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsControllerSample.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}