using Application.Services.Catalogs.CatalogTypes.CRUDService;
using ApplicationTest.Builders;
using AutoMapper;
using Infrastructure.MappingProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationTest.CatalogTypeTest
{
    public class GetListTest
    {
        [Fact]
        public void Return_list_of_CatalogType()
        {
            var dataBaseBuilder = new DataBaseBuilder();
            var dbContext = dataBaseBuilder.GetDbContext();

            var mockMapper = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile(new CatalogMappingProfile());
              });
            var mapper = mockMapper.CreateMapper();

            var service = new CatalogTypeService(dbContext, mapper);

            service.Add(new CatalogTypeDto
            {
                Id = 3,
                Type = "m16"
            });
            service.Add(new CatalogTypeDto
            {
                Id = 7,
                Type = "a12"
            });

            var result = service.GetList(null, 1, 20);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
