using MySql.Data.MySqlClient;
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
            string email = Session["email"].ToString();
            
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();
            return View();
        }
    }
}