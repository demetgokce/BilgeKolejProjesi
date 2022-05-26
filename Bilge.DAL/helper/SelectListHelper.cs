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
        #region Değişkenler

        
      
        private static DonemRepository _donemRepository = new DonemRepository();
        private static OgretmenRepository _ogretmenRepository = new OgretmenRepository();
        private static DersRepository _dersRepository = new DersRepository();
        private static SinifRepository _sinifRepository = new SinifRepository();



        private static IEnumerable<SelectListItem> _donemTipler;
        public static IEnumerable<SelectListItem> DonemTipler
        {
            get
            {
                if (_donemTipler == null)
                    _donemTipler = new List<SelectListItem>()
                    {
                        new SelectListItem{ Value = ((int)DonemTipEnum.Bahar).ToString(), Text = "Bahar" },
                        new SelectListItem{ Value = ((int)DonemTipEnum.Guz).ToString(), Text = "Güz" },
                        new SelectListItem{ Value = ((int)DonemTipEnum.Yaz).ToString(), Text = "Yaz" }
                    };
                return _donemTipler;
            }
        }

        #endregion

       
        

        public static IEnumerable<SelectListItem> Donem
        {
            get
            {
                var donemler = _donemRepository.GetirTumu_SelectList();
                if (donemler.BasariliMi)
                    return donemler.Veri;
                return null;
            }
        }

        public static IEnumerable<SelectListItem> GetirDersOgretmenleri(int dersId)
        {
            var ogretmen = _ogretmenRepository.GetirDersOgretmenleri_SelectList(dersId);
            if (ogretmen.BasariliMi)
                return ogretmen.Veri;
            return null;
        }
        //public static IEnumerable<SelectListItem> GetirSinifDersleri(int sinifId)
        //{
        //    var dersler = _dersRepository.GetirSinifDersleri_SelectList(sinifId);
        //    if (dersler.BasariliMi)
        //        return dersler.Veri;
        //    return null;
        //}



       


    }
}
