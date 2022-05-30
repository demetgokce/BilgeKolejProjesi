using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
   public class OgrenciDonemDers:BaseEntity
    {

       

        [Required]
        public int DonemDersId { get; set; }

        [Required]
        public int OgrenciId { get; set; }

        public int Sinav1 { get; set; }
        public int Sinav2 { get; set; }
        public int SonSinav { get; set; }
        public int Ortalama { get; set; }
        public int BasariDurumTip { get; set; }

        public virtual DonemDers DonemDers { get; set; }
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
