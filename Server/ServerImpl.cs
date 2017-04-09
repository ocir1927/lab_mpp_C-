using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using services;
using persistence.services;
namespace Server
{
    public class ServerImpl:IServer
    {
        private OperatoriServices operatoriServices;
        private CurseServices curseServices;
        private RezervariServices rezervariServices;
        private ClientiServices clientiServices;
        private readonly IDictionary<String, IObserver> loggedClients;

        public ServerImpl(OperatoriServices operatoriServices, CurseServices curseServices, RezervariServices rezervariServices, ClientiServices clientiServices)
        {
            this.operatoriServices = operatoriServices;
            this.curseServices = curseServices;
            this.rezervariServices = rezervariServices;
            this.clientiServices = clientiServices;
            loggedClients=new Dictionary<string, IObserver>();
        }


        public void Login(Operator op, IObserver client)
        {
            Operator oper=operatoriServices.Login(op.Username, op.Password);
            if (oper != null)
            {
                if (loggedClients.ContainsKey(op.Username))
                    throw new FirmaTransportException("User already logged in.");
                loggedClients[op.Username] = client;
//                notifyFriendsLoggedIn(user);
            }
            else
                throw new FirmaTransportException("Authentication failed.");
        }

        public List<Cursa> GetAllCurse()
        {
            List<Cursa> curse = curseServices.GetAll();
            if (curse == null)
            {
                throw new FirmaTransportException("Nu exista curse");
            }
            return curse;
        }

        public List<Rezervare> GetAllByCursa(int idCursa)
        {
            List<Rezervare> rezervari = rezervariServices.GetAllByCursa(idCursa);
            if (rezervari == null)
            {
                throw new FirmaTransportException("Nu exista rezervari");
            }
            return rezervari;
        }

        public Client FindClient(int id)
        {
            Client client = clientiServices.FindOne(id);
            if (client == null)
            {
                throw new FirmaTransportException("Nu exista clientul cu id-ul:"+id);
            }
            return client;
        }

        public void AddRezervare(Rezervare rezervare)
        {
            rezervariServices.Add(rezervare);
        }

        public Client FindClient(string nume)
        {
            Client client = clientiServices.FindByName(nume);
            return client;
        }

        public void AddClient(Client client)
        {
            clientiServices.Add(client);
        }

        public void UpdateCursa(Cursa cursa)
        {
            curseServices.Update(cursa.Id,cursa);
            NotifyUpdate(cursa);
        }

        public void NotifyUpdate(Cursa cursa)
        {
            Console.WriteLine("notify update at cursa:"+cursa);
            foreach (var cl in loggedClients)
            {
                cl.Value.CursaUpdated(cursa);
            }
        }
    }
}
