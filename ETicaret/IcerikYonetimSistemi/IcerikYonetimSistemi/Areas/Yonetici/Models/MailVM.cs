using System.ComponentModel.DataAnnotations;

namespace IcerikYonetimSistemi.Areas.Yonetici.Models
{
    public class MailVM
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
