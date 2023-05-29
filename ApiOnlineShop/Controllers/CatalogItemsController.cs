using Application.Catalogs;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly ICatalogItem CatalogItem;
        public CatalogItemsController(ICatalogItem CatalogItem)
        {
            this.CatalogItem = CatalogItem;

        }
        // GET: api/<CatalogItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<CatalogItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CatalogItemsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateDto Req)
        {
            var res = CatalogItem.Create(Req);
            string uri = Url.Action(nameof(Get), "Product", new { Id = res.Id }, Request.Scheme);
            return Created(uri, res);

            // hala abayd asan bara catalog item 1  type 1 ro sabt koni
        }



        // PUT api/<CatalogItemsController>/5
        [HttpPut("{id}")]

        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CatalogItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
        [Route("api/[action]")]
        [HttpGet]
        public IActionResult GetBrand()
        {
            return Ok(CatalogItem.GetBrand());

        }
       //[Route("api/[action]")]
       //[HttpGet]
       //public   IActionResult GetType()
       // {

       //     return Ok(CatalogItem.GetTpe());   
       // }

     







    }
}
