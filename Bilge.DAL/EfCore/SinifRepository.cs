using Bilge.Domain;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
   public class SinifRepository:BaseRepository
    {

        public IslemSonuc<List<Sinif>> GetirTumu()
        {
            try
            {
                return new IslemSonuc<List<Sinif>>
                {
                    BasariliMi = true,
                    Veri = _veritabani.Siniflar.ToList()
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<Sinif>> { Mesaj = hata.Message }; }

        }
        public IslemSonuc<List<Sinif>> GetirSinifDersleri(int sinifId)
        {
            try
            {
                return new IslemSonuc<List<Sinif>>
                {
                    BasariliMi = true,
                    Veri = _veritabani.Siniflar.Where(b => b.Id == sinifId).ToList()
                };
            }
            catch (Exception hata) { return new IslemSonuc<List<Sinif>> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<Sinif> Getir(int id)
        {
            try
            {
                var bolumler = (from b in _veritabani.Siniflar
                                where b.Id == id
                                select b);
                if (bolumler.Count() > 0)
                {
                    return new IslemSonuc<Sinif>
                    {
                        BasariliMi = true,
                        Veri = Sinif.FirstOrDefault()
                    };
                }
                else
                {
                    return new IslemSonuc<Sinif>();
                }
            }
            catch (Exception hata) { return new IslemSonuc<Sinif> { Mesaj = hata.Message }; }
        }
        public IslemSonuc<int> Kaydet(Sinif kayit)
        {
            try
            {
                _veritabani.Siniflar.Add(kayit);
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
        public IslemSonuc Guncelle(Sinif kayit)
        {
            try
            {
                var duzenlenecekKayitlar = _veritabani.Siniflar.Where(b => b.Id == kayit.Id);
                if (duzenlenecekKayitlar.Count() > 0)
                {
                    var duzenlenecekKayit = duzenlenecekKayitlar.FirstOrDefault();
                    duzenlenecekKayit.SinifAdi = kayit.SinifAdi;
                    
                    duzenlenecekKayit.Kapasite = kayit.Kapasite;
                    duzenlenecekKayit.Kod = kayit.Kod;
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
                var silinecekKayitlar = _veritabani.Siniflar.Where(b => b.Id == id);
                if (silinecekKayitlar.Count() > 0)
                {
                    var silinecekKayit = silinecekKayitlar.FirstOrDefault();
                    _veritabani.Siniflar.Remove(silinecekKayit);
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


        public IslemSonuc<SelectListHelper> GetirTumu_SelectListHelper()
        {
            var siniflar = (from f in _veritabani.Siniflar
                            orderby f.SinifAdi
                            select new NSelectListItem
                            {
                                Text = f.SinifAdi,
                                Value = f.Id.ToString()
                            }).ToList();

            return new IslemSonuc<SelectListHelper>
            {
                BasariliMi = true,
                Veri = new SelectListHelper(siniflar, "Value", "Text")
            };
        }



    }
}
