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
        public ActionResult Jabb()
        {
            string email = Session["email"].ToString();
            string Photo = Session["Photo"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT post.* , posting.EmailID , posting.PostID FROM posting inner join user on posting.EmailID = user.EmailID inner join post on posting.PostID = post.PostID WHERE posting.EmailID = '" + email + "' ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<ThreeTableViewModel>();
            string keepphoto = Session["Photo"].ToString();
            MySqlDataReader rd = cmd.ExecuteReader();

            ViewBag.showImag = keepphoto;

            try
            {
                while (rd.Read())
                {
                    var Threepost_m = new ThreeTableViewModel();
                    Threepost_m.PostID = rd.GetString(0);
                    Threepost_m.Title = rd.GetString(10);
                    Threepost_m.PostMoney = rd.GetString(5);
                    Threepost_m.PostDescrip = rd.GetString(2);
                    Threepost_m.PostMany = rd.GetString(3);
                    Threepost_m.TypePost = rd.GetString(4);
                    Threepost_m.DeadlinePost = Convert.ToDateTime(rd.GetString(6));

                    ViewBag.showImag = keepphoto;

                    model.Add(Threepost_m);
                }

            }
            catch { }


            return View(model);
        }

        public ActionResult Jubb()
        {
            return View();
        }
    }
}