using Microsoft.AspNetCore.Mvc;

namespace Day2_NguyenCongBang.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["numTimes"] = numTimes;
            return View();
        }
    }
}
