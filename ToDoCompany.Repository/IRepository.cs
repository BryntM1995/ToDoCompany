using System;
using System.Linq;
using ToDoCompany.Core;

namespace ToDoCompany.Repository
{
    public interface IRepository<Entity>
    {
        void Add(Entity entity);
        void Update(Entity entity);
        bool Remove(int key);
        Entity GetById(int key);
        IQueryable<Entity> GetAll();
        public bool Commit();
    }
}
