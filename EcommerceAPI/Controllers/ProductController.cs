using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


namespace EcommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbHelper _db;

        public ProductController(DbHelper db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            using (SqlConnection con = _db.GetConnection())
            {
                string query = "INSERT INTO Products(VendorId,Name,Price,Stock) VALUES(@VendorId,@Name,@Price,@Stock)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@VendorId", model.VendorId);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Price", model.Price);
                cmd.Parameters.AddWithValue("@Stock", model.Stock);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok("Product Added");
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection con = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        Name = reader["Name"].ToString(),
                        Price = (decimal)reader["Price"],
                        Stock = (int)reader["Stock"]
                    });
                }
            }

            return Ok(list);
        }
    }
}
