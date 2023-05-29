using Domain.Catalogs;

namespace Domain.Orders
{
    ///// <summary>
    ///// پرداخت انجام شد
    ///// </summary>
    //public void PaymentDone()
    //{
    //    PaymentStatus = PaymentStatus.Paid;
    //}


    ///// <summary>
    ///// کالا تحویل داده شد
    ///// </summary>
    //public void OrderDelivered()
    //{
    //    OrderStatus = OrderStatus.Delivered;
    //}

    ///// <summary>
    ///// ثبت مرجوعی کالا
    ///// </summary>
    //public void OrderReturned()
    //{
    //    OrderStatus = OrderStatus.Returned;
    //}


    ///// <summary>
    ///// لغو سفارش
    ///// </summary>
    //public void OrderCancelled()
    //{
    //    OrderStatus = OrderStatus.Cancelled;
    //}

    //public int TotalPrice()
    //{
    //    int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
    //    if (AppliedDiscount != null)
    //    {
    //        totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
    //    }
    //    return totalPrice;
    //}

    ///// <summary>
    ///// دریافت مبلغ کل بدونه در نظر گرفتن کد تخفیف
    ///// </summary>
    ///// <returns></returns>
    //public int TotalPriceWithOutDiescount()
    //{
    //    int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
    //    return totalPrice;
    //}

    //public void ApplyDiscountCode(Discount discount)
    //{
    //    this.AppliedDiscount = discount;
    //    this.AppliedDiscountId = discount.Id;
    //    this.DiscountAmount = discount.GetDiscountAmount(TotalPrice());
    //}



    // [Auditable]
    public class OrderItem
    {
        public int Id { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get;  set; }
        public string ProductName { get;  set; }
        public string PictureUri { get;  set; }
        public int UnitPrice { get;  set; }
        public int Units { get;  set; }
      
    }
}