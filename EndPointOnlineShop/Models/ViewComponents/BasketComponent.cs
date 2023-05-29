using Application;
using EndPointOnlineShop.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using static Application.Basket;

namespace EndPointOnlineShop.Models.ViewComponents
{
    public class BasketComponent:ViewComponent
    {
        private readonly IBasket Basket;
        public BasketComponent(IBasket Basket)
        {

           this.Basket = Basket;
             
        }
        private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = Basket.GetCart(ClaimUtility.GetUserId(userClaimsPrincipal));

            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket = Basket.GetCart(buyerId);
                }

            }
            return View(viewName: "BasketComponent", model: basket);
        }

    }
}
