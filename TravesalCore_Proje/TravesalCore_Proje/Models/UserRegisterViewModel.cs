using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace TravesalCore_Proje.Models
{
	public class UserRegisterViewModel
	{
		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen adınızı girin")]
        public string? Name { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen soyadaınız girin")]
		public string? Surname { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "kullanıcı adınızı girin")]
		public string? UserName { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Mail adresinizi girin")]
		public string? Mail { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifrenizi girin")]
		public string? Password { get; set; }

		[Compare("Password",ErrorMessage ="Şifreler uyyumlu değil")]
		public string? ConfrimPassword { get; set; }

	}
}
