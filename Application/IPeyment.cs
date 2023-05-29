using Application.Context;
using Application.Exeptions;
using Domain;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    //inja be identiti ham niaz chin   be user ham niaz daty 
    public interface IPeyment
    {
        PaymentOfOrderDto PayForOrder(int OrderId);
    }
    public class Peymentt: IPeyment
    {
        //private readonly IDataBaceContextIdentity identiti;
        private readonly IDataBaceContext context;
        public Peymentt(IDataBaceContext context)

        {

           this.context = context; 

        }

        public PaymentOfOrderDto PayForOrder(int OrderId)
        {
            var order= context.Order.Include(p=>p.OrderItem).Where(p=>p.Id == OrderId).SingleOrDefault();
        if(order==null)
            {
                throw new NotFound(nameof(Order), OrderId);
            };
            try
            {
                var peyment = context.Peyment.SingleOrDefault(sp => sp.OrderId == OrderId);
                int amo = 0;
                foreach (var x in order.OrderItem)
                {
                    amo += x.UnitPrice * x.Units;

                }


                if (peyment == null)
                {

                    peyment = new Peyment()
                    {
                        OrderId = order.Id,
                        Amount = amo
                    };
                    context.Peyment.Add(peyment);
                    context.SaveChanges();

                }
                return new PaymentOfOrderDto
                {
                    Amount = peyment.Amount,
                    PaymentId = peyment.Id,
                    PaymentMethod = order.PaymentMethod
                };
            }
            catch (Exception ex)

            {

              throw ex; 
            };

        }


        }

        public class PaymentOfOrderDto
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }


    public class PaymentDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public string Userid { get; set; }
    }
}
