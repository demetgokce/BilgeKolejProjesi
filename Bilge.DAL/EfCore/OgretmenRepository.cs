using Bilge.Domain;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
   public class OgretmenRepository: BaseRepository
    {
        public OgretmenRepository(bool uyelikAlinsinMi = true) : base(uyelikAlinsinMi) { }
        public IslemSonuc<List<Ogretmen>> GetirTumu()
        {
            try
            {
                return new IslemSonuc<List<Ogretmen>>
                {
                    BasariliMi = true,
                    Veri = _veritabani.Ogretmen.OrderBy(o => o.Ad).ToList()
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<Ogretmen>> { Mesaj = hata.Message }; }

        }
        public IslemSonuc<List<Ogretmen>> GetirDersOgretimGorevlileri(int dersId)
        {
            try
            {
                return new IslemSonuc<List<Ogretmen>>
                {
                    BasariliMi = true,
                    Veri = _veritabani.Ogretmen.Where(o => o.DersId == dersId).OrderBy(o => o.Ad).ToList()
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<Ogretmen>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<Ogretmen> Getir(int id)
        {
            try
            {
                var ogretmen = (from o in _veritabani.Ogretmen
                                          where o.Id == id
                                          orderby o.Ad, o.Soyad
                                          select o);
                if (ogretmen.Count() > 0)
                {
                    return new IslemSonuc<Ogretmen>
                    {
                        BasariliMi = true,
                        Veri = ogretmen.FirstOrDefault()
                    };
                }
                else
                {
                    return new IslemSonuc<Ogretmen>();
                }
            }
            catch (Exception hata) { return new IslemSonuc<Ogretmen> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<Ogretmen> Getir(string TcNo)
        {
            try
            {
                var ogretimGorevlileri = (from o in _veritabani.Ogretmen
                                          where o.TcNo == TcNo
                                          orderby o.Ad, o.Soyad
                                          select o);
                if (ogretimGorevlileri.Count() > 0)
                {
                    return new IslemSonuc<Ogretmen>
                    {
                        BasariliMi = true,
                        Veri = Ogretmen.FirstOrDefault()
                    };
                }
                else
                {
                    return new IslemSonuc<Ogretmen>();
                }
            }
            catch (Exception hata) { return new IslemSonuc<Ogretmen> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<int> Kaydet(Ogretmen kayit)
        {
            try
            {
                _veritabani.Ogretmen.Add(kayit);
                _veritabani.SaveChanges();

                var uyelikEkleSonuc = _uyelik.KullaniciEkle(kayit.TcNo, "Ogretmen");
                if (uyelikEkleSonuc.BasariliMi)
                {
                    return new IslemSonuc<int>
                    {
                        BasariliMi = true,
                        Veri = kayit.Id
                    };
                }
                else
                {
                    return new IslemSonuc<int>
                    {
                        BasariliMi = false,
                        Veri = kayit.Id,
                        Mesaj = uyelikEkleSonuc.Mesaj
                    };
                }
                return null;
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
        public IslemSonuc Guncelle(Ogretmen kayit)
        {
            try
            {
                var duzenlenecekKayitlar = _veritabani.Ogretmen.Where(o => o.Id == kayit.Id);
                if (duzenlenecekKayitlar.Count() > 0)
                {
                    var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
                    duzenlenecekKayit.Ad = kayit.Ad;
                    duzenlenecekKayit.Soyad = kayit.Soyad;
                    duzenlenecekKayit.TcNo = kayit.TcNo;
                    
                    duzenlenecekKayit.DogumTarih = kayit.DogumTarih;
                    duzenlenecekKayit.GirisTarih = kayit.GirisTarih;
                    duzenlenecekKayit.CikisTarih = kayit.CikisTarih;
                    duzenlenecekKayit.EPosta = kayit.EPosta;

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
                var silinecekKayitlar = _veritabani.Ogretmen.Where(o => o.Id == id);
                if (silinecekKayitlar.Count() > 0)
                {
                    var silinecekKayit = silinecekKayitlar.FirstOrDefault();
                    _veritabani.Ogretmen.Remove(silinecekKayit);
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


        public IslemSonuc<List<DonemDers>> GetirDonemDersleri_SonDonem(int ogretmenId)
        {
            var sonDonemler = (from d in _veritabani.Donemler
                               orderby new { d.Yil, d.DonemTip } descending
                               select d).ToList();

            if (sonDonemler.Count() > 0)
            {
                int sonDonem = sonDonemler.FirstOrDefault().Id;

                var dersler = (from d in _veritabani.DonemDers
                               where d.OgretmenId == ogretmenId && d.DonemId == sonDonem
                               orderby new { d.Donem.Yil, d.Donem.DonemTip } descending
                               select new DonemDers
                               {
                                   Id = d.Id,
                                   Ad = d.Ders.Ad,
                                   Yil = d.Donem.Yil,
                                   DonemTip = d.Donem.DonemTip,
                                   DonemId = d.DonemId
                               }).ToList();

                return new IslemSonuc<List<DonemDers>>
                {
                    BasariliMi = true,
                    Veri = dersler
                };
            }
            return new IslemSonuc<List<DonemDers>>();
        }
        public IslemSonuc<List<DonemDers>> GetirDonemDersleri_Tumu(int ogretimGorevlisiId)
        {
            var dersler = (from d in _veritabani.DonemDersler
                           where d.OgretimGorevlisiId == ogretimGorevlisiId
                           orderby new { d.Donem.Yil, d.Donem.DonemTip } descending
                           select new DonemDers
                           {
                               Id = d.Id,
                               Ad = d.Ders.Ad,
                               Yil = d.Donem.Yil,
                               DonemTip = d.Donem.DonemTip,
                               DonemId = d.DonemId
                           }).ToList();

            return new IslemSonuc<List<DonemDers>>
            {
                BasariliMi = true,
                Veri = dersler
            };
        }
        public IslemSonuc<List<DersDonem>> GetirDonem_TumDonemler(int ogretmenId)
        {
            try
            {
                var donemler = (from dd in _veritabani.DonemDers
                                where dd.OgretmenId == ogretmenId
                                orderby new { dd.Donem.Yil, dd.Donem.DonemTip } descending
                                select new DersDonem
                                {
                                    Id = dd.DonemId,
                                    DonemTip = dd.Donem.DonemTip,
                                    Yil = dd.Donem.Yil
                                }).Distinct().ToList();

                return new IslemSonuc<List<DersDonem>>
                {
                    BasariliMi = true,
                    Veri = donemler
                };

            }
            catch (Exception hata) { return new IslemSonuc<List<DersDonem>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<List<DersDonem>> GetirDonem_SonDonem(int ogretimGorevlisiId)
        {
            try
            {
                var sonDonemler = (from d in _veritabani.Donem
                                   orderby new { d.Yil, d.DonemTip } descending
                                   select d).ToList();

                if (sonDonemler.Count() > 0)
                {
                    int sonDonem = sonDonemler.FirstOrDefault().Id;


                    var donemler = (from dd in _veritabani.DonemDers
                                    where dd.OgretmenId == OgretmenId && dd.DonemId == sonDonem
                                    orderby new { dd.Donem.Yil, dd.Donem.DonemTip } descending
                                    select new DersDonem
                                    {
                                        Id = dd.DonemId,
                                        DonemTip = dd.Donem.DonemTip,
                                        Yil = dd.Donem.Yil
                                    }).Distinct().ToList();


                    return new IslemSonuc<List<DersDonem>>
                    {
                        BasariliMi = true,
                        Veri = donemler
                    };
                }
                else
                {
                    return new IslemSonuc<List<DersDonem>> { Mesaj = "Öğretmen son dönemde ders vermemiştir" };
                }
            }
            catch (Exception hata) { return new IslemSonuc<List<DersDonem>> { Mesaj = hata.Message }; }
        }

        public IslemSonuc<List<OgrenciDersNotu>> GetirDonemDersi_OgrenciNotlari(int donemDersId)
        {
            var dersler = (from d in _veritabani.OgrenciDonemNot
                           where d.DonemDersId == donemDersId
                           orderby new { d.DonemDers.Donem.Yil, d.DonemDers.Donem.DonemTip, d.DonemDers.Ders.Ad } descending
                           select new OgrenciDersNotu
                           {
                               Id = d.Id,
                               TcNo = d.Ogrenci.TcNo,
                               AdSoyad = d.Ogrenci.Ad + " " + d.Ogrenci.Soyad,
                               Sinav1 = d.Sinav1,
                               Sinav2 = d.Sinav2,
                               SonSinav = d.SonSinav,
                               Ortalama = d.Ortalama
                           }).ToList();

            return new IslemSonuc<List<OgrenciDersNotu>>
            {
                BasariliMi = true,
                Veri = dersler
            };
        }

        public IslemSonuc<SelectList> GetirDersOgretmen_SelectList(int DersId)
        {
            var ogretmen = (from o in _veritabani.Ogretmen
                                      where o.DersId == DersId
                                      orderby o.Ad
                                      select new SelectListItem
                                      {
                                          Text = o.Ad + " " + o.Soyad,
                                          Value = o.Id.ToString()
                                      }).ToList();

            return new IslemSonuc<SelectList>
            {
                BasariliMi = true,
                Veri = new SelectList(ogretimGorevlileri, "Value", "Text")
            };
        }
    }
}
