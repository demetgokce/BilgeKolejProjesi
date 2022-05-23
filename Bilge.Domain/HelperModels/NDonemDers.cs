using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.HelperModels
{
    public class NDonemDers
    {
        public int Id { get; set; }
        public int Yil { get; set; }
        public string Ad { get; set; }
        public int DonemId { get; set; }

        private int _donemTip;
        public int DonemTip
        {
            set { _donemTip = value; }
        }
        public string DonemAd
        {
            get { return EnumHelper.GetirDonemAdi(_donemTip); }
        }
    }

    public class NDers
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string OgretmenAd { get; set; }
    }

    public class NDersNotlu
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Ogretmen { get; set; }

        public int Sinav1 { get; set; }

        public int Sinav2 { get; set; }

        public int SonSinav { get; set; }

        public int Ortalama { get; set; }

        private int _basariDurumTip;
        public int BasariDurumTip
        {
            set { _basariDurumTip = value; }
        }

        public string BasariDurum
        {
            get
            {
                switch (_basariDurumTip)
                {
                    case (int)BasariDurumTipEnum.Basarili: return "Başarılı";
                    case (int)BasariDurumTipEnum.Basarisiz: return "Başarısız";
                    default: return "---";
                }
            }
        }

        public int DonemId { get; set; }
    }

    public class NDersDonem
    {
        public int Id { get; set; }
        public int Yil { get; set; }

        private int _donemTip;
        public int DonemTip
        {
            set { _donemTip = value; }
        }
        public string DonemAd
        {
            get { return EnumHelper.GetirDonemAdi(_donemTip); }
        }
    }

}
