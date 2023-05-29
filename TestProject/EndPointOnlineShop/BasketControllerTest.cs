using ApiOnlineShop.Controllers;
using Application;
using Application.Orders;
using Domain;
using Domain.Orders;
using EndPointOnlineShop.Controllers;
using EndPointOnlineShop.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
//using Persistence.Migrations.DataBaceContextIdentityMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using static Application.Basket;
using ControllerContext = Microsoft.AspNetCore.Mvc.ControllerContext;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace TestProject.EndPointOnlineShop
{
    public class BasketControllerTest
    {
        
       

        [Fact]
        public  void  Index_test()
        {
            

            var userManagerMock = new Mock<UserManager<User>>(
                new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            var userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<User>>();

            var identityOptionsMock = new Mock<IOptions<IdentityOptions>>();

            var loggerMock = new Mock<ILogger<CustomSignInManager<User>>>();

            var authenticationSchemeProviderMock = new Mock<IAuthenticationSchemeProvider>();

            var userConfirmationMock = new Mock<IUserConfirmation<User>>();

            var signInManager = new Mock<CustomSignInManager<User>>(
                userManagerMock.Object,
                httpContextAccessorMock.Object,
                userClaimsPrincipalFactoryMock.Object,
                identityOptionsMock.Object,
                loggerMock.Object,
                authenticationSchemeProviderMock.Object,
                userConfirmationMock.Object
            );




















            BasketDto x = new BasketDto()
            {
                BuyerId = "safsdfadsf",
                Id = 1,
                Total = 1,
            };

            User user = new User
            {
                FullName = "ali",
                Id = "1",
                Email = "alirezafazeli173@gmail.com",
                PhoneNumber = "0910123"
            };
            PaymentOfOrderDto a = new PaymentOfOrderDto()
            {
                Amount = 1,
                PaymentId = Guid.NewGuid(),
                PaymentMethod = new PaymentMethod()
            };


            var mock = new Mock<IBasket>();
            mock.Setup(p => p.GetCart("s")).Returns(x);

            var mock2 = new Mock<SignInManager<User>>();
            mock2.Setup(p => p.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(SignInResult.Success);
           mock2.Setup(p => p.SignInAsync(user, true, null));
            //     mock2.Setup(p => p.SignInAsync(user, true,null));
            var mock3 = new Mock<IOrder>();
            mock3.Setup(p => p.Create(1, new PaymentMethod { }));
            var mock4 = new Mock<IPeyment>();
            mock4.Setup(p => p.PayForOrder(1)).Returns(a);
            //            var userManagerMock = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

           var mock5= new Mock<UserManager<User>>();
            //  mock5.Setup(p=>p.)
            var store = new Mock<IUserStore<User>>();
            var mgr = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<User>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<User>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);









































            // mock2.Setup(p => p.SignInAsync(user, true, null));

            var mockUserStore = new Mock<IUserStore<User>>();


          

           
            var clims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.FullName),
                 new Claim(ClaimTypes.NameIdentifier,user.Id),  


            };
            var identitya = new ClaimsIdentity(clims, CookieAuthenticationDefaults.AuthenticationScheme);
           
//            var s= new ClaimsPrincipal { Claims=clims,}

             var identity = new GenericIdentity("some name", "test");
            // s=      signInManager(user,);

            //////    var contextUser = new ClaimsPrincipal(identitya) ; //add claims as needed
            //////    var httpContext = new DefaultHttpContext()
            //////    {
            //////        User = contextUser
            //////};

            //////    var controllerContext = new ControllerContext()
            //////    {
            //////        HttpContext = httpContext,
            //////    };
            BasketController Controller = new BasketController(mock.Object, signInManager.Object, mock3.Object, mock4.Object, mgr.Object)
            {
                ///   ControllerContext = controllerContext,


                userId = "safsdfadsf",
            
               
            };
          
                var res = Controller.Index();

            Assert.NotNull(res);
            Assert.IsType<ViewResult>(res);
            var viewResult = res as ViewResult;
            Assert.IsAssignableFrom<BasketDto>(viewResult.Model);


            //if user==nul>
            BasketDto userlog = new BasketDto()
            {
                BuyerId = "",
                Id = 1,
                Total = 1,
            };

            mock.Setup(p => p.GetCart("s")).Returns(userlog);
            var reslog= Controller.Index();
            Assert.NotNull(reslog);
            Assert.IsType<ViewResult>(reslog);
            var viewResultt = res as ViewResult;
            Assert.IsAssignableFrom<BasketDto>(viewResultt.Model);



        }


    }
    public class CustomSignInManager<User> : SignInManager<User> where User : class
    {
        public CustomSignInManager(
            UserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }

    
}

    