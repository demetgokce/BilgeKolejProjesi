using Bilge.DAL.EfCore;
using Bilge.Domain.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain.HelperModels
{
   public class SelectListHelper
    {

       // #region Değişkenler

       
       // private static SinifRepository _sinifRepository = new SinifRepository();
       // private static DonemRepository _donemRepository = new DonemRepository();
       // private static OgretmenRepository _ogretmenRepository = new OgretmenRepository();
       // private static DersRepository _dersRepository = new DersRepository();
       //       private static OgrenciRepository _ogrenciRepository = new OgrenciRepository();
      

       // private static IEnumerable<NSelectListItem> _donemTipler;
       // private List<NSelectListItem> donemListesi;
        
     

       // public SelectListHelper(List<NSelectListItem> donemListesi)
       // {
       //     this.donemListesi = donemListesi;
           
       // }

       // public static IEnumerable<NSelectListItem> DonemTipler
       // {
       //     get
       //     {
       //         if (_donemTipler == null)
       //             _donemTipler = new List<NSelectListItem>()
       //             {
       //                 new NSelectListItem{ Value = ((int)DonemTipEnum.Bahar).ToString(), Text = "Bahar" },
       //                 new NSelectListItem{ Value = ((int)DonemTipEnum.Guz).ToString(), Text = "Güz" },
       //                 new NSelectListItem{ Value = ((int)DonemTipEnum.Yaz).ToString(), Text = "Yaz" }
       //             };
       //         return _donemTipler;
       //     }
       // }

       // #endregion

       

       // public static IEnumerable<NSelectListItem> Sinif
       // {
       //     get
       //     {
       //         var siniflar = _sinifRepository.GetirTumu_SelectListHelper();
       //         if (siniflar.BasariliMi)
       //             return Sinif.Veri;
       //         return new SelectListHelper(null);
       //     }
       // }

       //// public static IEnumerable<NSelectListItem> Donemler
       // {
       //     get
       //     {
       //         var donemler = _donemRepository.GetirTumu_SelectList();
       //         if (donemler.BasariliMi)
       //             return Donemler.Veri;
       //         return new SelectListHelper(null);
       //     }
       // }

       // public static IEnumerable<NSelectListItem> GetirDersOgretmenleri(int dersId)
       // {
       //     var ogretmen = _ogretmenRepository.GetirDersOgretmenleri_SelectList(dersId);
       //     if (ogretmen.BasariliMi)
       //         return ogretmen.Veri;
       //     return new SelectListHelper(null);
       // }
       // public static IEnumerable<NSelectListItem> GetirSinifDersleri(int sinifId)
       // {
       //     var dersler = _dersRepository.GetirSinifDersleri_SelectList(sinifId);
       //     if (dersler.BasariliMi)
       //         return dersler.Veri;
       //     return new SelectListHelper(null);
       // }





    }
}
