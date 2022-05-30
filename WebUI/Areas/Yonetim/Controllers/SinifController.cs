using Bilge.DAL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Yonetim")]
    public class SinifController : Controller
    {



        private readonly ISinifRepository repository;

        public SinifController(ISinifRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {

            var siniflar = repository.GetAll();
            return View(siniflar);
        }
    }
}
