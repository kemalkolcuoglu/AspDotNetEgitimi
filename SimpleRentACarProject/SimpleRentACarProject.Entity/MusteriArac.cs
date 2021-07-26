using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleRentACarProject.Entity
{
    public class MusteriArac
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MusteriId { get; set; }

        [Required]
        public int AracId { get; set; }

        [ForeignKey(nameof(AracId))]
        public Arac Arac { get; set; }

        [ForeignKey(nameof(MusteriId))]
        public Musteri Musteri { get; set; }
    }
}
