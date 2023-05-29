using Application.Visitor;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class VisitorController : Controller
    {
        private readonly IRports Rep;
        public VisitorController(IRports Rep)
        {
            this.Rep = Rep;

        }
        public IActionResult Index()
        {
          
            return View(Rep.Execute());
        }
    }
}
