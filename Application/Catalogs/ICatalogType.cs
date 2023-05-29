using Application.Context;
using Application.Dto;
using Application.Exeptions;
using AutoMapper;
using Common;
using Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs
{
    public interface ICatalogType
    {

        BaseDto Create(CatalogTypeDto Req);
        BaseDto Edit(CatalogTypeDto Req);
        BaseDto< CatalogGetType> Get(int? parentId, int page, int pageSize); // inja mishe  page ina daryaf kard chon  az pejineshen estefade kardi
        void Delete(int Id);
        CatalogTypeDto FindById(int Id);
    }

    public class catalogType : ICatalogType
    {
        private readonly IDataBaceContext context;
             private readonly IMapper mapper; 
        public catalogType(IDataBaceContext context, IMapper mapper)
        {

        this.context=   context;
            this.mapper= mapper;
        }
        public BaseDto Create(CatalogTypeDto Req)
        {
            //// if (Req.ParentCatalogTypeId != null || Req.Id != 0)
            // {//
            //    // CatalogType xx = new CatalogType()
            //     {//
            //        // Type = Req.Type,
            //         //P/arentCatalogTypeId = Req.ParentCatalogTypeId,



            //     //};
            //     context.SaveChanges();
            //     context.CatalogType.Add(xx);
            // }
            try
            {
                var model = mapper.Map<CatalogType>(Req);
                context.CatalogType.Add(model);
                context.SaveChanges();
                //CatalogType x = new CatalogType()
                //{
                //    Type = Req.Type,
                //    ParentCatalogTypeId=Req.ParentCatalogTypeId,





                //};
                //context.SaveChanges();
                //context.CatalogType.Add(x);





                var res = context.CatalogType.ToList();
                return new BaseDto() { Masseg = "SabtShode", Statos = true };
            }
            catch (Exception ex)
            {
                return new BaseDto() { Masseg =ex.Message, Statos = false };
            }
        }

        public void Delete(int Id)
        {
        
           var res= context.CatalogType.Find(Id);
            if (res ==null)
            {
                throw new NotFound(nameof(catalogType), Id);
            }
            context.CatalogType.Remove(res);
            context.SaveChanges();

        }

        public BaseDto Edit(CatalogTypeDto Req)
        {
      var res=context.CatalogType.SingleOrDefault(p=>p.Id== Req.Id);
            if (res == null)
            {
                throw new NotFound(nameof(catalogType), Req.Id);
            }
            try
            {
               
                res.ParentCatalogTypeId = Req.ParentCatalogTypeId;
                    res.Type = Req.Type;
                context.SaveChanges();
                return new BaseDto { Masseg = "Sabt Shod" };
            }
            catch  (Exception ex)
            {
             return   new BaseDto { Masseg = ex.Message };
            };


        }

        public CatalogTypeDto FindById(int Id)
        {
            var res = context.CatalogType.Find(Id);
            if(res==null)
            {
                throw new NotFound(nameof(catalogType), Id);
            }
            
        var rees=     new CatalogTypeDto

            {

                Id = res.Id,
                ParentCatalogTypeId = res.ParentCatalogTypeId,
                Type = res.Type

            };
            return rees;



        }

        public BaseDto<CatalogGetType> Get(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            // in ja pagedressult  bas mishe ke  hamshon  namaish pida naknnn yejoraii bas filtering mishe
            var res = context.CatalogType.Where(p => p.ParentCatalogTypeId == parentId).
                PagedResult(page, pageSize, out totalCount).Select(d => new CatalogGetType
                // page result karay tedad ro migirie va filtering ro rosh anjam mide ke masan begim in 3 
                // item  be che sorat namaish bedim hamash  ya yek done ye done

            {

         //       ParentCatalogTypeId = d.ParentCatalogTypeId,
         Id=d.Id,
                Type = d.Type,
                ChildTypeCount = d.Childs.Count()
            }

            ).ToList();


            return  new BaseDto<CatalogGetType>(page, pageSize, totalCount) { Count=totalCount,Data=res,PageSize=pageSize,PageIndex=page };
        }


        //throw new NotImplementedException();
    }
}

    public class CatalogTypeDto
    {

  public int Id { get; set; }  // cheera id dare
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }

    }
 public class CatalogGetType
    {
    public int Id { get; set; }
        public string Type { get; set; }
    //    public int? ParentCatalogTypeId { get; set; }
        public int ChildTypeCount { get; set; }




    }

