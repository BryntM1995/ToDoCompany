using System;
using System.Linq;
using ToDoCompany.Core;

namespace ToDoCompany.Service
{
    public interface IServices<Entity>
    {
        IOperationResult Add(Entity entity);
        IOperationResult Update(Entity entity);
        IOperationResult Remove(int key);
        Entity GetById(int key);
        IQueryable<Entity> GetAll();
    }
}
