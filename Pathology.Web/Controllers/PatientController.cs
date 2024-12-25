using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pathology.Web.Models;
using Pathology.Web.Service.IService;
using Pathology.Web.Utility;

namespace Pathology.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> PatientIndex()
        {
            List<PatientDto>? list = new();

            ResponseDto? response = await _patientService.GetAllPatientAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PatientDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> PatientCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PatientCreate(PatientDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _patientService.CreatePatientAsync(model);

                if (response != null && response.IsSuccess)
                {
                    //TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(PatientIndex));
                }
                //else
                //{
                //    TempData["error"] = response?.Message;
                //}
            }
            return View(model);
        }
        public async Task<IActionResult> PatientDelete(int patientId)
        {
            ResponseDto? response = await _patientService.GetPatientByNumberAsync(patientId);

            if (response != null && response.IsSuccess)
            {
                PatientDto? model = JsonConvert.DeserializeObject<PatientDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> PatientDelete(PatientDto patientDto)
        {
            ResponseDto? response = await _patientService.DeletePatientAsync(patientDto.PatientNumber);

            if (response != null && response.IsSuccess)
            {

                return RedirectToAction(nameof(PatientIndex));
            }

            return View(patientDto);
        }
        public async Task<IActionResult> PatientUpdate(int patientId)
        {
            ResponseDto? response = await _patientService.GetPatientByNumberAsync(patientId);

            if (response != null && response.IsSuccess)
            {
                PatientDto? model = JsonConvert.DeserializeObject<PatientDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        
        [HttpPost]
       
        public async Task<IActionResult> UpdateVilla(PatientDto model)
        {
            //if (ModelState.IsValid)
            //{
              //  TempData["success"] = "Villa updated successfully";
                //var response = await _villaService.UpdateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                //if (response != null && response.IsSuccess)
                //{
                //    return RedirectToAction(nameof(IndexVilla));
                //}
                ResponseDto? response = await _patientService.UpdatePatientAsync(model);

                if (response != null && response.IsSuccess)
                {

                    return RedirectToAction(nameof(PatientIndex));
                }

                return View(model);
            //}
           // TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
