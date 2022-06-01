using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Okul.Domain;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
    public class BilgeDbContext : DbContext
    {
        public DbSet<Donem> Donem { get; set; }
        public DbSet<Ders> Ders { get; set; }
        public DbSet<Veli> Veliler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<DersProgram> DersProgramlar { get; set; }
        public DbSet<Siniflar> Siniflar { get; set; }
        public DbSet<DonemDers> DonemDers { get; set; }
        public DbSet<OgrenciDonemDers> OgrenciDonemDers { get; set; }
        public DbSet<Yoklama> Yoklamalar { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public BilgeDbContext()
        {

        }

        public BilgeDbContext(DbContextOptions<BilgeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=.;Database=OkulDb;User Id=sa;password=123");
            //optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=BilgeDb;User Id=postgres;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           


            #region Sinif
            modelBuilder.Entity<Siniflar>().Property(e => e.SinifAdi).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Siniflar>().HasData(
                new Siniflar { SinifAdi = "9A", Kapasite = 25,Kod="100", Id = 1 },
                new Siniflar { SinifAdi = "10A", Kapasite = 25, Kod = "101", Id = 2 },
                new Siniflar { SinifAdi = "11A", Kapasite = 25, Kod = "102", Id = 3 },
                new Siniflar { SinifAdi = "12A", Kapasite = 25, Kod = "103", Id = 4 }
                );

            #endregion

        }
    }
}