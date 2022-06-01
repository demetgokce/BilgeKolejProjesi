using Bilge.Domain;
using System;
using System.ComponentModel.DataAnnotations;

lausing Okul.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgrenciDto
    {
        [Required(ErrorMessage ="Ad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyad Alani Boş Olamaz")]
        [MaxLength(50)]
        public string Soyadi { get; set; }


        [Required(ErrorMessage = "TCNo Alani Boş Olamaz")]
        [MaxLength(11)]
        public string TcNo { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        public string Gsm { get; set; }

        //[Required(ErrorMessage ="Cisiyet alani Zorunludur")]
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }

        public int SinifId { get; set; }
        public Siniflar Siniflar { get; set; }


    }
}
