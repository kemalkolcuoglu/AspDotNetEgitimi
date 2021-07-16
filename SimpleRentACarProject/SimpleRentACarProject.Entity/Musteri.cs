using System.ComponentModel.DataAnnotations;

namespace SimpleRentACarProject.Entity
{
    public class Musteri
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Ad { get; set; }

        [Required, MaxLength(15)]
        public string Soyad { get; set; }
    }
}
