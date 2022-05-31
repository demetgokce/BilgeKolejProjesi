using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class DersProgram :BaseEntity
    {
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }


        public int DersId { get; set; }
        public  Sinif Ders{ get; set; }


        public int OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; }

        public ICollection<Yoklama> Yoklamalar { get; set; }

    }
}
