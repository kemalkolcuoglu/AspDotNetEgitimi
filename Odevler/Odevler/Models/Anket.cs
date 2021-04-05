using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odevler.Models
{
    public class Anket
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100), Required]
        public string Soru { get; set; }

        [MaxLength(100), Required]
        public string ASikki { get; set; }

        [MaxLength(100), Required]
        public string BSikki { get; set; }

        [MaxLength(100), Required]
        public string CSikki { get; set; }

        [MaxLength(100), Required]
        public string DSikki { get; set; }

        public virtual bool A { get; set; }
        public virtual bool B { get; set; }
        public virtual bool C { get; set; }
        public virtual bool D { get; set; }
        public DateTime Tarih { get; set; }
    }
}
