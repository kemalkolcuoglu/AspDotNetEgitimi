using System.ComponentModel;

namespace IcerikYonetimSistemi.Models
{
    public class KartBilgileri
    {
        [DisplayName("Kart Numarası")]
        public string KartNumarasi { get; set; }

        [DisplayName("Kart Sahibi")]
        public string KartSahibi { get; set; }

        [DisplayName("Güvenlik Kodu")]
        public string GuvenlikKodu { get; set; }

        [DisplayName("Son Kullanma Tarihi (AY)")]
        public int SonTarihAy { get; set; }

        [DisplayName("Son Kullanma Tarihi (YIL)")]
        public int SonTarihYil { get; set; }

        [DisplayName("Kart Tipi")]
        public int KartTipi { get; set; }
    }
}
