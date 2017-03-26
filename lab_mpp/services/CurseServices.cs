using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.repository;
using lab_mpp.utils;

namespace lab_mpp.services
{
    class CurseServices:Observable<Cursa>
    {
        List<Observer<Cursa>> observers=new List<Observer<Cursa>>();
        CurseRepository curseRepository;

        public CurseServices()
        {
            curseRepository=new CurseRepository();
        }

        public List<Cursa> GetAll()
        {
            return curseRepository.GetAll();
        }

        public void Update(int id, Cursa c)
        {
            curseRepository.Update(id,c);
            NotifyObservers();
        }


        public void AddObserver(Observer<Cursa> observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer<Cursa> observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }
    }
}
