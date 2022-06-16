using Microsoft.AspNetCore.Mvc;

namespace VIATECH.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
