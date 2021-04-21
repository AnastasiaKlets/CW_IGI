using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL
{
     public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationContext _applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<T> Create(T entity)
        {
            await _applicationContext.Set<T>().AddAsync(entity);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            //_applicationContext.Entry<T>(entity).State = EntityState.Detached;
            var c = _applicationContext.SaveChangesAsync().Result;
            _applicationContext.Set<T>().Remove(entity);
            c = _applicationContext.SaveChangesAsync().Result;
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            return await _applicationContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> Read()
        {
            return _applicationContext.Set<T>();
        }

        public async Task<T> Update(T entity)
        {
             _applicationContext.Set<T>().Update(entity);
            await _applicationContext.SaveChangesAsync();
            return entity;
        }
    }
}
