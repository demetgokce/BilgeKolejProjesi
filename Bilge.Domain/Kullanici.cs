using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.Domain
{
  public  class Kullanici:BaseEntity
    {

        
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public DateTime LoginDate { get; set; }

       
    }
}
