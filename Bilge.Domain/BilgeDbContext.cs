using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        

        public BilgeDbContext()
        {

        }

        public BilgeDbContext(DbContextOptions<BilgeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=.;Database=OkulDb5142;User Id=sa;password=123");
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=BilgeDb;User Id=postgres;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}