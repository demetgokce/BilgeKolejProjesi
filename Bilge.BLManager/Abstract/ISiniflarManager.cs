using Bilge.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Abstract
{
   public interface ISiniflarManager:IManager<Siniflar>
    {

      
        public bool CheckForSinifAdi(string SinifAdi);


    }
}
