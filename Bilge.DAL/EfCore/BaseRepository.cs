using Bilge.DAL.Abstract;
using Bilge.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.EfCore
{
  public  class BaseRepository:IBaseRepository
    {
        protected BilgeDbContext _veritabani = new BilgeDbContext();
        protected UyelikRepository _uyelik;

        public BaseRepository(bool uyelikAlinsinMi = true)
        {
            if (uyelikAlinsinMi)
                if (_uyelik == null)
                    _uyelik = new UyelikRepository();
        }

        public void Dispose()
        {
            _veritabani.Dispose();
        }

    }
}
