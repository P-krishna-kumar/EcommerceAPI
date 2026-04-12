using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    public class VendorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
