using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Carrent.BaseData.CarBrandManagement.Application
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IRepository<CarBrand, Guid> _repository;

        public CarBrandService(IRepository<CarBrand, Guid> repository)
        {
            _repository = repository;
        }
        public void Add(CarBrand carBrand)
        {
            _repository.Insert(carBrand);
        }

        public void Delete(CarBrand carBrand)
        {
            _repository.Remove(carBrand);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public List<CarBrand> GetAll()
        {
            return _repository.GetAll();
        }

        public CarBrand GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Update(CarBrand carBrand)
        {
            _repository.Update(carBrand);
        }
    }
}
