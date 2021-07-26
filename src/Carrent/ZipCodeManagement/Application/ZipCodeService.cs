using Carrent.Common.Interfaces;
using Carrent.ZipCodeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ZipCodeManagement.Application
{
    public class ZipCodeService : IZipCodeService
    {
        private readonly IRepository<ZipCode, Guid> _repository;

        public ZipCodeService(IRepository<ZipCode, Guid> repository)
        {
            _repository = repository;
        }

        public List<ZipCode> GetAll()
        {
            return _repository.GetAll();
        }

        public List<ZipCode> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Add(ZipCode entity)
        {
            _repository.Insert(entity);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public void Delete(ZipCode entity)
        {
            _repository.Remove(entity);
        }

        public void Update(ZipCode entity)
        {
            _repository.Update(entity);
        }
    }
}
