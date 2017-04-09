using System.Collections.Generic;

namespace persistence.services
{
    public interface IRezervariServices<E>
    {
        List<E> GetAllByCursa(int idCursa);
        void Add(E e);
    }
}
