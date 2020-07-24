using System.Collections.Generic;
using SubNineAPI.Entities;

namespace SubNineAPI.Repositories
{
    public interface ISubNineRepository<T>
    {
        public T GetOne(long id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetMultiple(IEnumerable<long> ids);

        public T Create(T T);
        public bool Delete(long id);
        public T Update(long id, T newT);
    }
}