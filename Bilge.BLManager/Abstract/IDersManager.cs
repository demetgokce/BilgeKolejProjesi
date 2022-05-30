using Bilge.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Abstract
{
    public interface IDersManager:IManager<Ders>
    {

        public bool CheckForBransName(string DersAdi);
    }
}
