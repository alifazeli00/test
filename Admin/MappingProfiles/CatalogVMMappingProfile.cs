﻿//using Admin.EndPoint.ViewModels.Catalogs;
using Admin.Models.ViewModel;
using Application.Catalogs;
//using Application.Catalogs.CatalogTypes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
            CreateMap<CatalogTypeDto, catalogType>().ReverseMap();
        }

    }
}