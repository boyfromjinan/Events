using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Events.Repository.Repository
{
    public interface IRepository<T>
    {
        T Create(T entity);
        void Remove(int id);
        void Update(T entity);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
