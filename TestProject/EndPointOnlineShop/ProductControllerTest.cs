using Application.Catalogs;
using Application.Dto;
using EndPointOnlineShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace TestProject.EndPointOnlineShop
{
    public class ProductControllerTest
    {
        [Fact]
        // inja chera to factory nazadish
        public  void Test_Index()
        {
            int[] x = new int[] { 1, 2, 3, };
            CatlogPLPRequestDto c = new CatlogPLPRequestDto()
            {
                AvailableStock = true, brandId = x , CatalogTypeId = 1, pageSize = 1, SearchKey = "s", SortType = SortType.MostVisited , pageIndex = 1
            };
            BaseDto<CatalogPLPDto> ss = new BaseDto<CatalogPLPDto>(1, 1, 1)
            {
                Statos = true, Count = 1, Masseg = "a", PageIndex = 1, PageSize = 1, Data = new List<CatalogPLPDto>()
                {
                new CatalogPLPDto
                { Id = 1, Name = "a", Image = "a", Price = 1, Rate = 3, AvailableStock = 1 }
                }
            };
          var mock = new Mock<IPlpItems>();
            mock.Setup(p => p.GetPlp(c)).Returns(ss);
            ////////////////////////////////////////
           var mock1= new Mock<IPdpItems>();
            mock1.Setup(p => p.Get(1));


            var s = mock.Object;

            ProductController contoroler = new ProductController(mock.Object,mock1.Object);

            var res = contoroler.Index(c);

            Assert.IsType<ViewResult>(res);
            var viewResult = res as ViewResult;
      Assert.IsAssignableFrom<BaseDto<CatalogPLPDto>>(viewResult.Model);


//            IsAssignableFrom// ersal model to view


        }
    //    [Theory()]
    //   [InlineData(It.IsAny<int>()]
        [Theory]
        [InlineData(1,-1)]
        public void Test_Get(int valid,int invalid)
        {
           

            CatalogItemPDPDto xx = new CatalogItemPDPDto
            {
                Description = "",
                PercentDiscount = 1,
                Brand = "s",
                Id = 1, OldPrice = 1,
                Name = "s",
              Price=1,Type="s",SimilarCatalogs= new List<SimilarCatalogItemDto> { new SimilarCatalogItemDto()},
              Images= new List<string> { "s"},
              Features = new List<PDPFeaturesDto>{ new PDPFeaturesDto() { Group="",Key="",Value=""} }.GroupBy(p=>p.Group),
              
            };
       

            var mock = new Mock<IPdpItems>();
            mock.Setup(p => p.Get(valid)).Returns(xx);
            int[] x = new int[] { 1, 2, 3, };
            CatlogPLPRequestDto c = new CatlogPLPRequestDto()
            {
                AvailableStock = true,
                brandId = x,
                CatalogTypeId = 1,
                pageSize = 1,
                SearchKey = "s",
                SortType = SortType.MostVisited,
                pageIndex = 1
            };
            BaseDto<CatalogPLPDto> ss = new BaseDto<CatalogPLPDto>(1, 1, 1)
            {
                Statos = true,
                Count = 1,
                Masseg = "a",
                PageIndex = 1,
                PageSize = 1,
                Data = new List<CatalogPLPDto>()
                {
                new CatalogPLPDto
                { Id = 1, Name = "a", Image = "a", Price = 1, Rate = 3, AvailableStock = 1 }
                }
     
            };
            var mock1 = new Mock<IPlpItems>();
            mock1.Setup(p => p.GetPlp(c)).Returns(ss);
            ProductController productController = new ProductController(mock1.Object, mock.Object);

            var res = productController.Get(valid);
          
            Assert.IsType<ViewResult>(res);
            var viewResult = res as  ViewResult;
            Assert.IsAssignableFrom<CatalogItemPDPDto>(viewResult.Model);

         mock.Setup(p => p.Get(invalid));

          var res2 = productController.Get(invalid);
          Assert.IsType<NotFoundResult>(res2);


        }
    }

}
