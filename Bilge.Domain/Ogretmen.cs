using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class Ogretmen : BaseEntity
    {
       
        [Required(ErrorMessage = "Lütfen öğretim görevlisinin adını yazınız")]
        [Display(Name = "Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen öğretim görevlisinin soyadını yazınız")]
        [Display(Name = "Soyadı")]
        public string Soyad { get; set; }

        [Required]
        [MinLength(11, ErrorMessage = "T.C. kimlik numarası 11 karakterden oluşmalıdır.")]
        [MaxLength(11, ErrorMessage = "T.C. kimlik numarası 11 karakterden oluşmalıdır.")]
        [Display(Name = "T.C. Kimlik No")]
        public string TcNo { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Posta Adresi")]
        public string EPosta { get; set; }
      
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarasi")]
        public string Gsm { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DogumTarih { get; set; }

        [Required]
        [Display(Name = "İşe Giriş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GirisTarih { get; set; }

        [Display(Name = "İşten Çıkış Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CikisTarih { get; set; }

        [Required]
        public int DersId { get; set; }

        public virtual Sinif Ders { get; set; }
        public virtual ICollection<DonemDers> DonemDersler { get; set; }
        public virtual ICollection<DersProgram> DersProgram { get; set; }
        public int SinifId { get; set; }
    }
}
