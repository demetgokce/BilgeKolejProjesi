using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class Donem:BaseEntity
    {


        

        [Required(ErrorMessage = "Lütfen dönemin yılını seçiniz")]
        [Display(Name = "DonemBaslangıcTarihi")]
        public int DonemBaslangıcTarihi{ get; set; }

        [Required(ErrorMessage = "Lütfen dönemin yılını seçiniz")]
        [Display(Name = "DonemBitisTarihi")]

       
        
        public int DonemBitisTarihi { get; set; }

        [Required(ErrorMessage = "Lütfen dönemin tipi seçiniz")]
        [Display(Name = "Dönem Tipi")]
        public int DonemTip { get; set; }
        [Required(ErrorMessage = "Lütfen dönemin yılını seçiniz")]
        [Display(Name = "Yıl")]
        public int Yil { get; set; }




        public virtual ICollection<DonemDers> DonemDersler { get; set; }
    }
}
