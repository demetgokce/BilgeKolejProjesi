using AutoMapper;
using Bilge.BLManager.Abstract;
using WebUI.Areas.admin.Models.Dtos;
using Bilge.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okul.BLManager.Abstract;
using Okul.Domain;

namespace WebUI.Areas.admin.Controllers
{
    
   
        [Area("Admin")]
        [Authorize]
        public class KullaniciController : Controller
        {
            private readonly IKullaniciManager us;
            private readonly IMapper mapper;


            public KullaniciController(IKullaniciManager us, IMapper mapper)
            {
                this.us = us;
                this.mapper = mapper;

            }
            [AllowAnonymous]
            public IActionResult Index()
            {
                return View(us.GetAll(null));
            }
            [AllowAnonymous]
            public IActionResult Create()
            {
                LoginCreateDto entity = new LoginCreateDto();


                return View(entity);
            }
            [AllowAnonymous]
            [HttpPost]
            public IActionResult Create(LoginCreateDto k)
            {
                if (ModelState.IsValid)
                {
                    var kullanici = mapper.Map<LoginCreateDto, Kullanici>(k);
                    us.Add(kullanici);
                    return RedirectToAction("Index", "Kullanici");

                }
                return View();
            }
            public IActionResult Update(int id)
            {
                var entity = us.Find(id);
                return View(entity);
            }
            [HttpPost]
            public IActionResult Update(Kullanici user)
            {
                if (ModelState.IsValid)
                {
                    us.Update(user);
                    return RedirectToAction("Index", "Kullanici");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                var entity = us.Find(id);
                return View(entity);
            }

            [HttpPost]
            public IActionResult Delete(Kullanici user)
            {
                us.Delete(user);
                return RedirectToAction("Index", "Kullanici");

            }
            [HttpGet]
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
    
}
