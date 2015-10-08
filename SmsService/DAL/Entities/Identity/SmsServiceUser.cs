using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class SmsServiceUser:IdentityUser
    {
        public virtual ICollection<SubscribersBase> SubscribersBases { get; set; } 
        public virtual ICollection<Delivery> Deliveries { get; set; }

        public SmsServiceUser()
        {
            SubscribersBases = new List<SubscribersBase>();
            Deliveries = new List<Delivery>();
        }
    }
}
