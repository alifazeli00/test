using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
   

    public class SupportCHatController : Controller
    {
  
        public IActionResult Index()
        {
            return View();
        }
    }
}
