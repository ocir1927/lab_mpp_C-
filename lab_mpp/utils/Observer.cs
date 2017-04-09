using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mpp.utils
{
    public interface Observer<E>
    {
        void Update(Observable<E> observable);
    }
}
