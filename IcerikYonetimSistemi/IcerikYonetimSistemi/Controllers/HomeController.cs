using IcerikYonetimSistemi.Data;
using IcerikYonetimSistemi.Models;
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

namespace IcerikYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Sayfa(int id)
        {
            Sayfa sayfa = _context.Sayfa.Include(x => x.Icerikler).FirstOrDefault(x => x.ID == id && x.Etkin);

            if (sayfa == null)
                return NotFound();

            return View(sayfa);
        }

        public IActionResult Icerik(int id)
        {
            Icerik icerik = _context.Icerik.Include(x => x.Yorumlar).ThenInclude(y => y.Kullanici).FirstOrDefault(x => x.ID == id && x.Etkin);

            if (icerik == null)
                return NotFound();
            ViewBag.EtiketIcerik = _context.EtiketIcerik.Where(x => x.IcerikID == id).Include(x => x.Etiket).ToList();

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

                    _context.Yorum.Add(yorum);
                    int sonuc = _context.SaveChanges();
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
