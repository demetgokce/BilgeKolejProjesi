using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
   public class DonemDers:BaseEntity
    {
       

        [Required]
        [Display(Name = "Dönem")]
        public int DonemId { get; set; }

        [Required(ErrorMessage = "Lütfen dersi seçiniz")]
        [Display(Name = "Ders")]
        public int DersId { get; set; }

        [Required(ErrorMessage = "Lütfen dersi verecek öğretmeni seçiniz")]
        [Display(Name = "Öğretmen")]
        public int OgretmenId { get; set; }

        public virtual Donem Donem { get; set; }
        public virtual Ders Ders { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
        public virtual ICollection<OgrenciDonemDers> OgrenciDonemDers { get; set; }


    }
}
