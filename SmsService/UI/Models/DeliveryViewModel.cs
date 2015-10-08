using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using UI.Services;

namespace UI.Models
{
    public class DeliveryViewModel
    {
        private readonly SubscribersService _service = new SubscribersService();

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ServiceId { get; set; }
        public ICollection<SubscribersBaseViewModel> SubscribersBases { get; set; }

        [ScaffoldColumn(false)]
        public int SubscribersBaseId { get; set; }
        //public List<int> SubscribersBaseId { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public int DeliveryRate { get; set; }
        public DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public Guid SmsServiceUserId { get; set; }

        public DeliveryViewModel()
        {
            Date = DateTime.Now;
        }

        public DeliveryViewModel(Guid id)
        {
            FillSubscribersBases(id);
            Date = DateTime.Now;
        }

        public void FillSubscribersBases(Guid id)
        {
            SubscribersBases = _service.GetUserBases(id);
        }
    }
}