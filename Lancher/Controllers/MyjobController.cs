using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;
namespace Lancher.Controllers
{
    public class MyjobController : Controller
    {
        [Route("[c ontroller]/[action]")]
        public ActionResult Jabb()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Jabbmo()
        {
            return View();
        }
    }
}