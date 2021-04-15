using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T: class
    {
        public IEnumerable<T> Read();

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task<T> Delete(T entity);

        public Task<T> GetById(int id);
    }
}
