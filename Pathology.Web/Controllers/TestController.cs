using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pathology.Web.Models;
using Pathology.Web.Service.IService;

namespace Pathology.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }


        public async Task<IActionResult> TestIndex()
        {
            List<TestDto>? list = new();

            ResponseDto? response = await _testService.GetAllTestAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TestDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> TestCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestCreate(TestDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _testService.CreateTestAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Test created successfully";
                    return RedirectToAction(nameof(TestIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> TestDelete(int testId)
        {
            ResponseDto? response = await _testService.GetTestByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                TestDto? model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> TestDelete(TestDto testDto)
        {
            ResponseDto? response = await _testService.DeleteTestAsync(testDto.TestId);

            if (response != null && response.IsSuccess)
            {

                return RedirectToAction(nameof(TestIndex));
            }

            return View(testDto);
        }

        public async Task<IActionResult> TestUpdate(int testId)
        {
            ResponseDto? response = await _testService.GetTestByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                TestDto? model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> TestUpdate(TestDto testDto)
        {
            ResponseDto? response = await _testService.UpdateTestAsync(testDto);

            if (response != null && response.IsSuccess)
            {

                return RedirectToAction(nameof(TestIndex));
            }

            return View(testDto);
        }
    }
}
