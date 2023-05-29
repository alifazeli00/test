using Application;
using Application.Orders;
using Domain;
using Domain.Orders;
using EndPointOnlineShop.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using static Application.Basket;

namespace EndPointOnlineShop.Controllers
{
    public class BasketController : Controller
    {
        private readonly IDistributedCache cache;
        private readonly SignInManager<User> signInManager;
         public string  userId=null;
        private readonly IBasket Basket;
        private readonly IOrder Orderr;
        private readonly IPeyment Peyment;
        private readonly UserManager<User> Usermanger;
        public BasketController(IBasket Basket, SignInManager<User> signInManager, IOrder Orderr, IPeyment Peyment/*, IDistributedCache cache*/, UserManager<User> Usermanger)
        {
            this.Peyment = Peyment;
         //  this.cache=cache; 
            this.Basket= Basket;
            this.Orderr = Orderr;
          this.signInManager= signInManager;
            this.Usermanger = Usermanger;
        }

      
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
             var res=   Basket.GetCart(userId);

                return View(res);
            }
                 string basketCookieName = "BasketId";
            //  string basketCookieName = new Guid().ToString();
            if (userId == null)
            {
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    userId = Request.Cookies[basketCookieName];

                    var res = Basket.GetCart(userId);

                    return View(res);
                }
            }
            if(userId!=null)
            {
                var res = Basket.GetCart(userId);

                return View(res);
            }

            //else

            //{

            //    userId = Guid.NewGuid().ToString();

            //    var cookieOptions = new CookieOptions { IsEssential = true };
            //    cookieOptions.Expires = DateTime.Today.AddYears(2);
            //    Response.Cookies.Append(basketCookieName, userId, cookieOptions);

            //    string getCookieValue = Request.Cookies[basketCookieName];
            //  //  Basket.Create(Id, userId);
            //}
            return View();
        }

        public void Create(int Id)
        {
            if (signInManager.IsSignedIn(User))
            {
                userId = ClaimUtility.GetUserId(User);
                Basket.Create(Id, userId);
                //     BasketServices.CreatBasket(userId, Id);
                //TempData["m"] = s.ToString();
            }
            else
            {
                // SetCookiesForBasket();
                //   BasketServices.CreatBasket(userId, CatalogItemId, quantity);

                // TempData["m"] = s.ToString();
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    userId = Request.Cookies[basketCookieName];

                }
                if (userId != null)
                {



                    Basket.Create(Id, userId);
                }
                if (userId == null)
                {

                    userId = Guid.NewGuid().ToString();

                    var cookieOptions = new CookieOptions { IsEssential = true };
                    cookieOptions.Expires = DateTime.Today.AddYears(2);
                    Response.Cookies.Append(basketCookieName, userId, cookieOptions);

                    string getCookieValue = Request.Cookies[basketCookieName];
                    Basket.Create(Id, userId);

                }








            }






        }

        [Authorize]
      public IActionResult ShippingPayment()
        {

            BasketDto x = new BasketDto();

            string userid = ClaimUtility.GetUserId(User);
            x= Basket.GetCart(userid);



            return View(x);
        }
        [Authorize]
        [HttpPost]

        public IActionResult ShippingPayment(PaymentMethod PaymentMethod)
        {

            string userid = ClaimUtility.GetUserId(User);
            var baskt= Basket.GetCart(userid);
            int order = Orderr.Create(baskt.Id, PaymentMethod);

            var ress= Peyment.PayForOrder(order);





            return View();
        }



    }
}
