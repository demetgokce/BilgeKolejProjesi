using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.HelperModels
{
   public class IslemSonuc
    {

        public bool BasariliMi { get; set; }
        public string Mesaj { get; set; }
    }

    public class IslemSonuc<TEntity> : IslemSonuc
    {
        public TEntity Veri { get; set; }
    }
}
