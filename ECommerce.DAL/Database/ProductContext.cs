using ECommerce.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Database
{
  public  class ProductContext:IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opts):base(opts)
        {

        }
        public DbSet<product> Products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=. ; database=Ecommerce; Trusted_Connection=True");


        //}




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>().HasKey(a => new { a.orderId, a.ProductId });
            modelBuilder.Entity<OrderProduct>().HasOne(a => a.order).WithMany(a => a.orderProducts).HasForeignKey(a => a.orderId);
            modelBuilder.Entity<OrderProduct>().HasOne(a => a.product).WithMany(a => a.orderProducts).HasForeignKey(a => a.ProductId);
        }
     
    }
}
