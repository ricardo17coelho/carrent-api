using Carrent.CarManagement.Domain;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrent.CarManagement.Infrastructure
{
    public class CarRepository : IRepository<Car, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public CarRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<Car> GetAll()
        {
            return _carRentDbContext.Cars.Include(car => car.Reservations)
                .Include(x => x.Class)
                .Include(car => car.Brand)
                .Include(car => car.Type)
                .ToList();
        }

        public Car FindById(Guid id)
        {
            return _carRentDbContext.Cars
                .Include(car => car.Class).Where(carClass => carClass.Id.Equals(id))
                .Include(car => car.BrandId).Where(brand => brand.Id.Equals(id))
                .Include(car => car.TypeId).Where(type => type.Id.Equals(id))
                .FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Car entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(Car entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id));
        }

        public void Remove(Car entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
