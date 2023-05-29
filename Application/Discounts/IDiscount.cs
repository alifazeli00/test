using Application.Context;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Discounts
{
    public interface IDiscount
    {
        bool CreateDis(AddNewDiscountDto Req);
        List<CatalogItemDto> GetCatalogItems(string searchKey,int Add);


    }
    public class Discount : IDiscount
    {
        readonly IDataBaceContext context;
        public Discount(IDataBaceContext context)
        {
            this.context = context;

        }
        public bool CreateDis(AddNewDiscountDto Req)
        {
            try
            {
                
                    var catalogItems = context.CatalogItem.Where(p => Req.appliedToCatalogItem.Contains(p.Id)).ToList();

                    Discountt x = new Discountt()
                {
                    DiscountAmount = Req.DiscountAmount,
                    Name = Req.Name,
                    CouponCode = Req.CouponCode,
                    DiscountLimitationId = Req.DiscountLimitationId,
                    DiscountPercentage = Req.DiscountPercentage,
                    DiscountTypeId = Req.DiscountTypeId,
                    EndDate = Req.EndDate,
                    RequiresCouponCode = Req.RequiresCouponCode,
                    StartDate = Req.StartDate,
                    UsePercentage = Req.UsePercentage,
                    CatalogItems= catalogItems


                    };
                //if (Req.appliedToCatalogItem != null)
                //{
                //    var catalogItems = context.CatalogItem.Where(p => Req.appliedToCatalogItem.Contains(p.Id)).ToList();

                //    foreach (var a in catalogItems)
                //    {

                //        if (x.RequiresCouponCode != true)
                //        {
                //            a.PercentDiscount = x.DiscountAmount;
                //            a.OldPrice = a.Price;

                //            //                        a.Price = (((a.Price) * (x.DiscountAmount)) / 100);
                //            a.Price = (a.Price) - (x.DiscountAmount);


                //            context.SaveChanges();
                //        }
                //        //    x.PercentDiscount = newdiscount.DiscountPercentage;


                //    }

                //    x.CatalogItems = catalogItems;
                //}
                context.Discountt.Add(x);
                context.SaveChanges();

                return true;



            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public List<CatalogItemDto> GetCatalogItems(string searchKey, int Add)
        {
            try
            {

                if (Add == 1)
                {

                    if (!string.IsNullOrEmpty(searchKey))
                    {
                        var res = context.CatalogItem.Where(p => p.Name.Contains(searchKey)).Select(p => new CatalogItemDto
                        {
                            Id = p.Id,
                            Name = p.Name

                        }).ToList();
                        return res;

                    }

                    else
                    {
                        var res = context.CatalogItem.Take(10).OrderByDescending(p => p.Id).Select(p => new CatalogItemDto
                        {
                            Id = p.Id,
                            Name = p.Name

                        }).ToList();
                        return res;

                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(searchKey))
                    {
                        var res = context.CatalogType.Where(p => p.Type.Contains(searchKey)).Select(p => new CatalogItemDto
                        {
                            Id = p.Id,
                            Name = p.Type

                        }).ToList();
                        return res;

                    }

                }
                return new List<CatalogItemDto> { };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    }
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
    public class AddNewDiscountDto
    {
        [Display(Name = "نام تخفیف")]
        public string Name { get; set; }
        [Display(Name = "استفاده از درصد؟")]
        public bool UsePercentage { get; set; } = true;
        [Display(Name = "درصد تخفیف")]
        public int DiscountPercentage { get; set; } = 0;
        [Display(Name = "مبلغ تخفیف")]
        public int DiscountAmount { get; set; } = 0;
        [Display(Name = "زمان شروع")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "زمان انقضا")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "استفاده از کوپن")]
        public bool RequiresCouponCode { get; set; }
        [Display(Name = "کد کوپن")]
        public string CouponCode { get; set; }
        [Display(Name = "نوع تخفیف")]
        public int DiscountTypeId { get; set; }
        [Display(Name = "محدودیت تخفیف")]
        public int DiscountLimitationId { get; set; }

        [Display(Name = "تعداد کد تخفیف")]
        public int LimitationTimes { get; set; } = 0;
        [Display(Name = "اعمال برای محصول")]
        public List<int> appliedToCatalogItem { get; set; }

        // age masan daste badni ro ham bekhai ezf koni baad inja anjam bedi

    }



