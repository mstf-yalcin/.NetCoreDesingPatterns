using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Adapter.Services;

namespace BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageProcess _imageProcess;
        public HomeController(ILogger<HomeController> logger, IImageProcess imageProcess)
        {
            _logger = logger;
            _imageProcess = imageProcess;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddWaterMark()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddWaterMark(IFormFile image)
        {

            if (image is { Length: > 0 })
            {
                var imageMemoryStream = new MemoryStream();

                await image.CopyToAsync(imageMemoryStream);
                _imageProcess.AddWaterMark(imageMemoryStream, "text", image.FileName);
            }


            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}