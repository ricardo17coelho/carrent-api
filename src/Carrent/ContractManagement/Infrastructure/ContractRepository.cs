using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.ContractManagement.Domain;
using Carrent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrent.ContractManagement.Infrastructure
{
    public class ContractRepository : IRepository<RentalContract, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public ContractRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<RentalContract> GetAll()
        {
            return _carRentDbContext.RentalContracts
                .Include(contract => contract.Reservation)
                .ThenInclude(reservation => reservation.Car.Brand)
                .Include(contract => contract.Reservation)
                .ThenInclude(reservation => reservation.Customer)
                .ToList();
        }

        public RentalContract FindById(Guid id)
        {
            return _carRentDbContext.RentalContracts
                .Include(contract => contract.Reservation)
                .ThenInclude(reservation => reservation.Car.Brand)
                .Where(reservation => reservation.Id.Equals(id))
                .Include(contract => contract.Reservation)
                .ThenInclude(reservation => reservation.Customer)
                .Where(reservation => reservation.Id.Equals(id))
                .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(RentalContract rentalContract)
        {
            _carRentDbContext.Add(rentalContract);
            _carRentDbContext.SaveChanges();
        }

        public void Update(RentalContract rentalContract)
        {
            _carRentDbContext.Update(rentalContract);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id));
        }

        public void Remove(RentalContract rentalContract)
        {
            _carRentDbContext.Remove(rentalContract);
            _carRentDbContext.SaveChanges();
        }
    }
}
