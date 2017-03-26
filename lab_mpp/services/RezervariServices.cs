using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.domain;
using lab_mpp.repository;
using lab_mpp.utils;

namespace lab_mpp.services
{
    class RezervariServices : Observable<Rezervare>
    {
        private List<Observer<Rezervare>> observers = new List<Observer<Rezervare>>();
        private RezervariRepository rezervariRepository;

        public RezervariServices()
        {
            rezervariRepository = new RezervariRepository();
        }

        public List<Rezervare> GetAllByCursa(int idCursa)
        {
            return rezervariRepository.GetAll().FindAll(cursa => cursa.IdCursa == idCursa);
        }

        public void AddObserver(Observer<Rezervare> observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(Observer<Rezervare> observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var ob in observers)
            {
                ob.Update(this);
            }
        }
    }
}
