using Carrent.BaseData.CarClassManagement.Domain;
using System;
using System.Collections.Generic;

namespace Carrent.BaseData.CarClassManagement.Application
{
    public interface ICarClassService
    {
        List<CarClass> GetAll();

        CarClass GetById(Guid id);

        void Add(CarClass carClass);

        void DeleteById(Guid id);

        void Delete(CarClass carClass);

        void Update(CarClass carClass);

    }
}
