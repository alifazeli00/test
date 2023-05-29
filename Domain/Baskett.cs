using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Baskett
    {
        public int Id { get; set; }
        public string BuyerId { get;  set; }
        public ICollection<BasketItem> BasketItem { get; set; }
      

        public int DiscountAmount { get;  set; } = 0;
        public Discountt AppliedDiscount { get;  set; }
        public int? AppliedDiscountId { get;  set; }
    }
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get;  set; }
        public int Quantity { get;  set; }
        public int CatalogItemId { get;  set; }
        public CatalogItem CatalogItem { get;  set; }
        public Baskett Baskett { get; set; }
        public int BaskettId { get;  set; }
       
       

        //public void AddQuantity(int quantity)
        //{
        //    Quantity += quantity;
        //}

        //public void SetQuantity(int quantity)
        //{
        //    Quantity = quantity;
        //}
    }
}
