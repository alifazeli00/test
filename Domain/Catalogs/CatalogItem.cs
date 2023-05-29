using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Catalogs
{
    public class CatalogItem
    {

        /// <summary>
        ///  mishod to catalog imgs az releshen estefade nakoni ke mishe  shadow  hala neveshti ye ja az barname bayad estefade koni bebin koja
        
        /// </summary>
        public  int Id { get; set; }
        public string Name { get; set; }
       public   int Price { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public int VisitCount { get; set; }
        public  string Description { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBranId { get; set; }
// fek konm on pi ke minvisi bara  img  bayad to in data bace zakhire kard v az in khond
        public ICollection<CatalogItemImgs>  CatalogItemImgs { get; set; }
        public bool IsRemove { get; set; } = false;
        public int DiscounttId { get; set; }
        public ICollection<Discountt> Discountt { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }

        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }










    }
}
