using Carrent.CustomerManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CustomerManagement.Application
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        Customer GetById(Guid id);

        void Add(Customer entity);

        void DeleteById(Guid id);

        void Delete(Customer entity);

        void Update(Customer entity);
    }
}
