using IslemKatmani;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using VarlikKatmani;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class YorumController : TemelController
    {
        private readonly ILogger<YorumController> _logger;
        private readonly YorumService _yorumIslemleri;
        private readonly UserManager<IdentityUser> _userManager;
        public YorumController(ILogger<YorumController> logger, UserManager<IdentityUser> userManager, YorumService yorumIslemleri)
        {
            _logger = logger;
            _yorumIslemleri = yorumIslemleri;
            _userManager = userManager;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        // id: IcerikID
        public IActionResult Liste(int id)
        {
            List<Yorum> yorumlar = _yorumIslemleri.ListeFiltre(x => x.IcerikID == id);
            return View(yorumlar);
        }

        #endregion

        #region Ekleme Islemleri

        // id: IcerikID
        public IActionResult Ekle(int? id)
        {
            if(id == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        public IActionResult Ekle(int id, Yorum yorum)
        {
            try
            {
                string userId = _userManager.GetUserId(this.User);
                yorum.KullaniciID = userId;
                yorum.Tarih = DateTime.Now;
                yorum.IcerikID = id;
                int sonuc = _yorumIslemleri.Ekle(yorum);
                if (sonuc >= 1)
                    return RedirectToAction(nameof(Liste), new { id });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Yorum Ekleme islemi gerceklestirilemedi! - {Tarih}", DateTime.Now);
            }
            return View(yorum);
        }

        #endregion

        #region Duzenleme Islemleri

        public IActionResult Duzenle(int? id, int? yorumId)
        {
            if (id == null || yorumId == null)
                return NotFound();

            Yorum yorum = _yorumIslemleri.Bul(x => x.ID == yorumId);

            if (yorum == null)
                return NotFound();
            return View(yorum);
        }

        #endregion
    }
}
