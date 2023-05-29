using Application.Discounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOnlineShop.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscount Discount;
        public DiscountController(IDiscount Discount)
        {
            this.Discount = Discount;

        }

        [HttpPost]
        public IActionResult Post(AddNewDiscountDto  Req)
        {
            var res= Discount.CreateDis(Req);
      return Ok(res);



        }




    }
}
