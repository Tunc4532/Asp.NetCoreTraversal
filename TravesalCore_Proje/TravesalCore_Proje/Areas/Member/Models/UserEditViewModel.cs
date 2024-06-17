using Microsoft.AspNetCore.Http;

namespace TravesalCore_Proje.Areas.Member.Models
{
	public class UserEditViewModel
	{
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? password { get; set; }
        public string? confirmpassword { get; set; }
        public string? Phonenumber { get; set; }
        public string? email { get; set; }
        public string? imageurl { get; set; }
        public IFormFile? image { get; set; }

    }
}
