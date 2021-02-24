using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Services.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        long Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
