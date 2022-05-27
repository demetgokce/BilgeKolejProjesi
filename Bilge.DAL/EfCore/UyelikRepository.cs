using Bilge.Domain;
using Bilge.Domain.HelperModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
    public class UyelikRepository
    {
       // #region Değişkenler

        //IdentityContext _db = new IdentityContext();

        //UserManager<ApplicationUser> UserManager { get; set; }
        //IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.Current.GetOwinContext().Authentication;
        //    }
        //}


        //#endregion

        //#region Constructor

        //public UyelikRepository()
        //{
        //    UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
        //}

        //#endregion

        //#region Kullanıcı İşlemleri

        //public IslemSonuc<string> KullaniciEkle(string kullaniciAd, string rol)
        //{
        //    if (string.IsNullOrEmpty(kullaniciAd))
        //        return new IslemSonuc<string> { Mesaj = "Lütfen kişinin kullanıcı adını belirtiniz" };
        //    if (string.IsNullOrEmpty(rol))
        //        return new IslemSonuc<string> { Mesaj = "Lütfen kişinin rolünü belirtiniz" };
        //    try
        //    {
        //        var kontrolKullanici = UserManager.FindByName(kullaniciAd);
        //        if (kontrolKullanici != null)
        //            return new IslemSonuc<string> { Mesaj = "Bu kişi sistemde kayıtlıdır" };

        //        //Kullanıcıyı ekle
        //        ApplicationUser kullanici = new ApplicationUser
        //        {
        //            UserName = kullaniciAd
        //        };
        //        _db.Users.Add(kullanici);
        //        _db.SaveChanges();

        //        UserManager.AddPassword(kullanici.Id, kullaniciAd);

        //        //Kullanıcıya rol ekle
        //        var rolEklemeSonuc = UserManager.AddToRole(kullanici.Id, rol);
        //        if (rolEklemeSonuc.Succeeded)
        //            return new IslemSonuc<string> { BasariliMi = true };
        //        else
        //            return new IslemSonuc<string> { BasariliMi = false, Mesaj = "Kullanıcıya rol tanımlaması yapılamadı" };
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc<string> { Mesaj = hata.ToString() };
        //    }
        //}
        //public IslemSonuc<string> KullaniciRoleEkle(string kullaniciAd, string rol)
        //{
        //    if (string.IsNullOrEmpty(kullaniciAd))
        //        return new IslemSonuc<string> { Mesaj = "Lütfen kişinin kullanıcı adını belirtiniz" };
        //    if (string.IsNullOrEmpty(rol))
        //        return new IslemSonuc<string> { Mesaj = "Lütfen kişinin rolünü belirtiniz" };
        //    try
        //    {
        //        var kullanici = UserManager.FindByName(kullaniciAd);
        //        var sonuc = UserManager.AddToRole(kullanici.Id, rol);
        //        if (sonuc.Succeeded)
        //            return new IslemSonuc<string> { BasariliMi = true };
        //        else
        //            return new IslemSonuc<string> { Mesaj = sonuc.Errors.ToString() };
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc<string> { Mesaj = hata.ToString() };
        //    }

        //}

        //public IslemSonuc<Session> GirisYap(string kullaniciAdi, string sifre, UyeTip tip)
        //{
        //    Session session = new Session();
        //    if (tip == UyeTip.Ogrenci)
        //    {
        //        OgrenciRepository ogrenciRepository = new OgrenciRepository(false);
        //        var ogrenci = ogrenciRepository.Getir(kullaniciAdi);
        //        if (!ogrenci.BasariliMi)
        //            return new IslemSonuc<Session> { Mesaj = "Lütfen öğrenci bilgilerini kontrol ediniz" };

        //        session.Id = ogrenci.Veri.Id;
        //        session.DersId = ogrenci.Veri.DersId;
        //    }
        //    else if (tip == UyeTip.Ogretmen)
        //    {
        //        OgretmenRepository ogretmenRepository = new OgretmenRepository(false);
        //        var ogretmen = ogretmenRepository.Getir(kullaniciAdi);
        //        if (!ogretmen.BasariliMi)
        //            return new IslemSonuc<Session> { Mesaj = "Lütfen öğretmen bilgilerini kontrol ediniz" };

        //        session.Id = ogretmen.Veri.Id;
        //        session.DersId = ogretmen.Veri.DersId;
        //    }
        //    else if (tip == UyeTip.Yonetim)//Bilgi işlem kullanıcısı öğrenci veya öğretim görevlisi olamaz
        //    {
        //        OgrenciRepository ogrenciRepository = new OgrenciRepository(false);
        //        var ogrenci = ogrenciRepository.Getir(kullaniciAdi);
        //        if (ogrenci.BasariliMi)
        //            return new IslemSonuc<Session> { Mesaj = "Lütfen üye bilgilerini kontrol ediniz" };

        //        OgretmenRepository ogretimGorevlisiRepository = new OgretmenRepository(false);
        //        var ogretimGorevlisi = ogretimGorevlisiRepository.Getir(kullaniciAdi);
        //        if (ogretimGorevlisi.BasariliMi)
        //            return new IslemSonuc<Session> { Mesaj = "Lütfen üye bilgilerini kontrol ediniz" };
        //    }

        //    var kullanici = UserManager.Find(kullaniciAdi, sifre);
        //    if (kullanici != null)
        //    {
        //        AuthenticationManager.SignOut();
        //        var kimlik = UserManager.CreateIdentity(kullanici, DefaultAuthenticationTypes.ApplicationCookie);
        //        AuthenticationManager.SignIn(new AuthenticationProperties(), kimlik);
        //        return new IslemSonuc<Session> { BasariliMi = true, Veri = session };
        //    }
        //    else
        //    {
        //        return new IslemSonuc<Session> { Mesaj = "Kullanıcı adı ve şifrenizi kontrol ediniz." };
        //    }
        //}
        //public IslemSonuc CikisYap()
        //{
        //    try
        //    {
        //        AuthenticationManager.SignOut();
        //        return new IslemSonuc { BasariliMi = true };
        //    }
        //    catch (Exception hata)
        //    {
        //        return new IslemSonuc { Mesaj = hata.ToString() };
        //    }
        //}
        //public IslemSonuc<string> GirisYapanKullanici()
        //{
        //    try
        //    {
        //        bool kullaniciGirisYaptiMi = AuthenticationManager.User.Identity.IsAuthenticated;
        //        if (kullaniciGirisYaptiMi)
        //        {
        //            return new IslemSonuc<string> { BasariliMi = true, Veri = AuthenticationManager.User.Identity.Name };
        //        }
        //    }
        //    catch { }
        //    return new IslemSonuc<string>();
        //}

        //#endregion
    }
}
