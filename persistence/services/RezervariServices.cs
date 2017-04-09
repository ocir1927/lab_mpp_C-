using System.Collections.Generic;
using model;
using persistence.repository;

namespace persistence.services
{
    public class RezervariServices :IRezervariServices<Rezervare>
    {
//        private List<Observer<Rezervare>> observers = new List<Observer<Rezervare>>();
        private RezervariRepository rezervariRepository;

        public RezervariServices()
        {
            rezervariRepository = new RezervariRepository();
        }

        public List<Rezervare> GetAllByCursa(int idCursa)
        {
            return rezervariRepository.GetAll().FindAll(cursa => cursa.IdCursa == idCursa);
        }

        public void Add(Rezervare rezervare)
        {
            rezervariRepository.Save(rezervare);
        }

/*        public void AddObserver(Observer<Rezervare> observer)
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
        }*/
    }
}
