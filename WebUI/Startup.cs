using Bilge.DAL.EfCore;
using Bilge.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BilgeDbContext>((options => options.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=BilgeDb;User Id=postgres;Password=123;")));
            

            services.AddScoped<DersRepository>();
            services.AddScoped<OgretmenRepository>();
            services.AddScoped<OgrenciRepository>();
            services.AddScoped<SinifRepository>();
            services.AddScoped<VeliRepository>();
            services.AddScoped<DonemRepository>();
            services.AddScoped<YoklamaRepository>();


            #region Cookie Base Authentication Ayarlari
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/OgrenciIslem/GirisYap"; //Giris Sayfasi
                    x.LogoutPath = "/OgrenciIslem/Cikis"; // Cikis 
                    x.AccessDeniedPath = "/OgrenciIslem/YetkiHatasi";
                    x.Cookie.HttpOnly = true;
                    x.Cookie.Name = "Bilge";
                    x.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    x.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Cookie'nin ömrünü belirler.
                });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
