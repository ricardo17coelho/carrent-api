using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.BaseData.CarTypesManagement.Application
{
    public class CarTypeService : ICarTypeService
    {
        private readonly IRepository<CarType, Guid> _repository;

        public CarTypeService(IRepository<CarType, Guid> repository)
        {
            _repository = repository;
        }
        public void Add(CarType carType)
        {
            _repository.Insert(carType);
        }

        public void Delete(CarType carType)
        {
            _repository.Remove(carType);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public List<CarType> GetAll()
        {
            return _repository.GetAll();
        }

        public List<CarType> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Update(CarType carType)
        {
            _repository.Update(carType);
        }
    }
}
