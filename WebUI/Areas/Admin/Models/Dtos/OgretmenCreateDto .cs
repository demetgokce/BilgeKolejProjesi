using Microsoft.AspNetCore.Mvc.Rendering;
using Okul.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models.Dtos
{
    public class OgretmenCreateDto
    {
        public OgrenciDto OgrenciDto { get; set; }
        public SelectList Sinif { get; set; }
        public OgretmenDto OgretmenDto { get; internal set; }
    }
}
