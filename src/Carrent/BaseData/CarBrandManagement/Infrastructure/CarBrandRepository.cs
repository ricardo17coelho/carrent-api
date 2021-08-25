using Carrent.BaseData.CarBrandManagement.Domain;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrent.BaseData.CarBrandManagement.Infrastructure
{
    public class CarBrandRepository : IRepository<CarBrand, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public CarBrandRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<CarBrand> FindById(Guid id)
        {
            return _carRentDbContext.CarBrands.Where(brand => brand.Id.Equals(id)).ToList();
        }

        public List<CarBrand> GetAll()
        {
            return _carRentDbContext.CarBrands.ToList();
        }

        public void Insert(CarBrand entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(CarBrand entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(CarBrand entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
