using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Models
{
    public class Etiket
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Etiket İçerik ID")]
        public int EtiketIcerikID { get; set; }

        [Required, MaxLength(20), DisplayName("Başlık")]
        public string Baslik { get; set; }

        [ForeignKey(nameof(EtiketIcerikID))]
        public virtual EtiketIcerik EtiketIcerik { get; set; }
    }
}
