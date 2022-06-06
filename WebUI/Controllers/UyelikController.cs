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

        public IActionResult Kayit()
        {


            return View();
        }

    }
}
