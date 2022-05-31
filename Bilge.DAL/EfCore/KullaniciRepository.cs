using Bilge.DAL.Abstract;
using Bilge.Domain;
using Okul.DAL.EfCore;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
  public  class KullaniciRepository:OkulDbRepository<Kullanici>,IKullaniciRepository
    {
        //kullanici ile ilgili crub metodları okuldbrepository icerisinde mevcuttur eger kullanici ile ilgili extra metodlara ihityacimiz olursa buraya eklenecek


    }
}
