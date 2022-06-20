using Bilge.Domain;
using Microsoft.AspNetCore.Mvc;
using Okul.BLManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class UyelikController : Controller
    {
        
        private readonly IUyelikManager manager;
        public UyelikController(IUyelikManager manager)
        {

            this.manager = manager;

        }
    
        public IActionResult İndex()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Kayit(Uyelik uyelik)
        {
            


            return View();
        }

    }
}
