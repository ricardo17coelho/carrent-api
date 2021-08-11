using Carrent.Common.Interfaces;
using Carrent.ReservationManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ReservationManagement.Application
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation, Guid> _repository;

        public ReservationService(IRepository<Reservation, Guid> repository)
        {
            _repository = repository;
        }

        public List<Reservation> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Reservation> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Add(Reservation entity)
        {
            _repository.Insert(entity);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public void Delete(Reservation entity)
        {
            _repository.Remove(entity);
        }

        public void Update(Reservation entity)
        {
            _repository.Update(entity);
        }
    }
}
