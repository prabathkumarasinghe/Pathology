using AutoMapper;
using Pathology.Services.PatientAPI.Models;
using Pathology.Services.PatientAPI.Models.Dto;
using static Azure.Core.HttpHeader;

namespace Pathology.Services.PatientAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PatientDto, Patient>();
                config.CreateMap<Patient, PatientDto>();

            });
            return mappingConfig;



        }
    }
}
