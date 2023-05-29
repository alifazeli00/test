using Application.Orders;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Builders;
using Xunit;

namespace TestProject.Application
{
     
    public class OrderService
    {
     [Fact]
      public void create()
      {




            var datbacebuilder = new DataBaceContextBuilder();
            var dbcontext = datbacebuilder.GetdbContext();

            var service = new Orderr(dbcontext);
            var res = service.Create(1, PaymentMethod.OnlinePaymnt);

            Assert.IsType<int>(res);
       


        }


    }
}
