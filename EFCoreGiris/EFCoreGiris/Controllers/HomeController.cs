using EFCoreGiris.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreGiris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EFCoreGirisContext context;

        public HomeController(EFCoreGirisContext eFCoreGirisContext, ILogger<HomeController> logger)
        {
            context = eFCoreGirisContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Kitap> kitaplar = context.Kitaplar.ToList();
            return View(kitaplar);
        }

        public IActionResult Privacy()
        {
            Yazar yazar = context.Yazarlar.FirstOrDefault(x => x.ID == 1);
            Kitap kitap = new Kitap()
            {
                Ad = "Kaşağı",
                Fiyat = 10.05,
                Tur = "Hikaye",
                Yazar = yazar
            };
            context.Kitaplar.Add(kitap);
            context.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
