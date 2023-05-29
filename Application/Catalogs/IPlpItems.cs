using Application.Context;
using Application.Dto;
using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs
{
    public interface IPlpItems
    {

        BaseDto<CatalogPLPDto> GetPlp(CatlogPLPRequestDto Req);

    }
    public class PlpItems : IPlpItems
    {
        private  readonly IDataBaceContext conext;
        public PlpItems(IDataBaceContext conext)
        {
            this.conext = conext;
        }
        public BaseDto<CatalogPLPDto> GetPlp(CatlogPLPRequestDto Req)
        {
            int rowCount = 0;
            var query = conext.CatalogItem.Include(p => p.CatalogBranId).Include(p => p.CatalogType).Include(p => p.CatalogItemImgs)
                .OrderByDescending(p => p.Id).AsQueryable();

           if(Req.brandId!=null)
            {
                query = query.Where(p => Req.brandId.Any(d=> d==p.CatalogBrandId));
                
            }
           
            if (Req.CatalogTypeId!=null)
            {
                query = query.Where(p => Req.CatalogTypeId==p.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(Req.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(Req.SearchKey)
                || p.Description.Contains(Req.SearchKey));
            }

            if (Req.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }


            //if (Req.SortType == SortType.Bestselling)
            //{
            //    query = query.Include(p => p.OrderItems)
            //        .OrderByDescending(p => p.OrderItems.Count());
            //}

            //if (request.SortType == SortType.MostPopular)
            //{
            //    query = query.Include(p => p.CatalogItemFavourites)
            //        .OrderByDescending(p => p.CatalogItemFavourites.Count());
            //}
            if (Req.SortType == SortType.MostVisited)
            {
                query = query
                    .OrderByDescending(p => p.VisitCount);
            }

            if (Req.SortType == SortType.newest)
            {
                query = query
                    .OrderByDescending(p => p.Id);
            }

            if (Req.SortType == SortType.cheapest)
            {
                query = query
                    .Include(p => p.Discountt)
                    .OrderBy(p => p.Price);
            }

            if (Req.SortType == SortType.mostExpensive)
            {
                query = query
                    .Include(p => p.Discountt)
                    .OrderByDescending(p => p.Price);
            }

            var res = query.PagedResult(Req.pageIndex, Req.pageSize, out rowCount)
         .Select(p => new CatalogPLPDto
            {
                AvailableStock = p.AvailableStock,
                Name = p.Name,
                Price = p.Price,
                Image = "https://localhost:44321/" + p.CatalogItemImgs.FirstOrDefault().Src,
                Id = p.Id,
                Rate = 5



            }).ToList();

            return new BaseDto<CatalogPLPDto>(Req.pageIndex, Req.pageSize, rowCount) { Count = rowCount, Data = res, PageSize = Req.pageSize, PageIndex = Req.pageIndex };
        }
    }
    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
    public class CatlogPLPRequestDto
    {
 //       public int page { get; set; } = 1;
        public int pageSize { get; set; } = 1;
        public int? CatalogTypeId { get; set; }
        public int[] brandId { get; set; }
        public bool AvailableStock { get; set; }
        public string SearchKey { get; set; }
        public SortType SortType { get; set; }
        public int pageIndex { get; set; } = 1;
    }


    public enum SortType
    {
        /// <summary>
        /// بدونه مرتب سازی
        /// </summary>
        None = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروش‌ترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوب‌ترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        ///  ‌جدیدترین
        /// </summary>
        newest = 4,
        /// <summary>
        /// ارزان‌ترین
        /// </summary>
        cheapest = 5,
        /// <summary>
        /// گران‌ترین
        /// </summary>
        mostExpensive = 6,
    }
}
