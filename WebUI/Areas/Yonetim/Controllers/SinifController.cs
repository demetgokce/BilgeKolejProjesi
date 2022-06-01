using Bilge.DAL.Abstract;
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
    public class SinifController : Controller
    {
        private readonly ISiniflarManager manager;
        private readonly IDersManager dersManager;

        public SinifController(ISiniflarManager manager,
           IDersManager dersManager
           )
        {
            this.manager = manager;
            this.dersManager = dersManager;
        }


        public IActionResult Index()
        {
            List<Siniflar> siniflar = new List<Siniflar>();
            siniflar = manager.GetAll(null);

            if (siniflar.Count == 0)
                siniflar.Add(new Siniflar());

            return View(siniflar);
        }
    }
}
