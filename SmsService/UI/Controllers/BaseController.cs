using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using UI.Services;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly SubscribersService _subscribersService = new SubscribersService();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase fileUpload)
        {
            var directory = Server.MapPath("~/");
            var file = Request.Files["Filedata"];

            if (file == null)
            {
                return RedirectToAction("Create");
            }

            Guid id;

            if (!Guid.TryParse(User.Identity.GetUserId(), out id))
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction(!_subscribersService.SaveSubscribersBase(file, id, directory) ? "Create" : "List");
        }

        [HttpGet]
        public ActionResult List()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var bases = _subscribersService.GetUserBases(id);

            return bases.Any() ? View(bases) : View();
        }
	}
}