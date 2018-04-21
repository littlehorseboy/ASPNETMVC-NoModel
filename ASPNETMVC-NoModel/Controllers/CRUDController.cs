using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVC_NoModel.Controllers
{
    public class CRUDController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// get city for select option
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCitySelect()
        {
            string sSQL = string.Format("SELECT DISTINCT city FROM CRUD");

            using (SqlDataAdapter da = new SqlDataAdapter(sSQL, connectionString))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                string str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return Json(str_json);
            }
        }

        /// <summary>
        /// datatables.js 要用的Json
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Json</returns>
        [HttpPost]
        public ActionResult GetData(string city)
        {
            string whereString = "";

            if (city != "all")
            {
                whereString = string.Format("WHERE city like '%{0}%'", city);
            }

            string sSQL = string.Format("SELECT * FROM CRUD {0}", whereString);

            using (SqlDataAdapter da = new SqlDataAdapter(sSQL, connectionString))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                string str_json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                return Json(str_json);
            }
        }

        /// <summary>
        /// 新增一筆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertData(string id, string name, string city)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city))
            {
                return Content("Fail");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    command.CommandText = string.Format(@"INSERT INTO CRUD(id, name, city) values(@Id, @Name, @City)");
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name); // 有 SQL 的安全性考量 
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                }
                return Content("Success");
            }
        }

        [HttpPost]
        public ActionResult UpdateData(string id, string name, string city)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(city))
            {
                return Content("Fail");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    command.CommandText = string.Format(@"UPDATE CRUD SET name = @Name, city = @City WHERE id = @Id");
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name); // 有 SQL 的安全性考量 
                    command.Parameters.AddWithValue("@City", city);
                    command.ExecuteNonQuery();
                }
                return Content("Success");
            }
        }

        [HttpPost]
        public ActionResult DeleteData(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Content("Fail");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    if (connection.State != ConnectionState.Open) connection.Open();
                    command.CommandText = string.Format(@"DELETE FROM CRUD WHERE id = @Id");
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
                return Content("Success");
            }
        }
    }
}