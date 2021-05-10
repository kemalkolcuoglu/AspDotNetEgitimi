using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VarlikKatmani
{
    public class KullaniciAdres
    {
        [Key]
        public int Id { get; set; }

        public string KullaniciId { get; set; }

        public int AdresId { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public IdentityUser Kullanici { get; set; }

        [ForeignKey(nameof(AdresId))]
        public Adres Adres { get; set; }
    }
}
