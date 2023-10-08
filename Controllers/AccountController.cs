using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TempleteD.Business_Layer.Repositories;
using TempleteD.Models.IdentityVM;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TempleteD.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly MailingRep mailingRep;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, MailingRep mailingRep, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.mailingRep = mailingRep;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Registration()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM reg)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser
                {
                    UserName = reg.Email,
                    Email = reg.Email
                };

                var res = await userManager.CreateAsync(User, reg.Password);

                if (res.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(reg);
        }

        public async Task<IActionResult> Login()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM User)
        {
            if (ModelState.IsValid)
            {

                var res = await signInManager.PasswordSignInAsync(User.Email, User.Password, User.RememberMe, false);

                if (res.Succeeded)
                {

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Check Your Password Or Email");
                }
            }

            return View(User);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        #region Forget Password
        public async Task<IActionResult> ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordEmailVM model)
        {



            if (ModelState.IsValid)
            {

                var user = await userManager.FindByEmailAsync(model.Email);
               

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { model.Email, Token = token }, protocol: Request.Scheme);

                    await mailingRep.SendingMail(model.Email, "Confirm Reset Password", $"Please reset your password by clicking here: {passwordResetLink}");

                    return RedirectToAction("ConfirmSendMAil");
                }
            }

            return View(model);
        }

        // after send Mail Show already The Mail Was sent.
        public IActionResult ConfirmSendMAil()
        {

            return View();
        }

        public async Task<IActionResult> ResetPassword(string Email, string Token)
        {
            if (Email == null || Token == null)
            {
                ModelState.AddModelError("", "Not Found the Email in Website");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(reset.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, reset.Token, reset.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(reset);
                }

                return RedirectToAction("ResetPassword");
            }

            return View(reset);
        }
        public IActionResult ConfirmResetPassword()
        {

            return View();
        }

        #endregion
    }
}
