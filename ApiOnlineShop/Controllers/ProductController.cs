using Application.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPlpItems PlpItems;
        private readonly IPdpItems PdpItems;
        public ProductController(IPlpItems PlpItems, IPdpItems PdpItems)
        {
            this.PlpItems = PlpItems;
           this .PdpItems = PdpItems;

        }

        [HttpGet()]    
        public IActionResult Post([FromQuery] CatlogPLPRequestDto Req)
        {

            var res = PlpItems.GetPlp(Req);

            return Ok(res);

        }
        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            return Ok(PdpItems.Get(Id));


        }





    }
}
