using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Controllers
{
    public class PanelController : TemelController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
