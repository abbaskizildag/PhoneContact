using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhoneContact.Shared.Dtos;
using PhoneContact.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneContact.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly HttpClient _httpClient;

        public HomeController( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            ContactResponse contactResult;


            _httpClient.BaseAddress = new Uri("https://localhost:44365/");

            var response = await _httpClient.GetAsync("/api/Contacts");
            if (response.IsSuccessStatusCode)
            {
                var test = await response.Content.ReadAsStringAsync();
                contactResult = JsonConvert.DeserializeObject<ContactResponse>(test);

            }
            else
            {
                contactResult = null;
            }
            return View(contactResult);
        }


        public IActionResult Privacy()
        {
            return View();
        }

    }
}
