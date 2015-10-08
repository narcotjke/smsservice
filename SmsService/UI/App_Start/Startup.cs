using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using DAL;
using DAL.Entities;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(UI.Startup))]


namespace UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<SmsServiceContext>(SmsServiceContext.Create);
            app.CreatePerOwinContext<SmsServiceUserManager>(SmsServiceUserManager.Create);
            app.CreatePerOwinContext<SmsServiceRoleManager>(SmsServiceRoleManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}