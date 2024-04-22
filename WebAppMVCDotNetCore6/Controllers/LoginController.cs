using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCDotNetCore6.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
