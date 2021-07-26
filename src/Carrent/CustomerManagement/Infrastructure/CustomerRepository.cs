using Carrent.Common.Context;
using Carrent.Common.Interfaces;
using Carrent.CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CustomerManagement.Infrastructure
{
    public class CustomerRepository : IRepository<Customer, Guid>
    {
        private readonly CarRentDbContext _carRentDbContext;

        public CustomerRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<Customer> GetAll()
        {
            return _carRentDbContext.Customers.Include(x => x.Zip).ToList();
        }

        public List<Customer> FindById(Guid id)
        {
            return _carRentDbContext.Customers.Include(x => x.Zip).Where(x => x.Id.Equals(id)).ToList();
        }

        public void Insert(Customer entity)
        {
            _carRentDbContext.Add(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Remove(FindById(id).FirstOrDefault());
        }

        public void Remove(Customer entity)
        {
            _carRentDbContext.Remove(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
