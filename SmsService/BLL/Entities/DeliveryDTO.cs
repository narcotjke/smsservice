using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ServiceId { get; set; }
        public string MessageText { get; set; }
        public int DeliveryRate { get; set; }
        public DateTime Date { get; set; }
        public Guid SmsServiceUserId { get; set; }
        public int SubscribersBaseId { get; set; }
        //public ICollection<int> SubscriberBases { get; set; }

        /*public DeliveryDTO()
        {
            SubscriberBases = new List<int>();
        }*/
    }
}
