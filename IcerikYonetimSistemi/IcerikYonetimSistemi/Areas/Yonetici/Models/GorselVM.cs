using IcerikYonetimSistemi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Areas.Yonetici.Models
{
    public class GorselVM
    {
        public string Baslik { get; set; }
        public IFormFile Dosya{ get; set; }
    }
}
