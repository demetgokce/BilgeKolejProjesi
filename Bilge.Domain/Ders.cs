using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
   public class Ders:BaseEntity
    {

        

        [Required(ErrorMessage = "Lütfen dersin adını yazınız")]
        [Display(Name = "DersAdı")]
        public string DersAd { get; set; }

        [Required(ErrorMessage = "Lütfen dersin kodunu yazınız")]
        [Display(Name = "Ders Kodu")]
        [MinLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        [MaxLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        public string Kod { get; set; }

      

       


        public virtual ICollection<DonemDers> DonemDersler { get; set; }
        public ICollection<Ogretmen> Ogretmenler { get; set; }
        public ICollection<DersProgram> DersProgramlar { get; set; }

    }
}
