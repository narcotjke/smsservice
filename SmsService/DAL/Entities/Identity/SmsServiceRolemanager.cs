using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL.Entities
{
    public class SmsServiceRoleManager:RoleManager<SmsServiceRole>
    {
        public SmsServiceRoleManager(RoleStore<SmsServiceRole> store) : base(store)
        {
        }

        public static SmsServiceRoleManager Create(IdentityFactoryOptions<SmsServiceRoleManager> options,
            IOwinContext context)
        {
            return new SmsServiceRoleManager(new RoleStore<SmsServiceRole>(context.Get<SmsServiceContext>()));
        }
    }
}
