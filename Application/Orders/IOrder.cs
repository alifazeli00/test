using Application.Context;
using Application.Exeptions;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders
{
    public interface IOrder
    {
        int Create(int BasketId, PaymentMethod PaymentMethod); 


    }
    public class Orderr : IOrder
    {
        private readonly IDataBaceContext context;
        public Orderr(IDataBaceContext context)
        {
                this.context = context;
        }
        public int Create(int BasketId, PaymentMethod PaymentMethod)
        {
            // sabad kharid ro zadi chon to onja ke mizae sabt mishe yek  id sabad kharid ro gereft va az onja mishe  item haro find kard
         var basket=context.Baskett.Include(p=>p.BasketItem).ThenInclude(p=>p.CatalogItem).ThenInclude(p=>p.CatalogItemImgs).SingleOrDefault(p=>p.Id==BasketId);
          if(basket==null)
            {
                throw new NotFound(nameof(basket),BasketId);
            }
            try
            {
                var items = basket.BasketItem.Select(p => p.CatalogItem).ToList();
                //foreach(var x in items)
                //{
                //   var orderitems = new OrderItem()
                //    {
                //        CatalogItem = x,
                //        ProductName = x.Name,
                //        UnitPrice = x.Price,
                //        PictureUri = x.CatalogItemImgs.FirstOrDefault().Src,

                //        // soal khob vaghti catalog itms zadi mishe be hame ina dast yaft??
                //    };

                //};
                List<OrderItem> da = new List<OrderItem>();
                foreach (var d in items)
                {
                    var uqn = basket.BasketItem.Where(p => p.CatalogItemId == d.Id).Select(p => p.Quantity).FirstOrDefault();
                    var orderitem = new OrderItem()
                    {
                        CatalogItemId = d.Id,
                        ProductName = d.Name,
                        UnitPrice = d.Price,
                        PictureUri = d.CatalogItemImgs.FirstOrDefault().Src,
                        Units = uqn

                        // soal khob vaghti catalog itms zadi mishe be hame ina dast yaft??
                    };
                    da.Add(orderitem);
                }
                //var os = items.First();
                //var orderitems = basket.BasketItem.Select(x => {
                //    var d = items.First(c => c.Id == x.CatalogItemId);
                //    var orderitem = new OrderItem()
                //    {
                //        CatalogItemId = d.Id,
                //        ProductName = d.Name,
                //        UnitPrice = d.Price,
                //        PictureUri = d.CatalogItemImgs.FirstOrDefault().Src,

                //        // soal khob vaghti catalog itms zadi mishe be hame ina dast yaft??
                //    };
                //    return orderitem;


                //}).ToList();


                Order io = new Order()
                {
                    PaymentMethod = PaymentMethod,
                    OrderDate = DateTime.Now,
                    OrderItem = da,

                };
                context.Order.Add(io);
                context.SaveChanges();
                return io.Id;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
