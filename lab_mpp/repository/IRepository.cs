using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_mpp.repository
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
