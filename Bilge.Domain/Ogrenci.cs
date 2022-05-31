using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
   public class Ogrenci: BaseEntity
    {



        

        [Required(ErrorMessage = "Lütfen öğrencinin adını yazınız")]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Lütfen öğrencinin soyadını yazınız")]
        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }

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
        [Display(Name = " Telefon Numarasi")]
        public string Gsm { get; set; }

        [Required]
        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DogumTarih { get; set; }

        [Required]
        [Display(Name = "Okula Giriş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GirisTarih { get; set; }

        [Display(Name = "Okuldan Çıkış Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CikisTarih { get; set; }
         public int SinifId { get; set; }
        public virtual Sinif Sinif { get; set; }
        public int DersId { get; set; }
        public virtual Sinif Ders { get; set; }
        public virtual ICollection<DersProgram> DersPrograms { get; set; }
        public virtual ICollection<Yoklama> Yoklamas { get; set; }
        public virtual ICollection<OgrenciDonemDers> OgrenciDonemDers{ get; set; }
        public virtual ICollection<DonemDers> DonemDers { get; set; }
    }
}
