using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mpp.utils
{
    public interface Observable<E>
    {
        void AddObserver(Observer<E> observer);
        void RemoveObserver(Observer<E> observer);
        void NotifyObservers();
    }
}
