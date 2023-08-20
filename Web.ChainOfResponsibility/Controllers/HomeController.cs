﻿using BaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.ChainOfResponsibility.ChainOfResponsibility;
using Web.ChainOfResponsibility.Models;

namespace BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppIdentityDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppIdentityDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> SendEmail()
        {

            var products = await _context.Products.ToListAsync();

            var ExcelProcessHandler = new ExcelProcessHandler<Product>();
            var zipFileProcessHandler = new ZipFileProcessHandler<Product>();
            var sendEmailProcessHandler = new SendEmailProcessHandler("test@gmail.com", "fileName.zip",_logger);
            
            ExcelProcessHandler.SetNext(zipFileProcessHandler).SetNext(sendEmailProcessHandler);
            ExcelProcessHandler.Handle(products);


            return View(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}