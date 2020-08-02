using System.Collections.Generic;

namespace SubNine.Core.Repositories
{
    public interface IRepository<T>
    {
        T GetOne(long id);

        IEnumerable<T> GetAll(string search);

        bool Delete(long id);

        T Create(T entity);

        T Update(long id, T entity);
    }
}
