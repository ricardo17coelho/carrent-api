using Carrent.BaseData.CarTypeManagement.Domain;
using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.BaseData.CarTypeManagement.Infrastructure
{
    public class CarTypeRepository : IRepository<CarType, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public CarTypeRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public CarType FindById(Guid id)
        {
            return _carRentDbContext.CarTypes.Where(brand => brand.Id.Equals(id)).FirstOrDefault(c => c.Id == id);
        }

        public List<CarType> GetAll()
        {
            return _carRentDbContext.CarTypes.ToList();
        }

        public void Insert(CarType entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id));
        }

        public void Remove(CarType entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(CarType entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
