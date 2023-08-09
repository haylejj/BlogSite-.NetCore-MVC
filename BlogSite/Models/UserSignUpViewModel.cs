using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz")]
        public string ?nameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string? Password { get; set; }
        [Display(Name ="Şifre Tekrar")]
        [Compare("Password",ErrorMessage =("Şifreler uyuşmuyor!"))]
        public string ?ConfirmPassword { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string? UserName { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen E-Mail Giriniz")]
        public string? Mail { get; set; }
    }
}
