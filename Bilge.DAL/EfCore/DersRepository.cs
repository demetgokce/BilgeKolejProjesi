using Bilge.DAL.Abstract;
using Bilge.Domain;
using Bilge.Domain.HelperModels;
using Okul.DAL.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
   public  class DersRepository : OkulDbRepository<Ders>, IDersRepository
    {

        BilgeDbContext c = new BilgeDbContext();

        public void AddDers(Ders ders)
        {
            c.Add(ders);
            c.SaveChanges();

        }


        public void DeleteDers(Ders ders)
        {

            c.Remove(ders);
            c.SaveChanges();

        }



        public List<Ders> ListAllDers()
        {

            return c.Ders.ToList();


        }

        public void UpdateDers(Ders ders)
        {

            c.Update(ders);
            c.SaveChanges();


        }


        // public DersRepository() : base() { }
        //public IslemSonuc<List<Ders>> GetirTumu()
        //{
        //    try
        //    {
        //        return new IslemSonuc<List<Ders>>
        //        {
        //            BasariliMi = true,
        //            Veri = _veritabani.Ders.OrderBy(o => o.DersAd).ToList()
        //        };
        //    }
        //    catch (Exception hata) { return new IslemSonuc<List<Ders>> { Mesaj = hata.Message }; }

        //}
        //public IslemSonuc<List<Ders>> GetirSinifDersleri(int sinifId)
        //{
        //    try
        //    {
        //        return new IslemSonuc<List<Ders>>
        //        {
        //            BasariliMi = true,
        //            Veri = _veritabani.Ders.Where(d => d.SinifId == sinifId).OrderBy(o => o.SinifId).ToList()
        //        };
        //    }
        //    catch (Exception hata) { return new IslemSonuc<List<Ders>> { Mesaj = hata.Message }; }
        //}
        //public IslemSonuc<Ders> Getir(int id)
        //{
        //    try
        //    {
        //        var dersler = (from d in _veritabani.Ders
        //                       where d.Id == id
        //                       select d);
        //        if (dersler.Count() > 0)
        //        {
        //            return new IslemSonuc<Ders>
        //            {
        //                BasariliMi = true,
        //                Veri = dersler.FirstOrDefault()
        //            };
        //        }
        //        else
        //        {
        //            return new IslemSonuc<Ders>();
        //        }
        //    }
        //    catch (Exception hata) { return new IslemSonuc<Ders> { Mesaj = hata.Message }; }
        //}
        //public IslemSonuc<int> Kaydet(Ders kayit)
        //{
        //    try
        //    {
        //        _veritabani.Ders.Add(kayit);
        //        _veritabani.SaveChanges();
        //        return new IslemSonuc<int>
        //        {
        //            BasariliMi = true,
        //            Veri = kayit.Id
        //        };
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc<int>()
        //        {
        //            BasariliMi = false,
        //            Mesaj = hata.Message
        //        };
        //    }
        //}
        //public IslemSonuc Guncelle(Ders kayit)
        //{
        //    try
        //    {
        //        var duzenlenecekKayitlar = _veritabani.Ders.Where(d => d.Id == kayit.Id);
        //        if (duzenlenecekKayitlar.Count() > 0)
        //        {
        //            var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
        //            duzenlenecekKayit.DersAd= kayit.DersAd;
        //            duzenlenecekKayit.SinifId = kayit.SinifId;
        //            duzenlenecekKayit.Kod = kayit.Kod;

        //            _veritabani.SaveChanges();
        //            return new IslemSonuc { BasariliMi = true };
        //        }
        //        else
        //        {
        //            return new IslemSonuc
        //            {
        //                BasariliMi = false,
        //                Mesaj = "Kayıt bulunamadı"
        //            };
        //        }
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc
        //        {
        //            BasariliMi = false,
        //            Mesaj = hata.Message
        //        };
        //    }
        //}
        //public IslemSonuc Sil(int id)
        //{
        //    try
        //    {
        //        var silinecekKayitlar = _veritabani.Ders.Where(d => d.Id == id);
        //        if (silinecekKayitlar.Count() > 0)
        //        {
        //            var silinecekKayit = silinecekKayitlar.FirstOrDefault();
        //            _veritabani.Ders.Remove(silinecekKayit);
        //            _veritabani.SaveChanges();
        //            return new IslemSonuc { BasariliMi = true };
        //        }
        //        else
        //        {
        //            return new IslemSonuc
        //            {
        //                BasariliMi = false,
        //                Mesaj = "Kayıt bulunamadı"
        //            };
        //        }
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc<int>()
        //        {
        //            BasariliMi = false,
        //            Mesaj = hata.Message
        //        };
        //    }
        //}





    }
}
