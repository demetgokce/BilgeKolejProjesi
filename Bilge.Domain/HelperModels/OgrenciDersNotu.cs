using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.HelperModels
{
  public  class OgrenciDersNotu
    {
        public int Id { get; set; }
        public string TcNo { get; set; }
        public string AdSoyad { get; set; }
        public int Sinav1 { get; set; }
        public int Sinav2 { get; set; }
        public int SonSinav { get; set; }
        public int Ortalama { get; set; }
    }
    public class OgrenciDersNotuKayit
    {
        public int Id { get; set; }
        public int Sinav1 { get; set; }
        public int Sinav2 { get; set; }
        public int SonSinav { get; set; }
        public int Ortalama { get; set; }
    }
}
