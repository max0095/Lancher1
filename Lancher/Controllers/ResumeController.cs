using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "'";

            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();

            //cmd.ExecuteNonQuery();

            try
            {
                while (rd.Read())
                {
                    ViewBag.name = rd.GetString(2);
                    ViewBag.lastname = rd.GetString(3);
                    ViewBag.facebook = rd.GetString(4);
                    ViewBag.univer = rd.GetString(8);
                    

                    //surname = rd.GetString(3); 
                }

            }
            catch { }


            return View();
        }
    }
}