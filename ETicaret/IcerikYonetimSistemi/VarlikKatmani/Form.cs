using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Form
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50), DisplayName("Ad Soyad")]
        public string AdSoyad { get; set; }

        [Required, MaxLength(100), DataType(DataType.EmailAddress), DisplayName("E-Posta")]
        public string EPosta { get; set; }

        [Required, MaxLength(15), DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

        [Required, MaxLength(128)]
        public string Konu { get; set; }

        [Required, MaxLength(1000)]
        public string Detay { get; set; }
    }
}
