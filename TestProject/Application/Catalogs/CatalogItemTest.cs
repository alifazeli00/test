using Application.Catalogs;
using Application.Dto;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Builders;
using Xunit;

namespace TestProject.Application.Catalogs
{
    public class CatalogItemTest
    {
        [Fact]
        public void Create_Test()
        {
            CreateDto x = new CreateDto()
            {
                AvailableStock = 1,
                CatalogBrandId = 1,
                CatalogTypeId = 1,
                Name = "q",
                Price = 1,
                MaxStockThreshold=1,Description="",
                RestockThreshold=1,Brands= new  List<BrandDto>{ new BrandDto { Brand = "s", Id = 1 } },
                Features= new List<AddNewCatalogItemFeature_dto> { new AddNewCatalogItemFeature_dto { Group="a",Key="a",Value="a"} },
                Images= new List<CatalogItemImgsDto> { new CatalogItemImgsDto { src="s"} },
                Types= new List<TypeDto> { new TypeDto { Id=1,} }
                
            };

            var datbacebuilder = new DataBaceContextBuilder();
            var dbcontext = datbacebuilder.GetdbContext();

            var service = new catalogItem(dbcontext);
            var res = service.Create(x);
            Assert.NotNull(res);
           Assert.IsType<BaseDto>(res);

        }

        [Fact]
        public void GetTpe_Test()
        {
            List<TypeDto> x = new List<TypeDto>()
            {
                 new TypeDto
                 {
                     Id=1,Type="1"
                 }
             };
            CatalogType xa = new CatalogType()
            {
                Id = 1,
               
                ParentCatalogTypeId = 1,
                Type = "ssam"
            };





              var datbacebuilder = new DataBaceContextBuilder();
            var dbcontext = datbacebuilder.GetdbContext();
            dbcontext.Add(xa);
            dbcontext.SaveChanges();
            var service = new catalogItem(dbcontext);
            var res = service.GetTpe();
            

            Assert.NotNull(res);
            Assert.IsType<List<TypeDto>>(res);

        }
      
    }
}
