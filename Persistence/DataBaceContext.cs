using Application.Context;
using Application.Discounts;
using Application.Orders;
using Domain;
using Domain.Catalogs;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataBaceContext:DbContext,IDataBaceContext
    {
        public DataBaceContext(DbContextOptions<DataBaceContext>options):base(options)
        {

        }
        public DbSet<Peyment> Peyment { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ChatMassege> ChatMassege { get; set; } 
   public  DbSet<CatalogItem> CatalogItem { get; set; }
        public DbSet<CatalogItemImgs> CatalogItemImgs { get; set; }
        public DbSet<CatalogType> CatalogType { get; set; }
        public DbSet <CatalogBrand>catalogBrand { get; set; }
        public DbSet<Discountt> Discountt { get; set; }
        public   DbSet<CatalogItemFeature> CatalogItemFeature { get; set; }
        public DbSet<Baskett> Baskett { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
       




        public DbSet<ChatRoms> ChatRoms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          //  modelBuilder.Entity<CatalogItem>().Property<bool>(p => p.IsRemove).HasDefaultValue(false);
            modelBuilder.Entity<CatalogItem>()
             .HasQueryFilter(m => EF.Property<bool>(m, "IsRemove") == false);
            DataBaseContextSeed.CatalogSeed(modelBuilder);
        }

        }
}
