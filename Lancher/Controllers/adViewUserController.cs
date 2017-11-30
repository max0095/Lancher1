using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Lancher.Models;
using System.Data.SqlClient;

namespace Lancher.Controllers
{
    public class adViewUserController : Controller
    {
        // GET: adViewUser
        public ActionResult adViewUser()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    var User = new user();
                    User.EmailID = dr.GetString(0);
                    User.Mistake = dr.GetString(11);
                    model.Add(User);

                }
                con.Clone();
            }
            catch
            {

            }

            return View(model);

            return View();
        }

        public ActionResult adViewUserUpdate()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user ";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    var post_m = new user();

                    post_m.EmailID = dr.GetString(0);
                    post_m.Password = dr.GetString(1);
                    post_m.FirstName = dr.GetString(2);
                    post_m.LastName = dr.GetString(3);
                    post_m.FacebookName = dr.GetString(4);
                    post_m.Height = dr.GetString(5);
                    post_m.Weight = dr.GetString(6);
                    post_m.BirthDay = Convert.ToDateTime(dr.GetString(7));
                    post_m.Education = dr.GetString(8);
                    post_m.ImgUser = dr.GetString(9);
                    post_m.StatusUser = dr.GetString(10);

                    model.Add(post_m);
                    //model1.Add(three);
                }
                return View(model);
            }
            catch
            {

            }

            return View(model);
        }

        public ActionResult sqlserver()
        {

            return View();
        }

        public ActionResult addserver()
        {
            string title = Request.Form["title"];
            string selectImag = Request.Form["selectImag"];
            string description = Request.Form["description"];

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FH9A82H; Initial Catalog=lancherdb;User Id=sa;Password=root");
            string strSQLserver = "INSERT INTO news(title,selectImag,description)"
                + "VALUE" + "('" + title + "','" + selectImag + "','" + description + "')";
            con.Open();
            SqlCommand cmdSqlserver = new SqlCommand(strSQLserver, con);
            cmdSqlserver.ExecuteNonQuery();

            return View();
        }

        
    }
}