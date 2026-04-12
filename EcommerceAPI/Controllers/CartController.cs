using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
