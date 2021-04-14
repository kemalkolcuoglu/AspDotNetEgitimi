using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Models
{
    public abstract class TemelModel
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(126), DisplayName("SEO Title")]
        public string SEOTitle { get; set; }

        [Required, MaxLength(256), DisplayName("SEO Description")]
        public string SEODescription { get; set; }

        [Required, MaxLength(100), DisplayName("Başlık")]
        public string Baslik { get; set; }

        [MaxLength(15), DisplayName("Ek Alan")]
        public string EkAlan { get; set; }

        [DefaultValue(true)]
        public bool Etkin { get; set; }
    }
}
