using Application;
using Domain;
using EndPointOnlineShop.Models;
using EndPointOnlineShop.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPointOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
    //    private readonly SignInManager<User> signInManager;
      //  private string userId = null;
        private readonly IBasket Basket;

      
        public HomeController(ILogger<HomeController> logger, IBasket Basket)
        {
            //this.Basket = Basket;
           ///is.signInManager = signInManager;
            _logger = logger; ;
        }

        public IActionResult Index()
        {
            //if (signInManager.IsSignedIn(User))
            //{
            //    userId = ClaimUtility.GetUserId(User);
            //    //     BasketServices.CreatBasket(userId, Id);
            //    //TempData["m"] = s.ToString();
            //}
            //else
            //{
            //    // SetCookiesForBasket();
            //    //   BasketServices.CreatBasket(userId, CatalogItemId, quantity);

            //    // TempData["m"] = s.ToString();
            //    string basketCookieName = "BasketId";
            //    if (Request.Cookies.ContainsKey(basketCookieName))
            //    {
            //        userId = Request.Cookies[basketCookieName];
            //    }
            //    if (userId != null)
            //    {



            //    var res=    Basket.GetCart( userId);
            //        return View(res);
            //    }
            //    if (userId == null)
            //    {

            //        userId = Guid.NewGuid().ToString();

            //        var cookieOptions = new CookieOptions { IsEssential = true };
            //        cookieOptions.Expires = DateTime.Today.AddYears(2);
            //        Response.Cookies.Append(basketCookieName, userId, cookieOptions);

            //        string getCookieValue = Request.Cookies[basketCookieName];
            //        var res = Basket.GetCart(userId);
            //        return View(res);
            //    }







            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
