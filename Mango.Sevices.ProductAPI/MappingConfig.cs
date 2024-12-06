using AutoMapper;
using Mango.Sevices.ProductAPI.Models;
using Mango.Sevices.ProductAPI.Models.Dtos;

namespace Mango.Sevices.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductDto,Product>();
                config.CreateMap<Product, ProductDto>();

            });
            return mappingConfig;
        }
    }
}
