using Pathology.Web.Models;
using Pathology.Web.Service.IService;
using Pathology.Web.Utility;
using static Pathology.Web.Utility.SD;
using System;

namespace Pathology.Web.Service
{
    public class PatientService : IPatientService
    {
        private readonly IBaseService _baseService;
        public PatientService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponsAsync(PatientDto patientDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = patientDto,
                Url = SD.PatientAPIBase + "/api/patient"
            });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.PatientAPIBase + "/api/patient/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PatientAPIBase + "/api/patient"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string test)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PatientAPIBase + "/api/patient/GetByTest/" + test
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PatientAPIBase + "/api/patient/" + id
            });
        }
         public async Task<ResponseDto?> GetCouponByNameAsync(string name)
        {
             return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                    Url = SD.PatientAPIBase + "/api/patient/GetByName/" + name
            });
         }
        
        public async Task<ResponseDto?> UpdateCouponsAsync(PatientDto patientDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = patientDto,
                Url = SD.PatientAPIBase + "/api/patient"
            });
        }
    }
}
