using Bilge.DAL.EfCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class OgrenciIslemController : Controller
    {
        //#region Değişkenler

        //DonemDersRepository _donemDersRepository = new DonemDersRepository();
        //OgrenciDonemNotRepository _ogrenciDonemNotRepository = new OgrenciDonemNotRepository();
        //UyelikRepository _uyelik = new UyelikRepository();

        //#endregion

        //#region Üyelik İşlemleri

        //[AllowAnonymous]
        //public ActionResult GirisYap()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult GirisYap(UyeGiris model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var girisSonuc = _uyelik.GirisYap(model.KullaniciAd, model.Sifre, UyeTip.Ogrenci);
        //        if (girisSonuc.BasariliMi)
        //        {
        //            Session["Ogrenci"] = girisSonuc.Veri;
        //            if (!string.IsNullOrEmpty(returnUrl))
        //                return Redirect(returnUrl);
        //            else
        //                return RedirectToAction("Not");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", girisSonuc.Mesaj);
        //        }
        //    }
        //    return View(model);
        //}

        //[Authorize(Roles = "Ogrenci")]
        //public ActionResult CikisYap()
        //{
        //    _uyelik.CikisYap();
        //    Session["Ogrenci"] = null;
        //    return RedirectToAction("GirisYap");
        //}

        //#endregion

        //#region Ders İşlemleri

        //public ActionResult DersSecim()
        //{
        //    var ogrenci = (Session)Session["Ogrenci"];
        //    ViewBag.Dersler = _ogrenciDonemNotRepository.GetirSonDonemDersleri(ogrenci.Id, ogrenci.BolumId).Veri;
        //    ViewBag.SecilenDersler = _ogrenciDonemNotRepository.GetirOgrencinin(ogrenci.Id).Veri;
        //    return View();
        //}

        //[HttpPost]
        //public JsonResult DersEkle(string id)
        //{
        //    var ogrenci = (NSession)Session["Ogrenci"];
        //    int dersId = Convert.ToInt32(id);
        //    OgrenciDonemDers ders = new OgrenciDonemDers
        //    {
        //        DonemDersId = dersId,
        //        OgrenciId = ogrenci.Id
        //    };
        //    var kayitSonuc = _ogrenciDonemDersRepository.Ekle(ders);
        //    if (kayitSonuc.BasariliMi)
        //        return Json("Basarili");
        //    else
        //        return Json(kayitSonuc.Mesaj);

        //}

        //[HttpPost]
        //public JsonResult DersSil(string id)
        //{
        //    int dersId = Convert.ToInt32(id);
        //    var kayitSonuc = _ogrenciDonemDersRepository.Sil(dersId);
        //    if (kayitSonuc.BasariliMi)
        //        return Json("Basarili");
        //    else
        //        return Json(kayitSonuc.Mesaj);
        //}

        //public ActionResult Transkript()
        //{
        //    var ogrenci = (Session)Session["Ogrenci"];
        //    var dersler = _ogrenciDonemDersRepository.GetirOgrencininDersleri_Transkript(ogrenci.Id).Veri;
        //    ViewBag.Donemler = _ogrenciDonemDersRepository.GetirOgrencininDersleri_Donemler(ogrenci.Id).Veri;
        //    return View(dersler);
        //}

        //#endregion
    }
}
