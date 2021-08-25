using Carrent.CarManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Application
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(Guid id);
        List<Car> GetByType(string type);
        void Add(Car car);
        void DeleteById(Guid id);
        void Delete(Car car);
        void Update(Car car);
    }
}
