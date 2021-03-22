using FormDeneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FormDeneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.kurs = "Asp.net Eğtimi";
            TempData["Yer"] = "İstanbul";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.kurs = "Asp.net Eğtimi";
            ViewData["Egitmen"] = "Kemal Kolcuoglu";
            return View();
        }

        [HttpGet]
        public IActionResult VeriAl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VeriAl(AlinanVeri alinanVeri)
        {
            if (ModelState.IsValid)
                ViewBag.veri = alinanVeri.Sayi;
            else
                ViewBag.Hata = "Lütfen Değerleri Giriniz";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
