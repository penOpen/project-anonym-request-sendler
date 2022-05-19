using Microsoft.AspNetCore.Mvc;

namespace AnonymRequest.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
