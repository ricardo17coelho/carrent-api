using Carrent.BaseData.CarBrandManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.BaseData.CarBrandManagement.Application
{
    public interface ICarBrandService
    {
        List<CarBrand> GetAll();
        List<CarBrand> GetById(Guid id);
        void Add(CarBrand carBrand);
        void DeleteById(Guid id);
        void Delete(CarBrand carBrand);
        void Update(CarBrand carBrand);
    }
}
