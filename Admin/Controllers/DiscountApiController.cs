using Application.Discounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountApiController : ControllerBase
    {
        private readonly IDiscount discount;

        public DiscountApiController(IDiscount  Discount)
        {
            discount = Discount;
        }
        [HttpGet]
        [Route("SearchCatalogItem")]
        public async Task<IActionResult> SearchCatalogItem(string term, int Add)
        {
           

             return Ok(discount.GetCatalogItems(term,Add));
        }
    }
}
