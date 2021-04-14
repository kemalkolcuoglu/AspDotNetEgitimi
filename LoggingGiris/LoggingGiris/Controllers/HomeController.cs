using LoggingGiris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingGiris.Controllers
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
            try
            {
                throw new Exception("Benim Hatam");
            }
            catch (Exception exp)
            {
                _logger.LogError(CustomLogEvent.GoruntulemeIslemleri, exp, "Hatayi Yakaladim - {Ahmet}", DateTime.Now);
            }
            _logger.LogError("Deneme icin");
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

    public class CustomLogEvent
    {
        public const int GoruntulemeIslemleri = 10020;
        public const int SilmeIslemleri = 10025;
    }
}
