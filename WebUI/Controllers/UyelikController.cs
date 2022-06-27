using Bilge.Domain;
using Bilge.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private UserManager<ApplicationUser> userManager;
      
        public UyelikController()
        {
            var userStore = new UserStore<ApplicationUser>(new BilgeDbContext());

            userManager = new UserManager<ApplicationUser>(userStore);
        }
    
        public IActionResult İndex()
        {


            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }
            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kayit(Uyelik uyelik)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicatonUser();
                user.UserName = uyelik.UserName;
                user.Email = uyelik.Email;

                var result = IKullaniciManager.Create(user, uyelik.Password);


                if(result.Succeeded)
                {

                    return RedirectToAction("Giris");

                }
                else
                {

                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);

                    }
                }
            }


            return View(uyelik);
        }

    }
}
