using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class DersDto
    {

        [Required(ErrorMessage = "Lütfen dersin adını yazınız")]
        [Display(Name = "DersAdı")]
        public string DersAd { get; set; }

        [Required(ErrorMessage = "Lütfen dersin kodunu yazınız")]
        [Display(Name = "Ders Kodu")]
        [MinLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        [MaxLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        public string Kod { get; set; }

    }
}
