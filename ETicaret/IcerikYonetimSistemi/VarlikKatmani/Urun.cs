using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Urun : TemelModel
    {
        public Urun()
        {
            UrunGaleri = new List<UrunGaleri>();
            UrunYorum = new List<UrunYorum>();
        }

        [Required, DataType(DataType.Currency), DisplayName("Fiyat")]
        public decimal Fiyat { get; set; }

        [Required, DataType(DataType.Currency), DisplayName("İndirimli Fiyat")]
        public decimal IndirimliFiyat { get; set; }

        [Required, MaxLength(1000), DisplayName("Kısa Açıklama")]
        public string KisaAciklama { get; set; }

        [Required]
        public string Detay { get; set; }

        [Required]
        public sbyte Beden { get; set; }

        [Required, MaxLength(64), DisplayName("Görsel")]
        public string Gorsel { get; set; }

        [Required, MaxLength(32)]
        public string Marka { get; set; }

        public double Miktar { get; set; }

        public int Birim { get; set; }

        [Required, DisplayName("Kategori")]
        public int KategoriId { get; set; }

        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }

        public List<UrunYorum> UrunYorum { get; set; }
        public List<UrunGaleri> UrunGaleri { get; set; }
    }
}
