using Bilge.Domain;
using Okul.BLManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.BLManager.Abstract
{
    public interface IOgretmenManager : IManager<Ogretmen>
    {
        public bool CheckForTckimlik(string tcno);
        public bool CheckForGsm(string Gsm);

        public bool TCDogrula(string tcno);
    }
}
