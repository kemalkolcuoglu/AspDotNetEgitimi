using IcerikYonetimSistemi.Models;
using IslemKatmani;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IcerikService _icerikIslemleri;
        private readonly SayfaService _sayfaIslemleri;
        private readonly EtiketIcerikService _etiketIcerikIslemleri;
        private readonly YorumService _yorumIslemleri;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            IcerikService icerikIslemleri,
            SayfaService sayfaIslemleri,
            YorumService yorumIslemleri,
            EtiketIcerikService etiketIcerikIslemleri
        )
        {
            _sayfaIslemleri = sayfaIslemleri;
            _yorumIslemleri = yorumIslemleri;
            _etiketIcerikIslemleri = etiketIcerikIslemleri;
            _icerikIslemleri = icerikIslemleri;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Sayfa(int id)
        {
            Sayfa sayfa = _sayfaIslemleri.Sorgu().Include(x => x.Icerikler).FirstOrDefault(x => x.ID == id && x.Etkin);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        public IActionResult Icerik(int id)
        {
            Icerik icerik = _icerikIslemleri.Sorgu().Include(x => x.Yorumlar).ThenInclude(y => y.Kullanici).FirstOrDefault(x => x.ID == id && x.Etkin);

            if (icerik == null)
                return NotFound();
            ViewBag.EtiketIcerik = _etiketIcerikIslemleri.Sorgu().Where(x => x.IcerikID == id).Include(x => x.Etiket).ToList();

            ViewData["IcerikID"] = icerik.ID;

            return View(icerik);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult YorumEkle(Yorum yorum)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var userID = _userManager.GetUserId(this.User);
                    yorum.KullaniciID = userID;
                    yorum.Tarih = DateTime.Now;

                    int sonuc = _yorumIslemleri.Ekle(yorum);
                }
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Yorum Ekleme Islemi Gerçeklestirilemedi - {Tarih}", DateTime.Now);
            }
            return RedirectToAction(nameof(Icerik), new { id = yorum.IcerikID });
        }

        public IActionResult Index()
        {
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
