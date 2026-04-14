using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DbHelper _db;

        public AuthController(DbHelper db)
        {
            _db = db;
        }

      
        [HttpPost("register-vendor")]
        public IActionResult RegisterVendor(Vendor model)
        {
            using (SqlConnection con = _db.GetConnection())
            {
                string query = "INSERT INTO Vendors(Name, Email, PasswordHash) VALUES(@Name,@Email,@Password)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@Password", model.PasswordHash);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok("Vendor Registered");
        }
    }
}
