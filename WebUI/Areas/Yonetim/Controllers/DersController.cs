using Bilge.Domain;
using Microsoft.AspNetCore.Mvc;
using Okul.BLManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class DersController : Controller
    {

        //Sadece Constructer icerisinde set edilebilir

        private readonly IDersManager manager;

        public DersController(IDersManager manager)
        {

            this.manager = manager;
        }
        public IActionResult Index()
        {
            var dersler = manager.GetAll(null);



            return View(dersler);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Ders entity = new Ders();
            return View(entity);
        }

        [HttpPost]
        public IActionResult Create(Ders ders)
        {
            if (ModelState.IsValid)
            {
                //repository.Insert(ders);
                if (!manager.CheckForDersAd(ders.DersAd))
                {
                    manager.Add(ders);
                    return RedirectToAction("Index", "Ders");

                }
                ModelState.AddModelError("", "Bu ders daha once tanimlanmistir.");

            }


            return View();
        }

        public IActionResult Update(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Update(Ders ders)
        {
            if (ModelState.IsValid)
            {
                manager.Update(ders);
                return RedirectToAction("Index", "Ders");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = manager.Find(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Ders ders)
        {
            manager.Delete(ders);
            return RedirectToAction("Index", "Ders");

        }
    }
}
