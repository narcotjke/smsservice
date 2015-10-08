using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class SubscribersBaseDTO
    {
        public String Name { get; set; }
        public int Subscribersnumber { get; set; }
        public DateTime CreationDate { get; set; }
        public String FilePath { get; set; }
        public ICollection<int> Deliveries { get; set; }
        public Guid SmsServiceUserId { get; set; }

        public SubscribersBaseDTO()
        {
            Deliveries = new List<int>();
        }
    }
}
