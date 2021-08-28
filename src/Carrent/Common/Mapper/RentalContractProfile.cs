using AutoMapper;
using Carrent.ContractManagement.Domain;
using Carrent.ContractManagement.Models;


namespace Carrent.Common.Mapper
{
    public class RentalContractProfile : Profile
    {
        public RentalContractProfile()
        {
            CreateMap<RentalContract, RentalContractResponseDto>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Reservation.Car.Brand.Title + ' ' + src.Reservation.Car.Model))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Reservation.Start))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Reservation.End))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Reservation.Customer.Firstname + ' ' + src.Reservation.Customer.Lastname));

            CreateMap<RentalContractRequestCreateDto, RentalContract>();
        }
    }
}
