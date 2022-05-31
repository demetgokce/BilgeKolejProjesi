using Bilge.DAL.Abstract;
using Bilge.Domain;
using Okul.DAL.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
  public  class VeliRepository : OkulDbRepository<Veli>, IVeliRepository
    {
    }
}
