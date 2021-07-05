﻿using AutoMapper;
using Carrent.CarManagement.Api;
using Carrent.CarManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Type))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Class.PricePerDay));

            CreateMap<CarDto, Car>().ForMember(dest => dest.Class, opt => opt.Ignore());

            CreateMap<CarClass, CarClassDto>();

            CreateMap<CarClassDto, CarClass>();
        }
    }
}
