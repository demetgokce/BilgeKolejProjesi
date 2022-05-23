using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class Sinif:BaseEntity
    {
       

        [Required(ErrorMessage = "Lütfen sinif adini yaziniz")]
        [Display(Name = "Sinif Adi")]
       
        public string SinifAdi { get; set; }
        [Required(ErrorMessage = "Lütfen sinif kodunu yazınız")]
        [Display(Name = "Sinif Kodu")]
        [MinLength(3, ErrorMessage = "Sinif kodu 3 karakterden oluşmalıdır.")]
        [MaxLength(3, ErrorMessage = "Sinif kodu 3 karakterden oluşmalıdır.")]
        public string Kod { get; set; }
        public int Kapasite { get; set; }

        public virtual ICollection<Ogrenci> Ogrenciler { get; set; }
        public virtual ICollection<Ders> Dersler { get; set; }

        public virtual ICollection<DersProgram> DersPrograms { get; set; }
      
    }
}
