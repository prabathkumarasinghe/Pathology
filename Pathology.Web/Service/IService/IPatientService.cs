using Pathology.Web.Models;

namespace Pathology.Web.Service.IService
{
    public interface IPatientService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> GetCouponByNameAsync(string name);
        Task<ResponseDto?> CreateCouponsAsync(PatientDto couponDto);
        Task<ResponseDto?> UpdateCouponsAsync(PatientDto couponDto);
        Task<ResponseDto?> DeleteCouponsAsync(int id);
    }
}
