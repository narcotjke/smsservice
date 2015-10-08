using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Balance
    {
        public Guid Id { get; set; }
        public virtual SmsServiceUser SmsServiceUser { get; set; }
        public decimal Amount { get; set; }
    }
}
