using System.Collections.Generic;

namespace persistence.services
{
    public interface IClientiServices<E>
    {
        List<E> GetAll();
        E FindOne(int idClient);
        E FindByName(string name);
        void Add(E e);
    }
}
