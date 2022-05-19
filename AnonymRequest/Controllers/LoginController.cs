using Microsoft.AspNetCore.Mvc;

namespace AnonymRequest.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
