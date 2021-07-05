using Carrent.CarManagement.Domain;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _carRentDbContext.Cars.Include(x => x.Class).ToList();
        }

        public List<Car> FindById(Guid id)
        {
            return _carRentDbContext.Cars.Include(x => x.Class).Where(x => x.Id.Equals(id)).ToList();
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
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(Car entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
