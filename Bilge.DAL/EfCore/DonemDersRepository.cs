using Bilge.Domain;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
 public   class DonemDersRepository: BaseRepository
    {

        public IslemSonuc<List<DonemDers>> GetirDonemdekiDersleri(int SinifId, int donemId)
        {
            try
            {
                var dersler = (from d in _veritabani.DonemDers
                               where d.DonemId == donemId && d.Ders.SinifId==SinifId
                               orderby d.Ders.DersAd
                               select d).ToList();

                return new IslemSonuc<List<DonemDers>>
                {
                    BasariliMi = true,
                    Veri = dersler
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<DonemDers>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<DonemDers> Getir(int id)
        {
            try
            {
                var dersler = (from b in _veritabani.DonemDers
                               where b.Id == id
                               select b);
                if (dersler.Count() > 0)
                {
                    return new IslemSonuc<DonemDers>
                    {
                        BasariliMi = true,
                        Veri = dersler.FirstOrDefault()
                    };
                }
                else
                {
                    return new IslemSonuc<DonemDers>();
                }
            }
            catch (Exception hata) { return new IslemSonuc<DonemDers> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<int> Kaydet(DonemDers kayit)
        {
            try
            {
                _veritabani.DonemDers.Add(kayit);
                _veritabani.SaveChanges();
                return new IslemSonuc<int>
                {
                    BasariliMi = true,
                    Veri = kayit.Id
                };
            }
            catch (Exception hata)
            {
                return new IslemSonuc<int>()
                {
                    BasariliMi = false,
                    Mesaj = hata.Message
                };
            }
        }
        public IslemSonuc Guncelle(DonemDers kayit)
        {
            try
            {
                var duzenlenecekKayitlar = _veritabani.DonemDers.Where(d => d.Id == kayit.Id);
                if (duzenlenecekKayitlar.Count() > 0)
                {
                    var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
                    duzenlenecekKayit.DersId = kayit.DersId;
                    duzenlenecekKayit.OgretmenId = kayit.OgretmenId;
                    _veritabani.SaveChanges();
                    return new IslemSonuc { BasariliMi = true };
                }
                else
                {
                    return new IslemSonuc
                    {
                        BasariliMi = false,
                        Mesaj = "Kayıt bulunamadı"
                    };
                }
            }
            catch (Exception hata)
            {
                return new IslemSonuc
                {
                    BasariliMi = false,
                    Mesaj = hata.Message
                };
            }
        }
        public IslemSonuc Sil(int id)
        {
            try
            {
                var silinecekKayitlar = _veritabani.DonemDers.Where(d => d.Id == id);
                if (silinecekKayitlar.Count() > 0)
                {
                    var silinecekKayit = silinecekKayitlar.FirstOrDefault();
                    _veritabani.DonemDers.Remove(silinecekKayit);
                    _veritabani.SaveChanges();
                    return new IslemSonuc { BasariliMi = true };
                }
                else
                {
                    return new IslemSonuc
                    {
                        BasariliMi = false,
                        Mesaj = "Kayıt bulunamadı"
                    };
                }
            }
            catch (Exception hata)
            {
                return new IslemSonuc<int>()
                {
                    BasariliMi = false,
                    Mesaj = hata.Message
                };
            }
        }
    }
}
