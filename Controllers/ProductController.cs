using Microsoft.AspNetCore.Mvc;

namespace Entertainment_Guild.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
