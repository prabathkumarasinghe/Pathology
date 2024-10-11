using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pathology.Services.PatientAPI.Data;
using Pathology.Services.PatientAPI.Models;
using Pathology.Services.PatientAPI.Models.Dto;

namespace Pathology.Services.PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;

        public PatientAPIController(AppDbContext db)
        {
            _db = db;
            _response   = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Patient> objList = _db.patients.ToList();
                _response.Result = objList;
                
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;


        }
        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Patient obj = _db.patients.First(u=>u.PatientNumber==id);
                _response.Result = obj;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
    }
}
