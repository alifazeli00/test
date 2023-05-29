using Application.Catalogs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiOnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ICatalogType CatalogType;
        public TypesController(ICatalogType CatalogType)
        {
            this.CatalogType = CatalogType; 

        }
        // GET: api/<TypesController>
        [HttpGet]
        public  IActionResult Get(int? parentId)
        {
            return Ok(CatalogType.Get(parentId, 1,10));

        }

        // GET api/<TypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = CatalogType.FindById(id);
            return Ok(res);
        }

        // POST api/<TypesController>
        [HttpPost]
        public IActionResult Post(CatalogTypeDto Req)
        { 

            var res = CatalogType.Create(Req);
            var uri = Url.Action(nameof(Get), "Types", new { Id = res.Id }, Request.Scheme);
         return   Created(uri,res);

        }


        // PUT api/<TypesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TypesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
