using Demo.DAL.Entities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AccountController(
            
            UserManager<ApplicationUser> userManager
           , SignInManager<ApplicationUser> signInManager )
        {
            this.userManager = userManager;
			this.signInManager = signInManager;
		}
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                { UserName = registerViewModel.Email.Split('@')[0],
                 Email = registerViewModel.Email,
                 IsAgree= registerViewModel.IsAgree,
                 //معملتش مابينج للباسورد عشان بيتعمله هاشينج وبعدين يتسجل في الداتابيز بتاعتي
                };
                var result = await  userManager.CreateAsync(user , registerViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(registerViewModel);
        }
		public IActionResult SignIn()
		{
			return View();
		}
        [HttpPost]
		public async Task <IActionResult> SignIn(SignInViewModel signInViewModel)
		{
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(signInViewModel.Email);

                if (user is null)
                    ModelState.AddModelError("", "Email does not exist");

                var iscorrectpassword = await userManager.CheckPasswordAsync(user, signInViewModel.Password);
                if (iscorrectpassword)
                {
                    var result = await signInManager.PasswordSignInAsync(user, signInViewModel.Password, signInViewModel.RememberMe, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                } 

            }
			return View(signInViewModel);
		}

        public async Task <IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }

	}
}
