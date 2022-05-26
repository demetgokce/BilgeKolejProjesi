using Bilge.Domain;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
  public  class OgrenciDonemNotRepository: BaseRepository
    {

        public IslemSonuc<Ders> GetirDers(int id, int ogretmenId = 0)
        {
            try
            {
                var dersler = (from d in _veritabani.DonemDers
                               where d.Id == id && (ogretmenId == 0 || d.OgretmenId == ogretmenId)
                               select d.Ders);
                if (dersler.Count() > 0)
                {
                    return new IslemSonuc<Ders> { BasariliMi = true, Veri = dersler.FirstOrDefault() };
                }
                return new IslemSonuc<Ders>() { Mesaj = "Ders Yok" };
            }
            catch { return new IslemSonuc<Ders>(); }
        }
        public IslemSonuc Ekle(OgrenciDonemNot ders)
        {
            try
            {
                _veritabani.OgrenciDonemNotlar.Add(ders);
                _veritabani.SaveChanges();
                return new IslemSonuc { BasariliMi = true };
            }
            catch
            {
                return new IslemSonuc { BasariliMi = false };
            }
        }
        public IslemSonuc Sil(int id)
        {
            try
            {
                var ders = _veritabani.OgrenciDonemNotlar.Where(d => d.Id == id).FirstOrDefault();
                _veritabani.OgrenciDonemNotlar.Remove(ders);
                _veritabani.SaveChanges();
                return new IslemSonuc { BasariliMi = true };
            }
            catch
            {
                return new IslemSonuc { BasariliMi = false };
            }
        }
        public IslemSonuc GuncelleNot(OgrenciDersNotuKayit kayit)
        {
            try
            {
                var ogrenciler = (from o in _veritabani.OgrenciDonemNotlar
                                  where o.Id == kayit.Id
                                  select o);
                if (ogrenciler.Count() > 0)
                {
                    var ogrenci = ogrenciler.FirstOrDefault();
                    ogrenci.Sinav1 = kayit.Sinav1;
                    ogrenci.Sinav2 = kayit.Sinav2;
                    ogrenci.SonSinav = kayit.SonSinav;
                    ogrenci.Ortalama = kayit.Ortalama;
                    _veritabani.SaveChanges();
                    return new IslemSonuc { BasariliMi = true };
                }
                return new IslemSonuc { Mesaj = "Kayıt Yok" };
            }
            catch
            {
                return new IslemSonuc();
            }
        }

        public IslemSonuc<List<NDers>> GetirSonDonemDersleri(int ogrenciId, int sinifId)
        {
            try
            {
                var sonDonemler = (from d in _veritabani.Donem
                                   orderby new { d.Yil, d.DonemTip } descending
                                   select d).ToList();
                if (sonDonemler.Count() > 0)
                {
                    int sonDonem = sonDonemler.FirstOrDefault().Id;

                    var dersler = (from dd in _veritabani.DonemDers.ToList()
                                   join odd in _veritabani.OgrenciDonemNotlar.Where(o => o.OgrenciId == ogrenciId).ToList() on dd.Id equals odd.DonemDersId into d
                                   from ders in d.DefaultIfEmpty()
                                   where dd.DonemId == sonDonem && dd.Ders.SinifId == sinifId && ders == null
                                   orderby dd.Ders.DersAd
                                   select new NDers
                                   {
                                       Id = dd.Id,
                                       Ad = dd.Ders.DersAd,
                                       OgretmenAd = dd.Ogretmen.Ad + " " + dd.Ogretmen.Soyad
                                   }).ToList();


                    return new IslemSonuc<List<NDers>>
                    {
                        BasariliMi = true,
                        Veri = dersler
                    };
                }
                return new IslemSonuc<List<NDers>> { BasariliMi = false, Mesaj = "Dönem açılmadı" };
            }
            catch (Exception hata) { return new IslemSonuc<List<NDers>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<List<NDers>> GetirOgrencininDersleri(int ogrenciId)
        {
            try
            {
                var sonDonemler = (from d in _veritabani.Donem
                                   orderby new { d.Yil, d.DonemTip } descending
                                   select d).ToList();
                if (sonDonemler.Count() > 0)
                {
                    int sonDonem = sonDonemler.FirstOrDefault().Id;

                    var dersler = (from dd in _veritabani.OgrenciDonemNotlar
                                   where dd.DonemDers.DonemId == sonDonem && dd.OgrenciId == ogrenciId
                                   orderby dd.DonemDers.Ders.DersAd
                                   select new NDers
                                   {
                                       Id = dd.Id,
                                       Ad = dd.DonemDers.Ders.DersAd,
                                       OgretmenAd = dd.DonemDers.Ogretmen.Ad + " " + dd.DonemDers.Ogretmen.Soyad
                                   }).ToList();


                    return new IslemSonuc<List<NDers>>
                    {
                        BasariliMi = true,
                        Veri = dersler
                    };
                }
                return new IslemSonuc<List<NDers>> { BasariliMi = false, Mesaj = "Dönem açılmadı" };
            }
            catch (Exception hata) { return new IslemSonuc<List<NDers>> { Mesaj = hata.Message }; }
        }

        public IslemSonuc<List<NDersNotlu>> GetirOgrencininDersleri_Karne(int ogrenciId)
        {
            try
            {
                var dersler = (from dd in _veritabani.OgrenciDonemNotlar
                               where dd.OgrenciId == ogrenciId
                               orderby new { dd.DonemDers.Donem.Yil, dd.DonemDers.Donem.DonemTip } descending
                               select new NDersNotlu
                               {
                                   Id = dd.Id,
                                   Ad = dd.DonemDers.Ders.DersAd,
                                   Ogretmen = dd.DonemDers.Ogretmen.Ad + " " + dd.DonemDers.Ogretmen.Soyad,
                                   BasariDurumTip = dd.BasariDurumTip,
                                   SonSinav = dd.SonSinav,
                                   Ortalama = dd.Ortalama,
                                   Sinav1 = dd.Sinav1,
                                   Sinav2 = dd.Sinav2,
                                   DonemId = dd.DonemDers.DonemId
                               }).ToList();


                return new IslemSonuc<List<NDersNotlu>>
                {
                    BasariliMi = true,
                    Veri = dersler
                };

            }
            catch (Exception hata) { return new IslemSonuc<List<NDersNotlu>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<List<NDersDonem>> GetirOgrencininDersleri_Donemler(int ogrenciId)
        {
            try
            {
                var dersler = (from dd in _veritabani.OgrenciDonemNotlar
                               where dd.OgrenciId == ogrenciId
                               orderby new { dd.DonemDers.Donem.Yil, dd.DonemDers.Donem.DonemTip } descending
                               select new NDersDonem
                               {
                                   Id = dd.DonemDers.DonemId,
                                   DonemTip = dd.DonemDers.Donem.DonemTip,
                                   Yil = dd.DonemDers.Donem.Yil
                               }).Distinct().ToList();

                return new IslemSonuc<List<NDersDonem>>
                {
                    BasariliMi = true,
                    Veri = dersler
                };

            }
            catch (Exception hata) { return new IslemSonuc<List<NDersDonem>> { Mesaj = hata.Message }; }
        }
    }
}
