using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pathology.Web.Models;
using Pathology.Web.Service.IService;


namespace Pathology.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITestService _testService;
       // private readonly ICartService _cartService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        //    _cartService = cartService;
        }


        public async Task<IActionResult> Index()
        {
            List<TestDto>? list = new();

            ResponseDto? response = await _testService.GetAllTestAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TestDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> TestDetails(int testId)
        {
            TestDto? model = new();

            ResponseDto? response = await _testService.GetTestByIdAsync(testId);

            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<TestDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(model);
        }


        //[Authorize]
        //[HttpPost]
        //[ActionName("TestDetails")]
        //public async Task<IActionResult> TestDetails(TestDto testDto)
        //{
        //    CartDto cartDto = new CartDto()
        //    {
        //        CartHeader = new CartHeaderDto
        //        {
        //            UserId = User.Claims.Where(u => u.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value
        //        }
        //    };

        //    CartDetailsDto cartDetails = new CartDetailsDto()
        //    {
        //        Count = testDto.Count,
        //        TestId = testDto.TestId,
        //    };

        //    List<CartDetailsDto> cartDetailsDtos = new() { cartDetails };
        //    cartDto.CartDetails = cartDetailsDtos;

        //    ResponseDto? response = await _cartService.UpsertCartAsync(cartDto);

        //    if (response != null && response.IsSuccess)
        //    {
        //        TempData["success"] = "Item has been added to the Shopping Cart";
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        TempData["error"] = response?.Message;
        //    }

        //    return View(testDto);
        //}


        //public IActionResult Privacy()
        //{
        //	return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
