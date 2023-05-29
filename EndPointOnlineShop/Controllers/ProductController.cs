using Application.Catalogs;
using EndPointOnlineShop.Utilities.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace EndPointOnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPlpItems PlpItems;
        private readonly IPdpItems PdpItems;
        private readonly IDistributedCache cache;
        public ProductController(IPlpItems PlpItems, IPdpItems PdpItems/* IDistributedCache cache*/)
        {
            this.PlpItems = PlpItems;
       //     this.cache=cache;
            this.PdpItems = PdpItems;
        }
       [ServiceFilter(typeof(SaveVisitorFilter))]
        [HttpGet]

        public IActionResult Index(CatlogPLPRequestDto Req)
        {
           
            var res = PlpItems.GetPlp(Req);
            return View(res);
        }

        public IActionResult Get(int Id)
        {
            var res = PdpItems.Get(Id);
            if(res == null)
            {

                return NotFound();
            }
             return View(res);
            

        }
    }
}
