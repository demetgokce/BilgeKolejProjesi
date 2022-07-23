using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Dto
{
    public class RegisterDto
    {
        [Display(Name = "İsim Soyisim")]
        [Required]
        public string UserName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mail adresini giriniz.")]

        public string EmailAdress { get; set; }

        [Required]
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Sifre Alani Bos Olamaz")]
        [Compare("Password")]
        public string RePassword { get; set; }
        public string ConfirmPassword { get; set; }


    }
}
