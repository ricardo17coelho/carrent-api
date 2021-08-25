using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Carrent.BaseData.CarClassManagement.Application
{
    public class CarClassService : ICarClassService
    {
        private readonly IRepository<CarClass, Guid> _repository;

        public CarClassService(IRepository<CarClass, Guid> repository)
        {
            _repository = repository;
        }

        public List<CarClass> GetAll()
        {
            return _repository.GetAll();
        }

        public CarClass GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Add(CarClass carClass)
        {
            _repository.Insert(carClass);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public void Delete(CarClass entity)
        {
            _repository.Remove(entity);
        }

        public void Update(CarClass entity)
        {
            _repository.Update(entity);
        }
    }
}
