using Bilge.Domain;
using Okul.BLManager.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Concrete
{
    public class SiniflarManager:ManagerBase<Siniflar>,ISiniflarManager
    {
        public bool CheckForSinifAdi(string SinifAdi)
        {
            var entities = base.db.GetAll(x => x.SinifAdi == SinifAdi);
            if (entities.Count > 0)
                return true;
            else
                return false;
        }


    }
}
