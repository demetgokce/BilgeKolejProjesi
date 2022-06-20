using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models.Dtos;

namespace WebUI.Areas.Yonetim.Models
{
    public class OgrenciCreateDto
    {

        public OgrenciDto OgrenciDto { get; set; }
        public SelectList Siniflar { get; set; }
    }
}
