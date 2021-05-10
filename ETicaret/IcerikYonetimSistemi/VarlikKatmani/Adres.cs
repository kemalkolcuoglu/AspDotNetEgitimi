using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VarlikKatmani
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }

        [Required, DisplayName("İl")]
        public int Il { get; set; }

        [Required, DisplayName("İlçe")]
        public int Ilce { get; set; }

        [Required, DisplayName("Açık Adres")]
        public string AcikAdres { get; set; }

        [Required, DisplayName("Adres Sahibi")]
        public string Kisi { get; set; }
    }
}
