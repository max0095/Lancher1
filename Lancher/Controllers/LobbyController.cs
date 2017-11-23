using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;
using MySql.Data.MySqlClient;

namespace Lancher.Controllers
{
    public class LobbyController : Controller
    {
        // GET: Lobby
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lobby()
        {
            string email = Session["email"].ToString();
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM post ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<post_model>();
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    var post_m = new post_model();                  
                    post_m.Title = dr.GetString(1);
                    post_m.PostMoney = dr.GetString(5);
                    post_m.PostDescrip = dr.GetString(2);
                    post_m.PostMany = dr.GetString(3);
                    post_m.TyprPost = dr.GetString(4);
                    post_m.DeadlinePost = Convert.ToDateTime(dr.GetString(6));
                    model.Add(post_m);
                }
            }
            catch
            {

            }
            return View();
        }

        public ActionResult LobbyCode()
        {
            return View();
        }
    }
}