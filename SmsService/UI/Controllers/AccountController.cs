using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        #region Properties
        private SmsServiceUserManager Usermanager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<SmsServiceUserManager>(); }
        }

        private SmsServiceRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<SmsServiceRoleManager>(); }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        #endregion
        #region Register

        [Authorize(Roles = "admin")]
        public ActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                SmsServiceUser user = new SmsServiceUser
                {
                    UserName = model.Nickname,
                    Email = model.Email
                };

                IdentityResult result = await Usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = RoleManager.FindByName("admin");
                    Usermanager.AddToRole(user.Id, role.Name);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error);
                }
            }

            return View(model);
        }
        #endregion
        #region Login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                SmsServiceUser user = await Usermanager.FindAsync(model.Login, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(String.Empty, "Неверный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claims =
                        await Usermanager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claims);

                    
                    //if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.ToString());
                    
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
        #endregion
    }
}