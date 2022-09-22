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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reciepe> Reciepes { get; set; }
        public DbSet<StockInReciepe> StockInReciepes { get; set; }
        public DbSet<Stockpile> Stockpiles { get; set; }

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
                c.Property(p=>p.Id).HasColumnName("Id");
                c.Property(p => p.UserId).HasColumnName("UserId");
                c.Property(p => p.FirstName).HasColumnName("FirstName");
                c.Property(p => p.LastName).HasColumnName("LastName");
                c.Property(p => p.Adress).HasColumnName("Adress");
                c.Property(p => p.TelephoneNumber).HasColumnName("TelephoneNumber");
                c.Property(p => p.Email).HasColumnName("Email");
                c.HasOne(p=>p.User);
            });

            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("Employees").HasKey(k=>k.Id);
                e.Property(p => p.UserId).HasColumnName("UserId");
                e.Property(p => p.NationalId).HasColumnName("NationalIdentity");
            });
            
        }
    }
}
