using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Delivery
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int ServiceId { get; set; }
        public String MessageText { get; set; }
        public int DeliveryRate { get; set; }
        public DateTime Date { get; set; }
        public SmsServiceUser SmsServiceUser { get; set; }
        public Guid SmsServiceUserId { get; set; }
        public virtual SubscribersBase SubscribersBase { get; set; }
        public int SubscribersBaseId { get; set; }
    }
}
