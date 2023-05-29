using Application;
using Domain;
using EndPointOnlineShop.Models.VIewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EndPointOnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User>   userManager ;
        private readonly IBasket basket;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IBasket basket)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.basket = basket;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Rejester()
        {

            return View();

        }

        [HttpPost]
        public IActionResult Rejester(RejesterViewModel Req)
        {
            if(!ModelState.IsValid)
            {
                return View(Req);   
            }
            User x = new User()
            {
                Email = Req.Email,
                PhoneNumber = Req.PhoneNumber,
                UserName = Req.Email,
                FullName = Req.FullName,
             
                
            };

            var res = userManager.CreateAsync(x,Req.Password).Result;
            if(res.Succeeded==true)
            {
                var user = userManager.FindByNameAsync(x.Email).Result;
                string cookieName = "BasketId";
                if (Request.Cookies.ContainsKey(cookieName))
                {


                    var anonymousId = Request.Cookies[cookieName];
                    basket.TransferBasket(anonymousId, user.Id);
                    Response.Cookies.Delete(cookieName);
                }


                signInManager.SignInAsync(user, true);

               
                return RedirectToAction(nameof(Login));



            }
            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
        


            TempData["mess"] = errors;
            string mes = "";
            foreach (var xx in res.Errors)
            {
                mes += xx.Description + Environment.NewLine;
            }
            TempData["mes"] = mes;
            return View();







        }


        public IActionResult Login(string uri="/")
        {

           
            LoginVewModel x = new LoginVewModel()
            {
                ReturnUrl = uri,
            };

            return View(x);
        }

        [HttpPost]
        public IActionResult Login(LoginVewModel Req)
        
        
        {
            if(!ModelState.IsValid)
            {

                return View (Req ); 
            }

            var User = userManager.FindByNameAsync(Req.Email).Result;

         //   signInManager.SignOutAsync();
            if (User==null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(Req);
     
            }
            signInManager.SignOutAsync();
            var res=  signInManager.PasswordSignInAsync(User, Req.Password,Req.IsPersistent,true).Result;

            if(res.Succeeded==true)
            {
                string cookieName = "BasketId";
                if (Request.Cookies.ContainsKey(cookieName))
                {


                    var anonymousId = Request.Cookies[cookieName];
                    basket.TransferBasket(anonymousId, User.Id);
                    Response.Cookies.Delete(cookieName);
                }


                return Redirect(Req.ReturnUrl ??"/" );
            }
            var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
            TempData["mes"] = errors;
            return View(Req);
        }

        public    void logout()
        {
            signInManager.SignOutAsync();


        }

    }
}
