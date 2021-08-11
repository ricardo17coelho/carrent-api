using AutoMapper;
using Carrent.CustomerManagement.Domain;
using Carrent.CustomerManagement.Models;
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
            CreateMap<CustomerRequestCreateDto, Customer>();
            CreateMap<CustomerRequestEditDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
        }
    }
}
