using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class HomerController : Controller
    {
        // GET: Homer
        public ActionResult FirstPage()
        {
            return View();
        }
    }
}