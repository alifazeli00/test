using Domain;
using Domain.Catalogs;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Context
{
    public interface IDataBaceContext
    {
        DbSet<Peyment> Peyment { get; set; }
        DbSet<ChatMassege> ChatMassege { get; set; }
         DbSet<Order> Order { get; set; }
         DbSet<OrderItem> OrderItem { get; set; }
        DbSet<CatalogItemFeature> CatalogItemFeature { get; set; }
        DbSet<CatalogItem> CatalogItem { get; set; }
         DbSet<CatalogItemImgs> CatalogItemImgs { get; set; }
         DbSet<CatalogType> CatalogType { get; set; }
         DbSet<CatalogBrand> catalogBrand { get; set; }
        DbSet<Discountt> Discountt { get; set; }
        DbSet<Baskett> Baskett { get; set; }
        DbSet<BasketItem> BasketItem { get; set; }
        DbSet<ChatRoms> ChatRoms { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());


    }
}
