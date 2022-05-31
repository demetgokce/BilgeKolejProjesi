using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanici Kodu boş olamaz")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alani boş geçilemez")]
        [MaxLength(50)]
        
        public string Password { get; set; }
        public bool State { get; set; }
    }
}
