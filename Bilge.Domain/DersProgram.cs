using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
    public class DersProgram : BaseEntity
    {

        [Key]
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }

        public int SiniflarId { get; set; }
        public Siniflar Sinif { get; set; }


        public int DersId { get; set; }
        public Ders Ders { get; set; }




        public ICollection<Yoklama> Yoklamalar { get; set; }

    }
}
