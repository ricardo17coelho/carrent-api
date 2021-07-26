using Carrent.ZipCodeManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ZipCodeManagement.Application
{
    public interface IZipCodeService
    {
        List<ZipCode> GetAll();
        List<ZipCode> GetById(Guid id);
        void Add(ZipCode entity);
        void DeleteById(Guid id);
        void Delete(ZipCode entity);
        void Update(ZipCode entity);
    }
}
