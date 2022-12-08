using System;
using System.Linq;
using ToDoCompany.Core;

namespace ToDoCompany.Repository
{
    public interface IRepository<T>
    {
        IOperationResult Add(T entity);
        IOperationResult Update(T entity);
        IOperationResult Remove(int key);
        T GetById(int key);
        IQueryable<T> GetAll();
        public bool Commit();
    }
}
