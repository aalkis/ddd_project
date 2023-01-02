using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Be_bitirme.Domain.Data
{


    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(x => x.Basket).WithOne(x => x.User).HasForeignKey<Basket>(x => x.UserId);
            modelBuilder.Entity<User>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();


            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<Basket>().Property(x => x.BasketTotalPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Basket>().HasKey(x=>x.BasketId);

            modelBuilder.Entity<BasketItem>().HasOne(x => x.Basket).WithMany(x => x.BasketItems).HasForeignKey(x => x.BasketId);
            modelBuilder.Entity<BasketItem>().Property(x => x.BasketItemPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<BasketItem>().HasKey(x => x.BasketItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
