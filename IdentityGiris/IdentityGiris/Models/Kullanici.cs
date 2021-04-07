using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityGiris.Models
{
    public class Kullanici : IdentityUser
    {
        [Required]
        public string Password { get; set; }


        public bool Cinsiyet { get; set; }
    }
}
