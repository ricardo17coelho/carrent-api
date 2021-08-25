using Carrent.BaseData.CarClassManagement.Domain;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrent.BaseData.CarClassManagement.Infrastructure
{
    public class CarClassRepository : IRepository<CarClass, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public CarClassRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<CarClass> GetAll()
        {
            return _carRentDbContext.CarClasses.ToList();
        }

        public List<CarClass> FindById(Guid id)
        {
            return _carRentDbContext.CarClasses.Where(x => x.Id.Equals(id)).ToList();
        }

        public void Insert(CarClass entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(CarClass entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(CarClass entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
