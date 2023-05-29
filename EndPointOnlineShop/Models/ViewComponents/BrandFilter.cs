using Application.Catalogs;
using Microsoft.AspNetCore.Mvc;

namespace EndPointOnlineShop.Models.ViewComponents
{
   
        public class BrandFilter : ViewComponent
        {
            private readonly ICatalogItem catalogItem;

            public BrandFilter(ICatalogItem CatalogItem)
            {
                catalogItem = CatalogItem;
            }

            public IViewComponentResult Invoke()
            {
                var Brands = catalogItem.GetBrand();
                return View(viewName: "BrandFilter", model: Brands);

            }
        }
    }
