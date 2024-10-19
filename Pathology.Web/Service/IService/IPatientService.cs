using Pathology.Web.Models;

namespace Pathology.Web.Service.IService
{
    public interface IPatientService
    {
        Task<ResponseDto?> GetPatientByTestAsync(string test);
        Task<ResponseDto?> GetAllPatientAsync();
        Task<ResponseDto?> GetPatientByNumberAsync(int number);
        Task<ResponseDto?> GetPatientByNameAsync(string name);
        Task<ResponseDto?> CreatePatientAsync(PatientDto patientDto);
        Task<ResponseDto?> UpdatePatientAsync(PatientDto patientDto);
        Task<ResponseDto?> DeletePatientAsync(int id);
    }
}
