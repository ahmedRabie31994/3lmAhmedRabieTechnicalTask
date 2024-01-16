using AhmedRabieTechnicalTask.Domain.Customer.Entities;
using AhmedRabieTechnicalTask.Domain.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AhmedRabieTechnicalTask.Infra.Data.Context
{
    public  class ApplicationDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
           new Book {Id= new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), Title = "Ahmed Rabie Book Title ", Description = "Ahmed Rabie Book Desctiption", MinSalePrice = 50, MaxSalePrice = 100, PublishDate = DateTime.Now, Auther = "Ahmed Mohamed" },
           new Book { Id = new Guid("5B29FC40-CA47-1067-B31D-00DD010662DA"), Title = "Mohamed Title ", Description = "Mohamed Title Book Desctiption", MinSalePrice = 70, MaxSalePrice = 100, PublishDate = DateTime.Now, Auther = "Mohamed Mohamed" },
           new Book { Id = new Guid("4B29FC40-CA47-1067-B31D-00DD010662DA"), Title = "Mohamed Title 4", Description = "Mohamed Title Book Desctiption", MinSalePrice = 70, MaxSalePrice = 100, PublishDate = DateTime.Now, Auther = "Mohamed Mohamed" }
           
            );
            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.Deleted);
            base.OnModelCreating(modelBuilder);



        }
    }
}
