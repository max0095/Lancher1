using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;

namespace Lancher.Controllers
{
    public class PostController : Controller
    {

        // GET: Post
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Post()
        {
            string email = Session["email"].ToString();
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM post WHERE PostEmailID = '" + email + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<post_model>();
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    var post_m = new post_model();
                    post_m.PostID = dr.GetString(0);
                    post_m.Title = dr.GetString(1);
                    post_m.PostMoney = dr.GetString(5);
                    post_m.PostDescrip = dr.GetString(2);
                    post_m.PostMany = dr.GetString(3);
                    post_m.TyprPost = dr.GetString(4);
                    post_m.DeadlinePost =Convert.ToDateTime(dr.GetString(6));
                    model.Add(post_m);
                }
            }
            catch
            {

            }
            /*try
            {
                while (rd.Read())
                {
                    ViewBag.idpost = rd.GetString(0);
                    ViewBag.Title = rd.GetString(1);
                    ViewBag.pucket = rd.GetString(5);
                    ViewBag.des = rd.GetString(2);
                    ViewBag.Many = rd.GetString(3);
                    ViewBag.type = rd.GetString(4);
                    ViewBag.Deadline = rd.GetString(6);
                }

            }
            catch
            {

            }*/

            return View(model);
        }

        public ActionResult PostCode()
        {
            string idpost = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            string Name_Post5 = Request.Form["Name_Post5"];
            string Des = Request.Form["Des"];
            string many = Request.Form["many"];
            string typepost = Request.Form["typepost"];
            string Pucket = Request.Form["Pucket"];
            string deadline = Request.Form["deadline"];

            string email = Session["email"].ToString();

            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "INSERT INTO post(PostID ,Title ,PostDescrip ,PostMany ,TypePost ,MoneyPost ,DeadlinePost ,PostEmailID )"
                            + "VALUES" + "('" + idpost + "','" + Name_Post5 + "','" + Des + "','" + many + "','" + typepost + "','" + Pucket + "','" + deadline + "','" + email + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Post", "Post");
        }   
    }
}