using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ReservationManagement.Infrastructure
{
    public class ReservationRepository : IRepository<Reservation, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public ReservationRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<Reservation> GetAll()
        {
            return _carRentDbContext.Reservations.Include(x => x.Car).ThenInclude(c => c.Class).Include(x => x.Customer).ToList();
        }

        public Reservation FindById(Guid id)
        {
            return _carRentDbContext.Reservations
                .Include(x => x.Car)
                .Include(x => x.Customer).Where(x => x.Id.Equals(id))
                .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Reservation entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(Reservation entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id));
        }

        public void Remove(Reservation entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }

        public void SetState(Reservation reservation, ReservationStatus status)
        {
            if (reservation.Status == ReservationStatus.Rent) return;
            reservation.Status = status;
            Update(reservation);
        }

        public void SetStatusRent(Reservation reservation)
        {
            ReservationStatus status = ReservationStatus.Rent;
            SetState(reservation, status);
        }

        public void SetStatusReserved(Reservation reservation)
        {
            ReservationStatus status = ReservationStatus.Reserved;
            SetState(reservation, status);
        }
    }
}
