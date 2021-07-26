using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.ZipCodeManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ZipCodeManagement.Infrastructure
{
    public class ZipCodeRepository : IRepository<ZipCode, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public ZipCodeRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<ZipCode> GetAll()
        {
            return _carRentDbContext.ZipCodes.ToList();
        }

        public List<ZipCode> FindById(Guid id)
        {
            return _carRentDbContext.ZipCodes.Where(x => x.Id.Equals(id)).ToList();
        }

        public void Insert(ZipCode entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(ZipCode entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(ZipCode entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
