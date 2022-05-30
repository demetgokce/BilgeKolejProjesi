using Bilge.Domain;
using Okul.BLManager.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Concrete
{
    public class DersManager : ManagerBase<Ders>, IDersManager
    {
        public bool CheckForBransName(string DersAdi)
        {
            var entities = base.db.GetAll(x => x.DersAd == DersAdi);
            if (entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
