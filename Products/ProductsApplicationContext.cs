using Products.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class ProductsApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsApplicationContext() : base("DefaultConnection2") { }
    }
}
