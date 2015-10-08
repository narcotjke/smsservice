using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SubscribersBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public String FilePath { get; set; }
        public int SubscribersNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual SmsServiceUser SmsServiceUser { get; set; }
        public Guid SmsServiceUserId { get; set; }

        public SubscribersBase()
        {
            Deliveries = new List<Delivery>();
        }
    }
}
