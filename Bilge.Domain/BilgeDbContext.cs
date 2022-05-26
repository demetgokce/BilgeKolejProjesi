using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
 public  class BilgeDbContext: DbContext
    {
        public DbSet<Donem> Donem { get; set; }
        public DbSet<Ders> Ders{ get; set; }
        public DbSet<Veli> Veliler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<DersProgram> DersProgramlar { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<DonemDers> DonemDers { get; set; }
        public DbSet<OgrenciDonemNot> OgrenciDonemNotlar { get; set; }
        public DbSet<Yoklama> Yoklamalar { get; set; }

        



             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                 optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7I7PU0G;Initial Catalog=BilgeKolej;Integrated //Security=True;Connect //Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

          
             }
             


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {

        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7I7PU0G;Initial Catalog=BilgeKolej;Integrated //Security=True;Connect //Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // }


       



    }

    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}
