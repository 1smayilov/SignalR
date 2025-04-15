using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.DTOs;
using WebUI.DTOs.OpeningHourDto;

namespace WebUI.Controllers
{
    public class OpeningHourController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpeningHourController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7235/api/OpeningHour/Getall");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RootResponse<List<ResultOpeningHourDto>>>(jsonData);
                return View(values.Data);
            }
            return View();
        }

       

        [HttpGet]
        public async Task<IActionResult> UpdateOpeningHour(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7235/api/OpeningHour/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RootResponse<UpdateOpeningHourDto>>(jsonData);
                return View(values.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOpeningHour(UpdateOpeningHourDto updateOpeningHoursDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOpeningHoursDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7235/api/OpeningHour", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}
