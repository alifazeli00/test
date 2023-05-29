using Application.Catalogs;
using Application.Context;
using Application.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs
{
    public interface IPdpItems
    {
        CatalogItemPDPDto Get(int Id);

    }
    public class PdpItems : IPdpItems
    {
        private readonly IDataBaceContext context;
       
        public PdpItems(IDataBaceContext context)
        {
             this.context = context;
        }
        private GetPriceDto GetPrice(int Id)
        {
            var catalogitem = context.CatalogItem.Include(p => p.CatalogItemImgs).Include(p => p.CatalogBranId).Include(p => p.CatalogType).Include(p => p.CatalogItemFeatures).
              Include(l => l.Discountt).ThenInclude(d => d.CatalogItems).SingleOrDefault(x => x.Id == Id);
            GetPriceDto dto = new GetPriceDto();
            foreach (var x in catalogitem.Discountt)
            {

                dto.old = catalogitem.Price;
                dto.persent = (x.DiscountAmount * 100) / catalogitem.Price;
                dto.price = catalogitem.Price-x.DiscountAmount ;

             

            };
            return dto;

        }

        public CatalogItemPDPDto Get(int Id)
        {

            var catalogitem = context.CatalogItem.Include(p=>p.CatalogItemImgs).Include(p => p.CatalogBranId).Include(p => p.CatalogType).Include(p=>p.CatalogItemFeatures).
              Include(l=>l.Discountt).ThenInclude(d=>d.CatalogItems).SingleOrDefault(x => x.Id == Id);
            if(catalogitem == null)
            {
                throw new NotFound(nameof(catalogitem),Id);
            }
        //    var items = context.CatalogItem.Include(p => p.CatalogItemImgs).Include(p => p.CatalogBranId).Include(p => p.CatalogType).Include(p => p.CatalogItemFeatures).
          //    Include(l => l.Discountt).ThenInclude(d => d.CatalogItems).Where(x => x.Id == Id).ToList();
            //var s = context.Discountt.Include(p => p.CatalogItems).Select(p => p.CatalogItems).Where(a => a.Contains(catalogitem)).ToList();
  
            // singel  chera  chera az first estefade nashode
     

            var feature = catalogitem.CatalogItemFeatures.Select(p => new PDPFeaturesDto
            {
                Group = p.Group,
                Key = p.Key,
                Value = p.Value


            }).ToList(). GroupBy(p => p.Group);

            //  float newpirce = 0;

            //  var dis = context.Discountt.Where(p => p.Id==catalogitem.Discounts.Select(p=>p.Id).LastOrDefault()).SingleOrDefault();
            //var dis = context.Discountt.Where(p => p.Id == catalogitem.Id).SingleOrDefault();

            //if (dis!=null)
            //{
            //if (dis.UsePercentage == true)
            //{
            //    float disamount = catalogitem.Price*(1-dis.DiscountPercentage/100);
            //    newpirce = catalogitem.Price - disamount;
            //}
            //else
            //{

            //   newpirce = catalogitem.Price - dis.DiscountAmount;
            //   }
            //if(dis.RequiresCouponCode==true)
            //{


            //}

            //      };
            // ino neveshtam chon to items  disscounttId nazade bodam va goshadim omad
            var h = GetPrice(catalogitem.Id);

            return new CatalogItemPDPDto
            {
                Features = feature,
            //    SimilarCatalogs = similarCatalogItems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBranId.Brand,
                Type = catalogitem.CatalogType.Type,
                Price = h.price,
                Description = catalogitem.Description,
                Images = catalogitem.CatalogItemImgs.Select(p => "https://localhost:44321/" + p.Src).ToList(),
              OldPrice = h.old,
              PercentDiscount=h.persent
                //PercentDiscount = catalogitem.PercentDiscount,
            };



        }
    }
    public class GetPriceDto
    {
        public int price { get; set; }
        public int old { get; set; }
        public int  persent { get; set; }
    }
    public class CatalogItemPDPDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }
        public List<string> Images { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGrouping<string, PDPFeaturesDto>> Features { get; set; }
        public List<SimilarCatalogItemDto> SimilarCatalogs { get; set; }

    }

    public class PDPFeaturesDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class SimilarCatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
    }
}
