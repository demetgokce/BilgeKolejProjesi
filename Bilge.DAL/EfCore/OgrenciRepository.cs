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
  public  class OgrenciRepository : OkulDbRepository<Ogrenci>, IOgrenciRepository
    {
        //public OgrenciRepository(bool uyelikAlinsinMi = true) : base(uyelikAlinsinMi) { }
        //public IslemSonuc<List<Ogrenci>> GetirTumu()
        //{
        //    try
        //    {
        //        return new IslemSonuc<List<Ogrenci>>
        //        {
        //            BasariliMi = true,
        //            Veri = _veritabani.Ogrenciler.OrderBy(o => o.Adi).ToList()
        //        };
        //    }
        //    catch (Exception hata) { return new IslemSonuc<List<Ogrenci>> { Mesaj = hata.Message }; }

        //}
        //public IslemSonuc<List<Ogrenci>> GetirSinifOgrencileri(int sinifId)
        //{
        //    try
        //    {
        //        return new IslemSonuc<List<Ogrenci>>
        //        {
        //            BasariliMi = true,
        //            Veri = _veritabani.Ogrenciler.Where(o => o.SinifId == sinifId).OrderBy(o => o.Adi).ToList()
        //        };
        //    }
        //    catch (Exception hata) { return new IslemSonuc<List<Ogrenci>> { Mesaj = hata.Message }; }
        //}
        //public IslemSonuc<Ogrenci> Getir(int id)
        //{
        //    try
        //    {
        //        var ogrenciler = (from o in _veritabani.Ogrenciler
        //                          where o.Id == id
        //                          orderby o.Adi, o.Soyadi
        //                          select o);
        //        if (ogrenciler.Count() > 0)
        //        {
        //            return new IslemSonuc<Ogrenci>
        //            {
        //                BasariliMi = true,
        //                Veri = ogrenciler.FirstOrDefault()
        //            };
        //        }
        //        else
        //        {
        //            return new IslemSonuc<Ogrenci>();
        //        }
        //    }
        //    catch (Exception hata) { return new IslemSonuc<Ogrenci> { Mesaj = hata.Message }; }
        //}
        //public IslemSonuc<Ogrenci> Getir(string tcNo)
        //{
        //    try
        //    {
        //        var ogrenciler = (from o in _veritabani.Ogrenciler
        //                          where o.TcNo == tcNo
        //                          orderby o.Adi, o.Soyadi
        //                          select o);
        //        if (ogrenciler.Count() > 0)
        //        {
        //            return new IslemSonuc<Ogrenci>
        //            {
        //                BasariliMi = true,
        //                Veri = ogrenciler.FirstOrDefault()
        //            };
        //        }
        //        else
        //        {
        //            return new IslemSonuc<Ogrenci>();
        //        }
        //    }
        //    catch (Exception hata) { return new IslemSonuc<Ogrenci> { Mesaj = hata.Message }; }
        //}

        ////public IslemSonuc<int> Kaydet(Ogrenci kayit)
        ////{
        ////    try
        ////    {
        ////        _veritabani.Ogrenciler.Add(kayit);
        ////        _veritabani.SaveChanges();

        ////        var uyelikEkleSonuc = _uyelik.KullaniciEkle(kayit.TcNo, "Ogrenci");
        ////        if (uyelikEkleSonuc.BasariliMi)
        ////        {
        ////            return new IslemSonuc<int>
        ////            {
        ////                BasariliMi = true,
        ////                Veri = kayit.Id
        ////            };
        ////        }
        ////        else
        ////        {
        ////            return new IslemSonuc<int>
        ////            {
        ////                BasariliMi = false,
        ////                Veri = kayit.Id,
        ////                Mesaj = uyelikEkleSonuc.Mesaj
        ////            };
        ////        }
        ////        return null;
        ////    }
        ////    catch (Exception hata)
        ////    {
        ////        return new IslemSonuc<int>()
        ////        {
        ////            BasariliMi = false,
        ////            Mesaj = hata.Message
        ////        };
        ////    }
        ////}
        //public IslemSonuc Guncelle(Ogrenci kayit)
        //{
        //    try
        //    {
        //        var duzenlenecekKayitlar = _veritabani.Ogrenciler.Where(o => o.Id == kayit.Id);
        //        if (duzenlenecekKayitlar.Count() > 0)
        //        {
        //            var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
        //            duzenlenecekKayit.Adi = kayit.Adi;
        //            duzenlenecekKayit.Soyadi = kayit.Soyadi;
        //            duzenlenecekKayit.TcNo = kayit.TcNo;
        //            duzenlenecekKayit.SinifId = kayit.SinifId;
        //            duzenlenecekKayit.DogumTarih = kayit.DogumTarih;
        //            duzenlenecekKayit.GirisTarih = kayit.GirisTarih;
        //            duzenlenecekKayit.CikisTarih = kayit.CikisTarih;
        //            duzenlenecekKayit.EPosta = kayit.EPosta;

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
        //        var silinecekKayitlar = _veritabani.Ogrenciler.Where(o => o.Id == id);
        //        if (silinecekKayitlar.Count() > 0)
        //        {
        //            var silinecekKayit = silinecekKayitlar.FirstOrDefault();
        //            _veritabani.Ogrenciler.Remove(silinecekKayit);
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
