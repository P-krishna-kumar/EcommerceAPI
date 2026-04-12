using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
