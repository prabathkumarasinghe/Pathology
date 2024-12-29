using AutoMapper;
using Pathology.Services.TestAPI.Models;
using Pathology.Services.TestAPI.Models.Dto;
using static Azure.Core.HttpHeader;

namespace Pathology.Services.TestAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TestDto, Test>();
                config.CreateMap<Test, TestDto>();

            });
            return mappingConfig;



        }
    }
}
