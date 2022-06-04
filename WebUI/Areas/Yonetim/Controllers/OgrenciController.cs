using AutoMapper;
using Bilge.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BLManager.Abstract;
using Okul.BLManager.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Models.Dtos;
using WebUI.Areas.Yonetim.Models;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Yonetim")]
    public class OgrenciController : Controller
    {
        private readonly IOgrenciManager manager;
        private readonly ISiniflarManager sinifManager;
        private readonly IMapper mapper;

        public OgrenciController(IOgrenciManager manager,
           ISiniflarManager sinifManager, IMapper mapper
           )
        {
            this.manager = manager;
            this.sinifManager = sinifManager;
            this.mapper = mapper;
        }



        public IActionResult Index()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler = manager.GetAll(null);

            if (ogrenciler.Count == 0)
                ogrenciler.Add(new Ogrenci());

            return View(ogrenciler);
        }
        public IActionResult Create()
        {
            OgrenciCreateDto createDto = new OgrenciCreateDto();

            createDto.OgrenciDto = new OgrenciDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            var siniflar = sinifManager.GetAll(null);
            var sinifSelect = mapper.Map<List<Siniflar>, List<SinifModel>>(siniflar);
            createDto.Siniflar = new SelectList(sinifSelect, "Id", "SinifAdi");

            return View(createDto);
        }

        [HttpPost]
        public IActionResult Create(OgrenciCreateDto dto)
        {

            if (ModelState.IsValid)
            {


                var ogrenci = mapper.Map<OgrenciDto, Ogrenci>(dto.OgrenciDto);
                ogrenci.SinifId = 1;
                try
                {
                    manager.CheckForTckimlik(ogrenci.TcNo);
                    manager.CheckForGsm(ogrenci.Gsm);
                    manager.Add(ogrenci);

                    return RedirectToAction("Index", "Ogrenci", new { Areas = "Yonetim" });
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }

            }

            return View(dto);
        }
    }
}
