using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public  DbSet<Category> Categories { get; set; }
        //public  DbSet<Customer> Customers { get; set; }
        //public  DbSet<Employee> Employees { get; set; }
        //public  DbSet<Order> Orders { get; set; }
        //public  DbSet<Product> Products { get; set; }
        //public  DbSet<Reciepe> Reciepes { get; set; }
        //public  DbSet<StockInReciepe> StockInReciepes { get; set; }
        //public  DbSet<Stockpile> Stockpiles { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions ,IConfiguration configuration ):base (dbContextOptions)
        {
            Configuration = configuration;  
        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AlanyaNArchitectureConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.ToTable("Categories").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p=>p.CategoryName ).HasColumnName("CategoryName");
            });

            modelBuilder.Entity<Customer>(c =>
            {
                c.ToTable("Customers").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.UserId).HasColumnName("UserId");
                c.Property(p => p.FirstName).HasColumnName("FirstName");
                c.Property(p => p.LastName).HasColumnName("LastName");
                c.Property(p => p.Adress).HasColumnName("Adress");
                c.Property(p => p.TelephoneNumber).HasColumnName("TelephoneNumber");
                c.Property(p => p.Email).HasColumnName("Email");
                c.HasOne(p => p.User);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employees").HasKey(k => k.Id);
                e.Property(p => p.Id).HasColumnName("Id");
                e.Property(p => p.UserId).HasColumnName("UserId");
                e.Property(p => p.NationalId).HasColumnName("NationalIdentity");
                e.Property(p => p.FirstName).HasColumnName("FirstName");
                e.Property(p => p.LastName).HasColumnName("LastName");
                e.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
                e.Property(p => p.Address).HasColumnName("Adress");
                e.Property(p => p.EmailAdress).HasColumnName("EmailAdress");
                e.Property(p => p.Salary).HasColumnName("Salary");
                e.Property(p => p.MaritalStatus).HasColumnName("MaritalStatus");
                e.Property(p => p.Department).HasColumnName("Department");
                e.HasOne(p => p.User);
            });

            modelBuilder.Entity<Order>(o =>
            {
                o.ToTable("Orders").HasKey(k => k.Id);
                o.Property(p => p.Id).HasColumnName("Id");
                o.Property(p => p.CustomerId).HasColumnName("CustomerId");
                o.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
                o.Property(p => p.OrderDate).HasColumnName("OrderDate");
                o.Property(p => p.OrderStatus).HasColumnName("OrderStatus");
                o.HasMany(p => p.Products);
                o.HasOne(p => p.Customer);
                o.HasOne(p => p.Employee);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.CategoryId).HasColumnName("CategoryId");
                p.Property(p => p.ProductImageId).HasColumnName("ProductImageId");
                p.Property(p => p.RecipeId).HasColumnName("ReciepeId");
                p.Property(p => p.DiscountId).HasColumnName("DiscontId");
                p.Property(p => p.UnitId).HasColumnName("UnitId");
                p.Property(p => p.ProductName).HasColumnName("ProductName");
                p.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
                p.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
                p.Property(p => p.ExpirationDate).HasColumnName("ExpirationDate");
                p.HasOne(p => p.Category);
            });

            modelBuilder.Entity<Reciepe>(r =>
            {
                r.ToTable("Reciepes").HasKey(k => k.Id);
                r.Property(p => p.Id).HasColumnName("Id");
                r.Property(p => p.RecipeName).HasColumnName("ReciepeName");
                r.Property(p => p.RecipeCost).HasColumnName("ReciepeCost");
            });

            modelBuilder.Entity<StockInReciepe>(s =>
            {
                s.ToTable("StockInReciepes").HasKey(k => k.Id);
                s.Property(p => p.Id).HasColumnName("Id");
                s.Property(p => p.StockId).HasColumnName("StockId");
                s.Property(p => p.ReciepeId).HasColumnName("ReciepeId");
                s.Property(p => p.Amount).HasColumnName("Amount");
                s.Property(p => p.Price).HasColumnName("Price");
                s.HasOne(p => p.Reciepe);
                s.HasOne(p => p.Stockpile);
            });

            modelBuilder.Entity<Stockpile>(s =>
            {
                s.ToTable("Stockpiles").HasKey(k => k.Id);
                s.Property(p => p.Id).HasColumnName("Id");
                s.Property(p => p.StockName).HasColumnName("StockName");
                s.Property(p => p.Unit).HasColumnName("Unit");
                s.Property(p => p.Amount).HasColumnName("Amount");
                s.Property(p => p.Cost).HasColumnName("Cost");
                s.Property(p => p.ExpirationDate).HasColumnName("ExpirationDate");

            });

        }
    }
}
