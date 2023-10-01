using ApiProjectUI.ViewModels;
using DAL.Entities;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectUI.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public InvoiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5280/api/Invoice");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<Invoice>>(jsonData);

                return View(values);
            }

            return View();
        }

        //[HttpGet]
        //public IActionResult AddInvoice()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddInvoice(InvoiceViewModel model)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var jsonData = JsonConvert.SerializeObject(model);

        //    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("http://localhost:5280/api/Invoice", stringContent);

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //public async Task<IActionResult> DeleteInvoice(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync($"http://localhost:5280/api/Invoice/{id}");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateInvoice(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:5280/api/Invoice/{id}");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<InvoiceViewModel>(jsonData);

        //        return View(values);
        //    }

        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateInvoice(InvoiceViewModel model)
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        var client = _httpClientFactory.CreateClient();

        //        var jsonData = JsonConvert.SerializeObject(model);

        //        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //        var responseMessage = await client.PutAsync("http://localhost:5280/api/Invoice", stringContent);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    return View(model);
        //}

        //public async Task<IActionResult> DetailInvoice(int id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync($"http://localhost:5280/api/Invoice/{id}");

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<InvoiceViewModel>(jsonData);

        //        return View(values);
        //    }

        //    return View();
        //}
    }
}