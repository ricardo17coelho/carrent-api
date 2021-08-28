using Carrent.ContractManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.ContractManagement.Application
{
    public interface IContractService
    {
        List<RentalContract> GetAll();

        RentalContract GetById(Guid id);

        RentalContract Add(RentalContract rentalContract);

        RentalContract DeleteById(Guid id);

        RentalContract Delete(RentalContract rentalContract);

        RentalContract Update(RentalContract rentalContract);
    }
}
