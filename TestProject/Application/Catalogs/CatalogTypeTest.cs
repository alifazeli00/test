using Admin.EndPoint.MappingProfiles;
using Application.Catalogs;
using Application.Dto;
using AutoMapper;
using Infrastructure.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Builders;
using Xunit;

namespace TestProject.Application.Catalogs
{
    public class CatalogTypeTest
    {
        [Fact]
        public  void Create()
        {
            CatalogTypeDto x = new CatalogTypeDto()
            {

                ParentCatalogTypeId=1,
                Id=1,Type="s",
                

            };
            var datbacebuilder = new DataBaceContextBuilder();
            var dbcontext = datbacebuilder.GetdbContext();
            var mockmapper = new MapperConfiguration(p =>
            {

                p.AddProfile(new CatalogMappingProfile());
            });
            var mapper = mockmapper.CreateMapper();
            var service = new catalogType(dbcontext, mapper);
            var res = service.Create(x);
            Assert.NotNull(res);
            Assert.IsType<BaseDto>(res);

        }
    }
}
