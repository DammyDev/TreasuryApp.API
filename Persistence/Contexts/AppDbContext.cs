using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using TreasuryApp.API.Domain.Models;
using System;

namespace TreasuryApp.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //builder.Entity<Category>().ToTable("Categories");
            //builder.Entity<Category>().HasKey(p => p.Id);
            //builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            //builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            //builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            //builder.Entity<Category>().HasData
            //(
            //    new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
            //    new Category { Id = 101, Name = "Dairy" }
            //);

            //builder.Entity<Product>().ToTable("Products");
            //builder.Entity<Product>().HasKey(p => p.Id);
            //builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            //builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            //builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            //builder.Entity<Product>().HasData
            //(
            //    new Product
            //    {
            //        Id = 100,
            //        Name = "Apple",
            //        QuantityInPackage = 1,
            //        UnitOfMeasurement = EUnitOfMeasurement.Unity,
            //        CategoryId = 100
            //    },
            //    new Product
            //    {
            //        Id = 101,
            //        Name = "Milk",
            //        QuantityInPackage = 2,
            //        UnitOfMeasurement = EUnitOfMeasurement.Liter,
            //        CategoryId = 101,
            //    }
            //);

            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Company>().Property(p => p.SwiftAddress).IsRequired();
            builder.Entity<Company>().Property(p => p.PhoneNumber).IsRequired();
            builder.Entity<Company>().Property(p => p.ReportingCurrency).IsRequired();
            builder.Entity<Company>().Property(p => p.SuspenseGLAccount).IsRequired();
            builder.Entity<Company>().Property(p => p.TradingDate).IsRequired();
            builder.Entity<Company>().Property(p => p.NextTradingDate).IsRequired();
            builder.Entity<Company>().Property(p => p.LastEODDate).IsRequired();
            builder.Entity<Company>().Property(p => p.NextEODDate).IsRequired();
            builder.Entity<Company>().Property(p => p.EODGLDate).IsRequired();
            builder.Entity<Company>().Property(p => p.MRSName).IsRequired();

            builder.Entity<Company>().HasData
            (
                new Company
                {
                    Id = 100,
                    Name =  "Beta Highdeas InfoTech",
                    ShortName =  "BetaHitech",
                    PhysicalAddress =  "57 Marina Rd, Lagos, ",
                    Country = "Nigeria",
                    SwiftAddress =  "XXXYYYZZZ",
                    PhoneNumber =  "08030721539",
                    ReportingCurrency =  "USD",
                    ParentEntity =  "XXX",
                    SuspenseGLAccount =  "900USD100000",
                    TradingDate =  DateTime.Now,
                    NextTradingDate = DateTime.Now,
                    LastEODDate = DateTime.Now,
                    NextEODDate = DateTime.Now,
                    EODGLDate = DateTime.Now,
                    MRSName =  "FF"
                },

                new Company
                {
                    Id = 101,
                    Name = "Bisi and Sons Ltd",
                    ShortName = "Beecee",
                    PhysicalAddress = "House 59, Ijapo Estate Rd, Akure ",
                    Country = "Nigeria",
                    SwiftAddress = "XXXYYYZZZ",
                    PhoneNumber = "09056570001",
                    ReportingCurrency = "GBP",
                    ParentEntity = "XXX",
                    SuspenseGLAccount = "900GBP500000",
                    TradingDate = DateTime.Now,
                    NextTradingDate = DateTime.Now,
                    LastEODDate = DateTime.Now,
                    NextEODDate = DateTime.Now,
                    EODGLDate = DateTime.Now,
                    MRSName = "QQ",
                    IsActive = false
                }
            );
        }
    }
}