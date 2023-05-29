using Application.Context;
using Application.Exeptions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Basket;

namespace Application
{
    public  interface IBasket
    {
        bool Create(int Id, string UserId);
        BasketDto GetCart(string UserId);
        void TransferBasket(string anonymousId,string userId);

    }

    public class Basket : IBasket
    {
        private readonly IDataBaceContext context;
        public Basket(IDataBaceContext context)
        {
            this.context = context;

        }
        //public void FindBasketForUser(UserId)
        //{



        //}


        public bool Create(int Id, string UserId)
        {
            // ya  cookiew made ya z atourize

            try
            {
                var res = context.Baskett.FirstOrDefault(p => p.BuyerId == UserId);

                if (res == null)
                {
                    Baskett x = new Baskett()
                    {

                        BuyerId = UserId,

                    };
                    context.Baskett.Add(x);
                    context.SaveChanges();

                    // inja chon  pain az res estefade mikoin va age khali bod error mide bayad bokoni tosh
                    res = x;
                }
                // yani hala age nall nabod ke hichi khodesh meghdar dare


                int co = 1;
                var cartitem = context.BasketItem.Where(p => p.CatalogItemId == Id && p.BaskettId == res.Id).FirstOrDefault();
                if (cartitem != null)
                {
                    co = cartitem.Quantity++;
                }
                if (cartitem == null)
                {

                    BasketItem x = new BasketItem()
                    {
                        CatalogItemId = Id,
                        BaskettId = res.Id,
                        Quantity = co

                    };
                    context.BasketItem.Add(x);
                }
                context.SaveChanges();


                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public BasketDto GetCart(string UserId)
        {
           

            var basket = context.Baskett.FirstOrDefault(p => p.BuyerId == UserId);
            if (basket == null)
            {

                throw new NotFound(nameof(basket), UserId);
            }
            try
            {
                if (basket != null)
                {
                    var ss = context.BasketItem.ToList();
                    var res = context.BasketItem.Where(p => p.BaskettId == basket.Id).Select(p => new GETCartDto()
                    {
                        Id = p.Id,
                        Quantity = p.Quantity,
                        Description = p.CatalogItem.Description,
                        images = "https://localhost:44321/" + p.CatalogItem.CatalogItemImgs.FirstOrDefault().Src,
                        Price = p.CatalogItem.Price,
                        Name = p.CatalogItem.Name,

                        //Count=+1,
                        // Total = p.CatalogItem.Price



                    }).ToList();
                    int Totall = 0;
                    foreach (var x in res)
                    {
                        if (x.Quantity == 0)

                        {
                            Totall += x.Price;
                        }
                        else

                        {
                            Totall += x.Price * x.Quantity;
                        }
                        x.Total += x.Price;
                        x.Count = res.Count;

                    }

                    return new BasketDto { Ites = res, BuyerId = basket.BuyerId, Id = basket.Id, Total = Totall };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (basket == null)
            {
                return null;
            }

            else
            {
                return null;
            }

        }

        public void TransferBasket(string anonymousId, string userId)
        {

            var anonymousBasket = context.Baskett
               .Include(p => p.BasketItem).ThenInclude(p => p.CatalogItem)
               .Include(p => p.AppliedDiscount)
               .SingleOrDefault(p => p.BuyerId == anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = context.Baskett.SingleOrDefault(p => p.BuyerId == userId);
            if (userBasket == null)
            {

                Baskett x = new Baskett()
                {
                    BuyerId = userId
                };


                //       userBasket = new Basket(userId);
                context.Baskett.Add(x);
                userBasket = x;
                context.SaveChanges();
            }
            foreach (var item in anonymousBasket.BasketItem)
            {
                BasketItem y = new BasketItem()
                {
                    BaskettId = userBasket.Id,
                    CatalogItemId = item.CatalogItemId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,

                };
                context.BasketItem.Add(y);


                // userBasket.AddItem(item.CatalogItemId, item.Quantity, item.UnitPrice);
            }

            //if (anonymousBasket.AppliedDiscount != null)
            //{
            //    userBasket.ApplyDiscountCode(anonymousBasket.AppliedDiscount);
            //}

            context.Baskett.Remove(anonymousBasket);
            context.SaveChanges();








        }

        public class GETCartDto
        {
            public int Id { get; set; } 
            public  int Quantity    { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string images { get; set; }
            public int Price { get; set; }
            public int Count { get; set; }
            public int Total { get; set; } = 0;

        }
        public class BasketDto
        {
            public int Id { get; set; }
            public string BuyerId { get; set; }
            public int Total { get; set; } = 0;
          public  List<GETCartDto> Ites { get; set; }= new List<GETCartDto>();


        }
    }
}
