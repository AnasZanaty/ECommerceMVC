using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
	public class SignInViewModel
	{
		[Required]
		[EmailAddress(ErrorMessage = "Wrong Email")]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	
		public bool RememberMe { get; set; }

	}
}
