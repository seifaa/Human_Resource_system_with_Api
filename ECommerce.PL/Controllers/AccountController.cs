using ECommerce.BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> manger;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> manger, SignInManager<IdentityUser> SignInManager,ILogger<AccountController> logger)
        {
            this.manger = manger;
            signInManager = SignInManager;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Register
        public IActionResult Regisetration()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Regisetration(RegisterationVM model)
        {
            if (ModelState.IsValid) {
                var data = new IdentityUser()
                { UserName = model.UserName,
                    Email = model.Email
                   
                };
            var res= await   manger.CreateAsync(data, model.Password);
                if (res.Succeeded) {
                    return RedirectToAction("login");
                }
                else {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(" ", error.Description);
                    }
                
                
                }



            }
            else
            {


                return View(model);
            }
            return View();
        }

        //Login
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> login(LoginVM model)
        {

            if (ModelState.IsValid)
            {
              var res=  await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or passwod");
                }
            }
            else { return View(model); }
            return View();
        }

        //Forget Password
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {



                var user = await manger.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await manger.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);


                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return RedirectToAction("ConfirmForgetPassword");



                }
                else { ModelState.AddModelError("", "UserNotFound"); }
                
            }
            return View(model);
        }

        //Confirm Forget Password
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }


        //Resset Password
        public IActionResult ResetPassword(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(RessetPasswordVM model)
        {
            if (ModelState.IsValid) {

                var user = await manger.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await manger.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                      return View(model);

                }

               

            }
            return View(model);
        }



        //Logout
        public async Task <IActionResult> logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    }
}
