using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EcommerceAPI.Controllers
{
    public class OrderController : Controller
    {
        private readonly DbHelper _db;

        public OrderController(DbHelper db)
        {
            _db = db;
        }
        public IActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult PlaceOrder(int customerId)
        {
            using (SqlConnection con = _db.GetConnection())
            {
                con.Open();

                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    // 1. Create Order
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Orders(CustomerId, TotalAmount, Status) OUTPUT INSERTED.OrderId VALUES(@CustomerId,0,'Pending')",
                        con, trans);

                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    int orderId = (int)cmd.ExecuteScalar();

                    // 2. Move Cart → OrderItems
                    SqlCommand cartCmd = new SqlCommand(
                        "SELECT * FROM Cart WHERE CustomerId=@CustomerId",
                        con, trans);

                    cartCmd.Parameters.AddWithValue("@CustomerId", customerId);

                    SqlDataReader reader = cartCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // insert into OrderItems
                    }

                    reader.Close();

                    // 3. Clear Cart
                    SqlCommand clearCart = new SqlCommand(
                        "DELETE FROM Cart WHERE CustomerId=@CustomerId",
                        con, trans);

                    clearCart.Parameters.AddWithValue("@CustomerId", customerId);
                    clearCart.ExecuteNonQuery();

                    trans.Commit();

                    return Ok("Order Placed");
                }
                catch
                {
                    trans.Rollback();
                    return BadRequest("Error");
                }
            }
        }
    }
}
