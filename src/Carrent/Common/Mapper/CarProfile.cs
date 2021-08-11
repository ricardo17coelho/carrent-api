using AutoMapper;
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
            CreateMap<Car, CarResponseDto>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Type))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Class.PricePerDay));

            CreateMap<CarRequestCreateDto, Car>().ForMember(dest => dest.Class, opt => opt.Ignore());

            CreateMap<CarClass, CarClassResponseDto>();

            CreateMap<CarClassRequestEditDto, CarClass>();
            CreateMap<CarClassRequestCreateDto, CarClass>();
        }
    }
}
