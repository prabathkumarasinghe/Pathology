
using Pathology.Web.Models;
using Pathology.Web.Service.IService;
using Pathology.Web.Utility;

namespace Pathology.Web.Service
{
    public class TestService : ITestService
    {
        private readonly IBaseService _baseService;
        public TestService(IBaseService baseService)
        {
            _baseService = baseService;
        }

       

        public async Task<ResponseDto?> CreateTestAsync(TestDto testDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = testDto,
                Url = SD.TestAPIBase + "/api/test",
              //  ContentType = SD.ContentType.MultipartFormData
            });
        }



        public async Task<ResponseDto?> DeleteTestAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.TestAPIBase + "/api/test/" + id
            });
        }

        public async Task<ResponseDto?> GetAllTestAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/test"
            });
        }

        //public async Task<ResponseDto?> GetTestAsync(string testCode)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.GET,
        //        Url = SD.TestAPIBase + "/api/Test/GetByCode/" + testCode
        //    });
        //}

        public async Task<ResponseDto?> GetTestByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/test/" + name
            });
        }
        public async Task<ResponseDto?> GetTestByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.TestAPIBase + "/api/test/" + id
            });
        }

        public async Task<ResponseDto?> UpdateTestAsync(TestDto testDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = testDto,
                Url = SD.TestAPIBase + "/api/test"
                //  ContentType = SD.ContentType.MultipartFormData
            });
        }

    }
}
