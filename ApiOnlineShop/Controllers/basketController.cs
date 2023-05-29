using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class basketController : ControllerBase
    {
        private readonly IBasket Basket;
        public basketController(IBasket  Basket)
        {
            this.Basket = Basket;

        }

        [HttpGet("{UserId}")]
       public IActionResult Get(string UserId)
        {
            return Ok(Basket.GetCart(UserId));


        }
        [HttpPost]
        public IActionResult Post(int Id, string UserId)
        {
            string uri = Url.Action(nameof(Get), "basket", UserId,Request.Scheme);
            return Created(uri,Basket.Create(Id,uri));
        }


    }
}
