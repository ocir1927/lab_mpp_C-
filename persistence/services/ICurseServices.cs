using System.Collections.Generic;

namespace persistence.services
{
    public interface ICurseServices<E>
    {
        List<E> GetAll();
        void Update(int id, E e);
    }
}
