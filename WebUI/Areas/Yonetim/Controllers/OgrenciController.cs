using Bilge.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okul.BLManager.Abstract;
using Okul.BLManager.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Yonetim")]
    public class OgrenciController : Controller
    {
        private readonly IOgrenciManager manager;
        private readonly ISiniflarManager sinifManager;


        public OgrenciController(IOgrenciManager manager,
           ISiniflarManager sinifManager
           )
        {
            this.manager = manager;
            this.sinifManager = sinifManager;
           
        }



        public IActionResult Index()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler = manager.GetAll(null);

            if (ogrenciler.Count == 0)
                ogrenciler.Add(new Ogrenci());

            return View(ogrenciler);
        }
    }
}
