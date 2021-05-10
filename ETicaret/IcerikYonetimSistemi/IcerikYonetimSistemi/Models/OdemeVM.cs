using VarlikKatmani;

namespace IcerikYonetimSistemi.Models
{
    public class OdemeVM
    {
        public KartBilgileri KartBilgileri { get; set; }
        public AdresVM FaturaAdresi { get; set; }
        public Kisi Kisi { get; set; }
        public bool SozlesmeOnay { get; set; }
        public decimal OdenecekTutar { get; set; }
    }
}
