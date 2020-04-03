using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebOcrTest.Models;

namespace WebOcrTest.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }
           
            //var ImageData= new OCRClass()
            //{
            //   app_id=,
            //   app_key=,
            //   src=file.OpenReadStream().
            //}

            //HttpClient Client = new HttpClient();
            //Client.DefaultRequestHeaders.Clear();
            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
            //HttpResponseMessage httpResponseMessage = Client.PostAsync("https://api.mathpix.com/v3/latex");
            return RedirectToAction("Index");
        }
    }
}