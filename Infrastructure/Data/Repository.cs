using ApplicationCore.Entities;
using ApplicationCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly RockstarsContext dbContext;

        public Repository(RockstarsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual T GetById(long id)
        {
            return dbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking().AsEnumerable();
        }

        public long Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
