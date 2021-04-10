using DIGiris.Models;
using DIGiris.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DIGiris.Controllers
{
    public class HomeController : Controller
    {
        ILog _log;
        public HomeController(ILog log)
        {
            _log = log;
        }

        public ActionResult Index()
        {
            // logic 
            _log.Log("Index Methodu İşlendi");
            return View();
        }

        public IActionResult Privacy()
        {
            _log.Log("Privacy Methodu İşlendi");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
