using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;
using Microsoft.EntityFrameworkCore;

namespace tech_test_payment_api.Context
{
   public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                        
        }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItems> SalesItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>(s => {
                s.HasKey(s => s.Id);
            });

            modelBuilder.Entity<Product>(p => {
                p.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Sale>(s => {
                s.HasKey(s => s.Id);

                s.HasOne<Seller>(s => s.Seller)
                .WithOne()
                .HasForeignKey<Seller>(se => se.Id);

                s.HasMany(s => s.Items)
                 .WithOne()
                 .HasForeignKey(si => si.SaleId);
            });       

            modelBuilder.Entity<SaleItems>(si => {
                si.HasKey(si => si.Id);

                si.HasOne<Sale>(si => si.Sale)
                .WithOne()
                .HasForeignKey<Sale>(s => s.Id);

                si.HasOne<Product>(si => si.Produtcx)
                .WithOne()
                .HasForeignKey<Product>(p => p.Id);                                
            });
        }
    }
}