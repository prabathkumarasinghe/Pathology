using Pathology.Web.Models;


namespace Pathology.Web.Service.IService
{
    public interface ITestService
    {
        Task<ResponseDto?> GetAllTestAsync();
        Task<ResponseDto?> GetTestByIdAsync(int id);
        Task<ResponseDto?> GetTestByNameAsync(string name);
        Task<ResponseDto?> CreateTestAsync(TestDto testDto);
        Task<ResponseDto?> UpdateTestAsync(TestDto testDto);
        Task<ResponseDto?> DeleteTestAsync(int id);
    }
}
