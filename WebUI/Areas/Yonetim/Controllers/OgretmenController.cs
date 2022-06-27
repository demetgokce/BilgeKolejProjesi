using AutoMapper;
using Bilge.BLManager.Abstract;
using Bilge.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okul.BLManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Yonetim")]
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
       

      
    }
}
