using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Common.Interfaces
{
    public interface IRepository<T, in TI>
    {
        List<T> GetAll();
        T FindById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(Guid id);
        void Remove(T entity);
    }
}
