using System.Collections.Generic;

namespace ApiProjectTest.Repository
{
    public interface IRepository<T> where T:class
    {
        int insert(T item);
        int update(int Id, T item);
        int delete(int Id);

        List<T> GetAll();

        T GetById(int id);
    }
}
