using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilterAttributeGiris.Models
{
    public class Kisi
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(15)]
        public string Ad { get; set; }
    }
}
