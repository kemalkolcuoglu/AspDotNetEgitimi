using System.Collections.Generic;

namespace SimpleRentACarProject.DAL.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        int Edit(int id, T Entity);
        int Delete(int id);
    }
}
