using Bilge.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Abstract
{
    public interface IOgrenciManager:IManager<Ogrenci>
    {
        public bool CheckForTckimlik(string tcno);
        public bool CheckForGsm(string Gsm);

        public bool TCDogrula(string tcno);
    }
}
