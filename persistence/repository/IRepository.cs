using System.Collections.Generic;

namespace persistence.repository
{
    interface IRepository<ID,E>
    {
        void Save(E entity);
        void Delete(ID id);
        void Update(ID id, E entity);
        E FindOne(ID id);
        List<E> GetAll();

    }
}
