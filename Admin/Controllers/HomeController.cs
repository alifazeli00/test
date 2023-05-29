using Admin.Models;
using Admin.Models.ViewModel;
using Application.Catalogs;
using AutoMapper;
using Infrastructure.ExternalApi.ImgeServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {



        private readonly ICatalogItem catalogItem;
        private readonly ICatalogType catalogType;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper maper;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ImageUploderService mageUploderService;

        public HomeController(ICatalogItem catalogItem, ICatalogType catalogType, IMapper maper, ImageUploderService mageUploderService)
        {
            this.catalogItem = catalogItem;
            this.catalogType = catalogType;
            this.maper=maper;
            this.mageUploderService=mageUploderService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // size yani be ge  chanta to safe aval namaish bede
        public IActionResult IndexType(int? parentId, int pageIndex = 1, int pageSize = 5)
        {

            // bara namaish farzand az parentid estesfade shode 
            ViewBag.Request = parentId;
            var res = catalogType.Get(parentId,pageIndex,pageSize);


            return View(res);

        }

        public IActionResult Create(int? ParentId)
        {
            // bara sabt farzand az prent estefade shode
            //ViewBag.Request = ParentId;
            CatalogTypeViewModel x = new CatalogTypeViewModel()
            {
                ParentCatalogTypeId = ParentId,
            };

            return View(x);


        }

        [HttpPost]

        public IActionResult Create(CatalogTypeViewModel z)
        {

            var model = maper.Map<CatalogTypeDto>(z);


            //CatalogTypeDto ss = new CatalogTypeDto()
            //{
            ////    Id = z.Id,
            //    ParentCatalogTypeId = z.ParentCatalogTypeId,
            //    Type = z.Type
                
            //};
           
            var res = catalogType.Create(model);
            return RedirectToAction("IndexType", new { parentid = z.ParentCatalogTypeId });


        }

        public void delete(int Id)
        {
            catalogType.Delete(Id);

        }
        public IActionResult Edit(int Id)
        {
            var res = catalogType.FindById(Id);

            CatalogTypeViewModel x = new CatalogTypeViewModel()
            {
                Id = res.Id,
                ParentCatalogTypeId = res.ParentCatalogTypeId,
                Type = res.Type
            };


            return View(x);
        }
        [HttpPost]
        public IActionResult Edit(CatalogTypeViewModel Req)
        {
            CatalogTypeDto x = new CatalogTypeDto()
            {

                Id = Req.Id,
                ParentCatalogTypeId = Req.ParentCatalogTypeId,
                Type = Req.Type

            };
            var res= catalogType.Edit(x);
            return View();
        }

     
        public IActionResult CreateItem()
        {
            //   ViewBag.Brands = new SelectList(catalogItem.GetBrand(), "Id", "Name");
            CreateDto x = new CreateDto()
            {

                Brands = catalogItem.GetBrand(),
                Types = catalogItem.GetTpe()
            };
            return View(x);
            
        }
        public IActionResult GetBrand()
        {
            var res = catalogItem.GetBrand();
            return Json(res);
        }
        public IActionResult GetType()
        {
            var res = catalogItem.GetTpe();
            return Json(res);
        }

        [HttpPost]
        public IActionResult CreateItem(CreateDto Req, List<IFormFile> Files)
       {
        //    CatalogItemViewModel Files = new CatalogItemViewModel();
            
           
               for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                Files.Add(file);
            }
            List<CatalogItemImgsDto> images = new List<CatalogItemImgsDto>();
            if (Files.Count > 0)
            {
                //Upload 
                var result =mageUploderService.upload(Files);
                foreach (var item in result)
                {
                    images.Add(new CatalogItemImgsDto { src = item });
                }
            }
            Req.Images=images;

            var res = catalogItem.Create(Req);
            return Json(res);


        }

        

    }
}
