using Application.Context;
using Application.Dto;
using Application.Exeptions;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Application.Catalogs
{
    public interface ICatalogItem
    {

        BaseDto Create(CreateDto Req);
        List<TypeDto> GetTpe();
        List<BrandDto> GetBrand();
    


    }
    public class catalogItem : ICatalogItem
    {
        private readonly IDataBaceContext context;
   
        public catalogItem(IDataBaceContext context)
        {
            this.context = context;

        }
        public BaseDto Create(CreateDto Req)
        {
            try
            {

                CatalogItem x = new CatalogItem()
                {
                    Name = Req.Name,
                    AvailableStock = Req.AvailableStock,
                    IsRemove = false,
                    Price = Req.Price,
                    MaxStockThreshold = Req.MaxStockThreshold,
                    RestockThreshold = Req.RestockThreshold,
                    CatalogBrandId = Req.CatalogBrandId,
                    CatalogTypeId = Req.CatalogTypeId,



                };
                foreach (var item in Req.Images)
                {
                    x.CatalogItemImgs = new List<CatalogItemImgs> { new CatalogItemImgs { Src = item.src } };
                };

                foreach (var item in Req.Features)
                {
                    x.CatalogItemFeatures = new List<CatalogItemFeature> { new CatalogItemFeature { Key = item.Key, Value = item.Value, Group = item.Group } };
                };

                context.CatalogItem.Add(x);
                context.SaveChanges();

                return new BaseDto { Masseg = "Sabt shod", Statos = true, Id = x.Id };
            }
            catch(Exception ex)
            {
             
                return new BaseDto { Masseg = ex.Message, Statos = false, Id = 0 };
            }
       


        }


        public List<BrandDto> GetBrand()
        {
        
              CatalogBrand x = new CatalogBrand()
            {
                Brand = "s"

            };
            context.catalogBrand.Add(x);
            context.SaveChanges();
           var res=context.catalogBrand.Select(p=>new BrandDto {Brand=p.Brand,Id=p.Id}).ToList();
            return res;
        }

        public List<TypeDto> GetTpe()
        {
            

                var res = context.CatalogType.Select(p => new TypeDto { Type = p.Type, Id = p.Id }).ToList();
            if(res==null)
            {
                throw new NotFound(nameof(CatalogType));
            }
            return res;
         

        }
    }
    public class TypeDto
    {
        public string Type { get; set; }
        public int Id { get; set; }
    }

    public class BrandDto
    {
        public string Brand { get; set; }
        public int Id { get; set; }
    }

    public class CreateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
   //     public int VisitCount { get; set; }

        public string Description { get; set; }
        public int CatalogTypeId { get; set; }
        //public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        //public CatalogBrand CatalogBrand { get; set; }
        //public int CatalogItemImgsId { get; set; }
        public List<CatalogItemImgsDto> Images { get; set; }
        //public bool IsRemove { get; set; } = false;
        public List<AddNewCatalogItemFeature_dto> Features { get; set; }
        public  List<TypeDto>  Types{ get; set; }
          public List<BrandDto> Brands { get; set; }

    }
     public class AddNewCatalogItemFeature_dto
    {

        public string Key { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }
    }
public class CatalogItemImgsDto
{

    public string src { get; set; }
}


}


