//using Application;
//using Domain;
//using EndPointOnlineShop.Models.VIewModel;
//using Microsoft.AspNetCore.Identity;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject.EndPointOnlineShop
//{
//    public class AccountControllerTest
//    {
//        public void    Rejester_Test()
//        {
//            RejesterViewModel y = new RejesterViewModel()
//            {
//                Password = "aa",
//                FullName = "a"
//            };

//            User x = new User()
//            {
//                FullName = "a", Email = "s"
//            };

//            var mock1 = new Mock<SignInManager<User>>();
//            var mock2 = new Mock<UserManager<User>>();
//            var mock3= new Mock<IBasket>();
//            mock2.Setup(p => p.CreateAsync(x,y.Password)).Returns();


//        }


//    }
//}
