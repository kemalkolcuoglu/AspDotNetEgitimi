using System.ComponentModel.DataAnnotations;

namespace SimpleRentACarProject.Entity
{
    public class Arac
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string Marka { get; set; }

        [Required, MaxLength(20)]
        public string Model { get; set; }

        [Required, MaxLength(9)]
        public string Plaka { get; set; }

        [Required]
        public int VitesTipi { get; set; }
    }
}
