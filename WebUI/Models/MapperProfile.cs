using AutoMapper;
using WebUI.Models.Dto;
using Bilge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Okul.Domain;

namespace WebUI.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<LoginDto, Kullanici>();
            CreateMap<Kullanici, LoginDto>();
            CreateMap<RegisterDto, Kullanici>();
            CreateMap<Kullanici, RegisterDto>();
        }
    }
}
