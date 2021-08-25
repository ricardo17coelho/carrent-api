using Carrent.ReservationManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ReservationManagement.Application
{
    public interface IReservationService
    {
        List<Reservation> GetAll();

        Reservation GetById(Guid id);

        void Add(Reservation entity);

        void DeleteById(Guid id);

        void Delete(Reservation entity);

        void Update(Reservation entity);
    }
}
