using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using EcommerceAPI.Services;

namespace EcommerceAPI.Controllers
{
    public class VendorController : Controller
    {
        private readonly DbHelper _db;

        public VendorController(DbHelper db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllVendors()
        {
            List<Vendor> list = new List<Vendor>();

            using (SqlConnection con = _db.GetConnection())
            {
                string query = "SELECT * FROM Vendors";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Vendor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return Ok(list);
        }
    }
}
