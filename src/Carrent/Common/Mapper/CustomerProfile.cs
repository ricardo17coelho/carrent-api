using AutoMapper;
using Carrent.CustomerManagement.Domain;
using Carrent.CustomerManagement.Models;
using Carrent.ZipCodeManagement.Domain;
using Carrent.ZipCodeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponseDto>()
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip.Zip))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Zip.Country))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Zip.Town));
            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.Zip, opt => opt.Ignore());

            CreateMap<ZipCode, ZipCodeDto>();
            CreateMap<ZipCodeDto, ZipCode>();
        }
    }
}
