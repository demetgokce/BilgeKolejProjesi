using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
   public class Veli:BaseEntity
    {
        

        [Required(ErrorMessage = "Lütfen öğrencinin adını yazınız")]
        [Display(Name = "Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen öğrencinin soyadını yazınız")]
        [Display(Name = "Soyadı")]
        public string Soyad { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "T.C. kimlik numarası 11 karakterden oluşmalıdır.")]
        [MaxLength(11, ErrorMessage = "T.C. kimlik numarası 11 karakterden oluşmalıdır.")]
        [Display(Name = "T.C. Kimlik No")]
        public string KimlikNo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Posta Adresi")]
        public string EPosta { get; set; }



        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = " Telefon Numarasi")]
        public string Gsm { get; set; }
        public virtual ICollection<Yoklama> Yoklamas { get; set; }
        public virtual ICollection<DersProgram> DersProgram { get; set; }
        public virtual ICollection<OgrenciDonemNot> OgrenciDonemNot { get; set; }
    }
}
