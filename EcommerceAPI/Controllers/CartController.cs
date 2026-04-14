using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EcommerceAPI.Controllers
{
    public class CartController : Controller
    {
        private readonly DbHelper _db;

        public CartController(DbHelper db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(Cart model)
        {
            using (SqlConnection con = _db.GetConnection())
            {
                string query = "INSERT INTO Cart(CustomerId,ProductId,Quantity) VALUES(@CustomerId,@ProductId,@Quantity)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CustomerId", model.CustomerId);
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok("Added to cart");
        }
    }
}
