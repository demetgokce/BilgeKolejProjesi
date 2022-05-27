using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.HelperModels
{
  public  class EnumHelper
    {
        public static string GetirDonemAdi(int tip)
        {
            return GetirDonemAdi((DonemTipEnum)tip);
        }
        public static string GetirDonemAdi(DonemTipEnum tip)
        {
            switch (tip)
            {
                case DonemTipEnum.Bahar: return "Bahar";
                case DonemTipEnum.Guz: return "Güz";
                case DonemTipEnum.Yaz: return "Yaz";
                default: return "";
            }
        }
    }
}
