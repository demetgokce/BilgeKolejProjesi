
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Abstract
{
    public interface IKullaniciManager:IManager<Kullanici>
    {
        public bool CheckForUserName(string username);

    }
}
