using AutoMapper;
using Carrent.ReservationManagement.Domain;
using Carrent.ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Mapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationResponseDto>()
                //.ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car.BrandId + ' ' + src.Car.Class.Type))
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.Firstname + ' ' + src.Customer.Lastname))
                .AfterMap((src, dest) => {
                    var PricePerDay = src.Car.Class.PricePerDay;
                    //var PricePerDay = 10;
                    dest.TotalCost = src.TotalDays * PricePerDay;
                });

            CreateMap<ReservationRequestCreateDto, Reservation>()
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore());
        }
    }
}
