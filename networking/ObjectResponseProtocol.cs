using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace networking
{
    public interface Response
    {
    }

    [Serializable]
    public class OkResponse : Response
    {

    }

    [Serializable]
    public class ErrorResponse : Response
    {
        private string message;

        public ErrorResponse(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get
            {
                return message;
            }
        }
    }

    [Serializable]
    public class AllCurseResponse : Response
    {
        private List<Cursa> curse;

        public AllCurseResponse(List<Cursa> curse)
        {
            this.curse=curse;
        }

        public virtual List<Cursa> Curse
        {
            get
            {
                return curse;
            }
        }
    }

    [Serializable]

    public class RezervariByCursaResponse : Response
    {
        private List<Rezervare> rezervari;

        public RezervariByCursaResponse(List<Rezervare> rezervari)
        {
            this.rezervari = rezervari;
        }

        public virtual List<Rezervare> Rezervari
        {
            get
            {
                return rezervari;
            }
        }
    }

    [Serializable]

    public class ClientResponse : Response
    {
        public ClientResponse(Client client)
        {
            Client = client;
        }

        public Client Client { get; }
    }
    public interface UpdateResponse : Response
    {
    }

    [Serializable]
    public class CursaUpdatedResponse : UpdateResponse
    {
        public Cursa Cursa { get; }

        public CursaUpdatedResponse(Cursa cursa)
        {
            Cursa = cursa;
        }

    }
/*
    [Serializable]
    public class FriendLoggedOutResponse : UpdateResponse
    {
        private UserDTO friend;

        public FriendLoggedOutResponse(UserDTO friend)
        {
            this.friend = friend;
        }

        public virtual UserDTO Friend
        {
            get
            {
                return friend;
            }
        }
    }


    [Serializable]
    public class NewMessageResponse : UpdateResponse
    {
        private MessageDTO message;

        public NewMessageResponse(MessageDTO message)
        {
            this.message = message;
        }

        public virtual MessageDTO Message
        {
            get
            {
                return message;
            }
        }
    }*/
}
