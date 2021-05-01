using IcerikYonetimSistemi.Data;
using IcerikYonetimSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class YorumController : Controller
    {
        private readonly ILogger<YorumController> _logger;
        private readonly ApplicationDbContext _context;
        public YorumController(ILogger<YorumController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // CRUD - Create, Read, Update, Delete
        #region Okuma Islemleri

        // id: IcerikID
        public IActionResult Liste(int id)
        {
            List<Yorum> yorumlar = _context.Yorum.ToList();
            return View(yorumlar);
        }

        #endregion
    }
}
