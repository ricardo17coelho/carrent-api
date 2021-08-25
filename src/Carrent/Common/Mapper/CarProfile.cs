using AutoMapper;
using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.BaseData.CarBrandManagement.Models;
using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.BaseData.CarTypeManagement.Models;
using Carrent.CarManagement.Api;
using Carrent.CarManagement.Domain;
using System.Linq;

namespace Carrent.Common.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarResponseDto>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Type))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Reservations.OrderBy(r => r.Id).FirstOrDefault().Status))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Class.PricePerDay));

            CreateMap<CarRequestCreateDto, Car>().ForMember(dest => dest.Class, opt => opt.Ignore());

            //CarClass
            CreateMap<CarClass, CarClassResponseDto>();
            CreateMap<CarClassRequestEditDto, CarClass>().ForMember(dest => dest.Type, opt => opt.Ignore());
            CreateMap<CarClassRequestCreateDto, CarClass>();

            //CarBrand
            CreateMap<CarBrand, CarBrandResponseDto>();
            CreateMap<CarBrandRequestEditDto, CarBrand>();
            CreateMap<CarBrandRequestCreateDto, CarBrand>();

            //CarType
            CreateMap<CarType, CarTypeResponseDto>();
            CreateMap<CarTypeRequestEditDto, CarType>();
            CreateMap<CarTypeRequestCreateDto, CarType>();
        }
    }
}
