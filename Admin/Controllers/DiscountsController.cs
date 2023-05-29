using Admin.Binders;
using Application.Discounts;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class DiscountsController : Controller
    {
        private IDiscount discount;
        public DiscountsController(IDiscount discount)
        {

            this.discount = discount;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create([ModelBinder(binderType: typeof(DiscountEntityBinder))] AddNewDiscountDto Req)
        {
            discount.CreateDis(Req);

            return RedirectToAction(nameof(Index));
        }
    }
}
