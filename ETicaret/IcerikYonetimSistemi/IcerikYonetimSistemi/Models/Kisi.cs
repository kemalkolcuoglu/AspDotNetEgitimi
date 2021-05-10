using System.ComponentModel.DataAnnotations;

namespace IcerikYonetimSistemi.Models
{
    public class Kisi
    {
        [Required, MaxLength(11)]
        public string TCKNO { get; set; }

        [Required, MaxLength(15)]
        public string Ad { get; set; }

        [Required, MaxLength(15)]
        public string Soyad { get; set; }

        [Required, MaxLength(15)]
        public string TelefonNo { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }
    }
}
