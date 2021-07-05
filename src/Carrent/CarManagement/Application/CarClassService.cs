using Carrent.CarManagement.Domain;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagement.Application
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

        public List<CarClass> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Add(CarClass entity)
        {
            _repository.Insert(entity);
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
