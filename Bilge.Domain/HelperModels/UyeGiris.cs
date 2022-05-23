using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class UyeGiris
    {

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }


    }
}
