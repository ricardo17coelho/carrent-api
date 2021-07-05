using Carrent.CarManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Application
{
    public interface ICarClassService
    {
        List<CarClass> GetAll();

        List<CarClass> GetById(Guid id);

        void Add(CarClass car);

        void DeleteById(Guid id);

        void Delete(CarClass car);

        void Update(CarClass car);

    }
}
