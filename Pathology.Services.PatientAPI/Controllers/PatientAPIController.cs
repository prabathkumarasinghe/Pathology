using AutoMapper;
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
        private IMapper _mapper; 

        public PatientAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response   = new ResponseDto();
            _mapper = mapper;

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Patient> objList = _db.patients.ToList();
                _response.Result = _mapper.Map<IEnumerable<PatientDto>>(objList);
                
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
                _response.Result = _mapper.Map<PatientDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        [HttpGet]
        [Route("GetByCode/{test}")]
        public ResponseDto GetByCode(string test)
        {
            try
            {
                Patient obj = _db.patients.First(u => u.TestType.ToLower() == test.ToLower());
                _response.Result = _mapper.Map<PatientDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDto GetByName(string name)
        {
            try
            {
                Patient obj = _db.patients.First(u => u.PatientName.ToLower() == name.ToLower());
                _response.Result = _mapper.Map<PatientDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }

        [HttpPost]       
        public ResponseDto Post([FromBody] PatientDto patientDto)
        {
            try
            {
                Patient obj = _mapper.Map<Patient>(patientDto);
                _db.patients.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PatientDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        [HttpPut]
        public ResponseDto Update([FromBody] PatientDto patientDto)
        {
            try
            {
                Patient obj = _mapper.Map<Patient>(patientDto);
                _db.patients.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<PatientDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Patient obj = _db.patients.First(u=>u.PatientNumber==id);
                _db.patients.Remove(obj);
                _db.SaveChanges();

               
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
