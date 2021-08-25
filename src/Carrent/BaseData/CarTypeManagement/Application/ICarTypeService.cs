using Carrent.BaseData.CarTypeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.BaseData.CarTypesManagement.Application
{
    public interface ICarTypeService
    {
        List<CarType> GetAll();
        List<CarType> GetById(Guid id);
        void Add(CarType carType);
        void DeleteById(Guid id);
        void Delete(CarType carType);
        void Update(CarType carType);
    }
}
