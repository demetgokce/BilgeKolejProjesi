using Bilge.Domain;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
  public  class DonemRepository : BaseRepository
    {
        public IslemSonuc<List<Donem>> GetirTumu()
        {
            try
            {
                return new IslemSonuc<List<Donem>>
                {
                    BasariliMi = true,
                    Veri = _veritabani.Donem.ToList()
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<Donem>> { Mesaj = hata.Message }; }

        }
        public IslemSonuc<Donem> Getir(int id)
        {
            try
            {
                var donemler = (from d in _veritabani.Donem
                                where d.Id == id
                                select d);
                if (donemler.Count() > 0)
                {
                    return new IslemSonuc<Donem>
                    {
                        BasariliMi = true,
                        Veri = donemler.FirstOrDefault()
                    };
                }
                else
                {
                    return new IslemSonuc<Donem>();
                }
            }
            catch (Exception hata) { return new IslemSonuc<Donem> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<int> Kaydet(Donem kayit)
        {
            try
            {
                _veritabani.Donemler.Add(kayit);
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
        public IslemSonuc Guncelle(Donem kayit)
        {
            try
            {
                var duzenlenecekKayitlar = _veritabani.Donem.Where(d => d.Id == kayit.Id);
                if (duzenlenecekKayitlar.Count() > 0)
                {
                    var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
                    duzenlenecekKayit.DonemTip = kayit.DonemTip;
                    duzenlenecekKayit.Yil = kayit.Yil;
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
                var silinecekKayitlar = _veritabani.Donem.Where(d => d.Id == id);
                if (silinecekKayitlar.Count() > 0)
                {
                    var silinecekKayit = silinecekKayitlar.FirstOrDefault();
                    _veritabani.Donem.Remove(silinecekKayit);
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
