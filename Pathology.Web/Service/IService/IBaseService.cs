using Pathology.Web.Models;

namespace Pathology.Web.Service.IService
{
    public interface IBaseService
    {
        public Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
