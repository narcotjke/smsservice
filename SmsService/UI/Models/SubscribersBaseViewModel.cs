using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class SubscribersBaseViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubscribersNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string Path { get; set; }

        [ScaffoldColumn(false)]
        public Guid SmsServiceUserId { get; set; }
    }
}