using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IcerikYonetimSistemi.Models
{
    public class Icerik : TemelModel
    {
        public Icerik()
        {
            Yorumlar = new List<Yorum>();
        }

        [DisplayName("Sayfa ID")]
        public int SayfaID { get; set; }

        //[DisplayName("Etiket İçerik ID")]
        //public int EtiketIcerikID { get; set; }

        [Required]
        public string Detay{ get; set; }

        [Required, MaxLength(150), DataType(DataType.ImageUrl), DisplayName("Görsel")]
        public string Gorsel{ get; set; }

        [DisplayName("Ekleme Tarihi")]
        public DateTime EklemeTarihi { get; set; }

        [DisplayName("Düzenleme Tarihi")]
        public DateTime DuzenlemeTarihi { get; set; }

        [ForeignKey(nameof(SayfaID))]
        public virtual Sayfa Sayfa { get; set; }

        //[ForeignKey(nameof(EtiketIcerikID))]
        //public virtual EtiketIcerik EtiketIcerik { get; set; }

        public virtual List<Yorum> Yorumlar { get; set; }

        public virtual List<int> EtiketList { get; set; }
    }
}
