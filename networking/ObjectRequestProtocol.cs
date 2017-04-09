using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace networking
{
    public interface Request
    {
    }


    [Serializable]
    public class LoginRequest : Request
    {
        public Operator Operator { get; }

        public LoginRequest(Operator Operator)
        {
            this.Operator = Operator;
        }


    }

   [Serializable]
    public class GetCurseRequest : Request
    {

        public GetCurseRequest()
        {
        }
    }

    [Serializable]
    public class GetRezervariByCursaRequest : Request
    {
        private int idCursa;

        public GetRezervariByCursaRequest(int idCursa)
        {
            this.idCursa = idCursa;
        }

        public virtual int IdCursa => idCursa;
    }
    [Serializable]

    public class GetClientByIdRequest : Request
    {
        private int idClient;

        public GetClientByIdRequest(int idClient)
        {
            this.idClient = idClient;
        }

        public int IdClient => idClient;
    }

    [Serializable]
    public class AddRezervareRequest : Request
    {
        public AddRezervareRequest(Rezervare rezervare)
        {
            this.Rezervare = rezervare;
        }

        public virtual Rezervare Rezervare { get; }
    }

    [Serializable]
    public class GetClientByNameRequest : Request
    {
        public String Nume { get; }

        public GetClientByNameRequest(String nume)
        {
            Nume = nume;
        }
    }

    [Serializable]
    public class AddClientRequest : Request
    {
        public AddClientRequest(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }

    [Serializable]
    public class UpdateCursaRequest : Request
    {
        public Cursa cursa { get; }

        public UpdateCursaRequest(Cursa cursa)
        {
            this.cursa = cursa;
        }
    }
}
