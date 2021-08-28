using Carrent.Common.Interfaces;
using Carrent.ContractManagement.Domain;
using Carrent.ContractManagement.Infrastructure.Exceptions;
using Carrent.ReservationManagement.Domain;
using Carrent.ReservationManagement.Infrastructure;
using System;
using System.Collections.Generic;


namespace Carrent.ContractManagement.Application
{
    public class ContractService : IContractService
    {
        private readonly IRepository<RentalContract, Guid> _rentalContractRepository;
        private readonly ReservationRepository _reservationRepository;

        public ContractService(IRepository<RentalContract, Guid> rentalContractRepository, ReservationRepository reservationRepository)
        {
            _rentalContractRepository = rentalContractRepository;
            _reservationRepository = reservationRepository;
        }

        public RentalContract Add(RentalContract rentalContract)
        {

            Reservation reservation = _reservationRepository.FindById(rentalContract.ReservationId);
            if (reservation == null || reservation.Status == ReservationStatus.Rent) throw new NotFoundException(); ;
            _rentalContractRepository.Insert(rentalContract);
            _reservationRepository.SetStatusRent(reservation);
            return rentalContract;
        }

        public RentalContract Delete(RentalContract rentalContract)
        {
            _rentalContractRepository.Remove(rentalContract);
            return rentalContract;
        }

        public RentalContract DeleteById(Guid id)
        {
            var ret = GetById(id);
            _rentalContractRepository.Remove(id);
            return ret;
        }

        public List<RentalContract> GetAll()
        {
            return _rentalContractRepository.GetAll();
        }

        public RentalContract GetById(Guid id)
        {
            return _rentalContractRepository.FindById(id);
        }

        public RentalContract Update(RentalContract rentalContract)
        {
            _rentalContractRepository.Update(rentalContract);
            return rentalContract;
        }
    }
}
