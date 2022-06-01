using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
    public class Siniflar : BaseEntity
    {
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }



        [Required(ErrorMessage = "Lütfen bölümün kodunu yazınız")]
        [Display(Name = "Sinif Kodu")]
        [MinLength(3, ErrorMessage = "Bölüm kodu 3 karakterden oluşmalıdır.")]
        [MaxLength(3, ErrorMessage = "Bölüm kodu 3 karakterden oluşmalıdır.")]
        public string Kod { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }

        public ICollection<DersProgram> DersProgram { get; set; }

    }
}
