using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
