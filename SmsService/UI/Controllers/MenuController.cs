using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models.Menu;

namespace UI.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public PartialViewResult RightSideMenu()
        {
            var menu = new MenuViewModel();
            return PartialView(menu);
        }
	}
}