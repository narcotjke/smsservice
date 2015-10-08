using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL
{
    public class SmsServiceUserManager:UserManager<SmsServiceUser>
    {
        public SmsServiceUserManager(IUserStore<SmsServiceUser> store) : base(store)
        {
        }

        public static SmsServiceUserManager Create(IdentityFactoryOptions<SmsServiceUserManager> options, IOwinContext context)
        {
            SmsServiceContext db = context.Get<SmsServiceContext>();
            SmsServiceUserManager manager = new SmsServiceUserManager(new UserStore<SmsServiceUser>(db));

            return manager;
        }
    }
}
