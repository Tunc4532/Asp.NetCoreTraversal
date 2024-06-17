using System.ComponentModel.DataAnnotations;

namespace TravesalCore_Proje.Models
{
    public class UserSıgnInUserModel
    {

        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Lütfen şifreniizi giriniz.")]
        public string? password { get; set; }

    }
}
