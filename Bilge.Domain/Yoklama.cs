using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class Yoklama:BaseEntity
    {
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }

        public DateTime Tarih { get; set; }

        public DateTime Saat { get; set; }

        public int DersProgramId { get; set; }
        public DersProgram DersProgram { get; set; }
    
       


    }
}
