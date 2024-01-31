using Microsoft.AspNetCore.Mvc;

namespace Mongodb.Models
{
    public class Status : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
