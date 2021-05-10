using IslemKatmani;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class GorselController : TemelController
    {
        private readonly GorselService _gorselIslemleri;
        private readonly ILogger<GorselController> _logger;
        private readonly IWebHostEnvironment _hostingEnv;

        public GorselController(ILogger<GorselController> logger, GorselService gorselIslemleri, IWebHostEnvironment hostingEnv)
        {
            _gorselIslemleri = gorselIslemleri;
            _logger = logger;
            _hostingEnv = hostingEnv;
        }

        public IActionResult Liste()
        {
            List<Gorsel> gorseller = _gorselIslemleri.Sorgu().OrderByDescending(x => x.ID).ToList();
            return View(gorseller);
        }

        public IActionResult Yukle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Yukle(string baslik, IFormFile dosya)
        {
            try 
            {
                if (dosya == null)
                    throw new Exception("Herhangi bir gorsel secilmedi");

                string wwwrootPath = _hostingEnv.WebRootPath;
                string fileName = Path.GetFileName(dosya.FileName);
                string filePath = Path.Combine(wwwrootPath, "default\\images\\blog", fileName);
                using (FileStream fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await dosya.CopyToAsync(fileSteam);
                }
                Gorsel gorsel = new Gorsel()
                {
                    Baslik = baslik,
                    Yol = fileName,
                    Etkin = true
                };
                int sonuc = _gorselIslemleri.Ekle(gorsel);
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste));
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Gorsel yukleme islemi gerceklestirilemedi - {Tarih}", DateTime.Now);
            }
            return View();
        }
    }
}
