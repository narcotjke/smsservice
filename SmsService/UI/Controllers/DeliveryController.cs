using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UI.Models;
using UI.Services;

namespace UI.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly DeliveryService _service = new DeliveryService();

        [HttpGet]
        public ActionResult Create()
        {
            Guid id;
            var model = Guid.TryParse(User.Identity.GetUserId(), out id) ? new DeliveryViewModel(id) : new DeliveryViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeliveryViewModel delivery)
        {
            Guid id;
            Guid.TryParse(User.Identity.GetUserId(), out id);

            if (!ModelState.IsValid)
            {
                delivery.FillSubscribersBases(id);
                return View(delivery);
            }

            delivery.SmsServiceUserId = id;
            _service.SaveDelivery(delivery);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult PlannedDeliveries()
        {
            var deliveries = _service.GetDeliveries(DateTime.Now, DateTime.MaxValue);

            return View("DeliveryList", deliveries);
        }

        [HttpPost]
        public ActionResult PlannedDeliveries(DateTime? from, DateTime? to)
        {
            if (to > DateTime.Now)
            {
                to = DateTime.Now;
            }

            var deliveries = _service.GetDeliveries(from, to);

            return View("DeliveryList", deliveries);
        }

        [HttpGet]
        public ActionResult ConductedDeliveries()
        {
            var deliveries = _service.GetDeliveries(DateTime.MinValue, DateTime.Now);

            return View("DeliveryList", deliveries);
        }

        [HttpPost]
        public ActionResult ConductedDeliveries(DateTime? from, DateTime? to)
        {
            var deliveries = _service.GetDeliveries(from, to);

            return View("DeliveryList", deliveries);
        }
	}
}