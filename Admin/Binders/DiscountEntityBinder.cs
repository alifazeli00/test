using Application.Discounts;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string FieldName = bindingContext.FieldName;



            var DiscountLimitationIc = int.Parse(bindingContext.ValueProvider
            .GetValue("DiscountLimitationId").Values.ToString());
            var Start = MD.PersianDateTime.Standard.PersianDateTime.Parse(bindingContext.ValueProvider
              .GetValue("StartDate").Values);

            var DiscountAmount = int.Parse(bindingContext.ValueProvider
            .GetValue("DiscountAmount").Values.ToString());

         //   var DiscountPercentage = bindingContext.ValueProvider
       //   .GetValue("DiscountPercentage").Values.ToString();

            var DiscountTypeId = int.Parse(bindingContext.ValueProvider
          .GetValue("DiscountTypeId").Values.ToString());

            var LimitationTimes =int.Parse( bindingContext.ValueProvider
          .GetValue("LimitationTimes").Values.ToString());


            var UsePercentage =bool.Parse( bindingContext.ValueProvider
          .GetValue("UsePercentage").FirstValue.ToString());


            var DiscountPercentage = int.Parse(bindingContext.ValueProvider
        .GetValue("DiscountLimitationId").Values.ToString());

            var RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
          .GetValue("RequiresCouponCode").FirstValue.ToString());

            



            var End = MD.PersianDateTime.Standard.PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue("EndDate").Values);



            var CouponCode = bindingContext.ValueProvider
        .GetValue("CouponCode").Values.ToString();


            var Name = bindingContext.ValueProvider
     .GetValue("Name").Values.ToString();
            AddNewDiscountDto discountDto = new AddNewDiscountDto()
            {
                DiscountAmount = DiscountAmount,
                DiscountLimitationId = DiscountLimitationIc,
                DiscountPercentage = DiscountPercentage,
                DiscountTypeId = DiscountTypeId,
                StartDate = Start,
                EndDate = End,
                CouponCode = CouponCode,
                Name = Name,
                LimitationTimes = LimitationTimes,
                UsePercentage = UsePercentage,
                RequiresCouponCode = RequiresCouponCode,
            };



            //AddNewDiscountDto discountDto = new AddNewDiscountDto()
            //{
            //    CouponCode = bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.CouponCode)}").Values.ToString(),
            //    DiscountAmount = int.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.DiscountAmount)}").Values.ToString()),
            //    DiscountLimitationId = int.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),
            // DiscountPercentage = int.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.DiscountLimitationId)}").Values.ToString()),

            //    DiscountTypeId = int.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.DiscountTypeId)}").Values.ToString()),
            //    LimitationTimes = int.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.LimitationTimes)}").Values.ToString()),
            //    UsePercentage = bool.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.UsePercentage)}").FirstValue.ToString()),

            //    Name = bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.Name)}").Values.ToString(),

            //    RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.RequiresCouponCode)}").FirstValue.ToString()),

            //    EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.EndDate)}").Values.ToString()),

            //    StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
            //    .GetValue($"{FieldName}.{nameof(discountDto.StartDate)}").Values.ToString()),
            //};


            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("appliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                //discountDto.appliedToCatalogItem =
                //bindingContext.ValueProvider
                //.GetValue($"{FieldName}.{nameof(discountDto.appliedToCatalogItem)}")


             discountDto.appliedToCatalogItem = bindingContext.ValueProvider
        .GetValue("appliedToCatalogItem").Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }


            bindingContext.Result = ModelBindingResult.Success(discountDto);
            return Task.CompletedTask;












        }
    }
}
