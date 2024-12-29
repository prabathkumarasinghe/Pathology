using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pathology.Services.TestAPI.Data;
using Pathology.Services.TestAPI.Model.Dto;
using Pathology.Services.TestAPI.Models;
using Pathology.Services.TestAPI.Models.Dto;


namespace Pathology.Services.TestAPI.Controllers
{
    [Route("api/test")]
    [ApiController]
	//[Authorize(Roles = "Admin")]
	public class TestAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public TestAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;

        }

        [HttpGet]
		[Authorize]
		public ResponseDto Get()
        {
            try
            {
                IEnumerable<Test> objList = _db.tests.ToList();
                _response.Result = _mapper.Map<IEnumerable<TestDto>>(objList);

            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;


        }
        //[HttpGet]
        //[Route("{id:int}")]
        //public object Get(int id)
        //{
        //    try
        //    {
        //        Test obj = _db.tests.First(u => u.TestId == id);
        //        _response.Result = _mapper.Map<TestDto>(obj);
        //    }

        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.Message;
        //    }
        //    return _response;


        //}
        [HttpGet]
        [Route("GetByTest/{test}")]
        public ResponseDto GetByTest(string test)
        {
            try
            {
                Test obj = _db.tests.First(u => u.Name.ToLower() == test.ToLower());
                _response.Result = _mapper.Map<TestDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        //[HttpGet]
        //[Route("GetByName/{name}")]
        //public ResponseDto GetByName(string name)
        //{
        //    try
        //    {
        //        Test obj = _db.tests.First(u => u.Name.ToLower() == name.ToLower());
        //        _response.Result = _mapper.Map<TestDto>(obj);
        //    }

        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.Message;
        //    }
        //    return _response;


        //}

        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public ResponseDto Post([FromBody] TestDto testDto)
        {
            try
            {
                Test obj = _mapper.Map<Test>(testDto);
                _db.tests.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TestDto>(obj);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.Message = e.Message;
            }
            return _response;

        }
        [HttpPut]
        public ResponseDto Update([FromBody] TestDto testDto)
        {
            try
            {
                Test obj = _mapper.Map<Test>(testDto);
                _db.tests.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<TestDto>(obj);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


        }
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Test obj = _db.tests.First(u => u.TestId == id);
                _db.tests.Remove(obj);
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
