using AutoMapper;
using Bilge.BLManager.Abstract;
using Bilge.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.BLManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OgretmenController : Controller
    {
        private readonly IOgretmenManager manager;
        private readonly ISiniflarManager sinifManager;
        private readonly IMapper mapper;

        public OgretmenController(IOgretmenManager manager,
           ISiniflarManager sinifManager, IMapper mapper
           )
        {
            this.manager = manager;
            this.sinifManager = sinifManager;
            this.mapper = mapper;
        }



        public IActionResult Index()
        {
            List<Ogretmen> ogretmenler = new List<Ogretmen>();
            ogretmenler = manager.GetAll(null);

            if (ogretmenler.Count == 0)
                ogretmenler.Add(new Ogretmen());

            return View(ogretmenler);
        }

        public IActionResult Create()
        {
            OgretmenCreateDto createDto = new OgretmenCreateDto();

            createDto.OgretmenDto = new OgretmenDto();
            //createDto.Sinif = 

            //new SelectList(fruits, "Id", "SinifAdi");
            var siniflar = sinifManager.GetAll(null);
            var sinifSelect = mapper.Map<List<Siniflar>, List<SinifModel>>(siniflar);
            createDto.Sinif = new SelectList(sinifSelect, "Id", "SinifAdi");

            return View(createDto);
        }
        public IActionResult Create(OgretmenCreateDto dto)
        {

            if (ModelState.IsValid)
            {


                var ogretmen = mapper.Map<OgretmenDto, Ogretmen>(dto.OgretmenDto);
                ogretmen.SinifId = 1;
                try
                {
                    manager.CheckForTckimlik(ogretmen.TcNo);
                    manager.CheckForGsm(ogretmen.Gsm);
                    manager.Add(ogretmen);

                    return RedirectToAction("Index", "Ogretmen", new { Areas = "Admin" });
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
