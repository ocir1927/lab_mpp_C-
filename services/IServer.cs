using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace services
{
    public interface IServer
    {
        void Login(Operator op,IObserver client);
        List<Cursa> GetAllCurse();
        List<Rezervare> GetAllByCursa(int idCursa);
        Client FindClient(int id);
        void AddRezervare(Rezervare rezervare);
        Client FindClient(String nume);
        void AddClient(Client client);
        void UpdateCursa(Cursa cursa);
    }
}
