using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class UserSingInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı adını girin.")]
        public string? username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi girin.")]
        public string ?password { get; set; }
    }
}
