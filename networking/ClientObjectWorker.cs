using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using model;
using services;

namespace networking
{
    public class ClientObjectWorker : IObserver //, Runnable
    {
        private IServer server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        public ClientObjectWorker(IServer server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }


        private Response handleRequest(Request request)
        {
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest)request;
                //UserDTO udto = logReq.User;
               // User user = DTOUtils.getFromDTO(udto);
                Operator op = logReq.Operator;
                try
                {
                    lock (server)
                    {
                        server.Login(op, this);
                    }
                    return new OkResponse();
                }
                catch (FirmaTransportException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetCurseRequest)
            {
                Console.WriteLine("Get curse request");
                List<Cursa> curse;
                try
                {
                    lock (server)
                    {

                        curse=server.GetAllCurse();
                    }
                    connected = false;
                    return new AllCurseResponse(curse);

                }
                catch (FirmaTransportException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetRezervariByCursaRequest)
            {
                Console.WriteLine("GetRezervariByCursaRequest ...");
                GetRezervariByCursaRequest senReq = (GetRezervariByCursaRequest)request;
                int idCUrsa= senReq.IdCursa;
                try
                {
                    List<Rezervare> rezervari;
                    lock (server)
                    {
                        rezervari=server.GetAllByCursa(idCUrsa);
                    }
                    return new RezervariByCursaResponse(rezervari);
                }
                catch (FirmaTransportException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetClientByIdRequest)
            {
                Console.WriteLine("GetClientById Request ...");
                GetClientByIdRequest getReq = (GetClientByIdRequest)request;
                int idClient= getReq.IdClient;
                try
                {
                    Client client;
                    lock (server)
                    {

                        client = server.FindClient(idClient);
                    }
                    return new ClientResponse(client);
                }
                catch (FirmaTransportException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is AddRezervareRequest)
            {
                Console.WriteLine("AddRezervare request ...");
                AddRezervareRequest addRezReq = (AddRezervareRequest)request;
                //UserDTO udto = logReq.User;
                // User user = DTOUtils.getFromDTO(udto);
                Rezervare rezervare = addRezReq.Rezervare;
                try
                {
                    lock (server)
                    {
                        server.AddRezervare(rezervare);
                    }
                    return new OkResponse();
                }
                catch (FirmaTransportException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is GetClientByNameRequest)
            {
                Console.WriteLine("GetClientById Request ...");
                GetClientByNameRequest getReq = (GetClientByNameRequest)request;
                String NumeClient = getReq.Nume;
                try
                {
                    Client client;
                    lock (server)
                    {

                        client = server.FindClient(NumeClient);
                    }
                    return new ClientResponse(client);
                }
                catch (FirmaTransportException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is AddClientRequest)
            {
                Console.WriteLine("AddClient request ...");
                AddClientRequest addRezReq = (AddClientRequest)request;
                //UserDTO udto = logReq.User;
                // User user = DTOUtils.getFromDTO(udto);
                Client client = addRezReq.Client;
                try
                {
                    lock (server)
                    {
                        server.AddClient(client);
                    }
                    return new OkResponse();
                }
                catch (FirmaTransportException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is UpdateCursaRequest)
            {
                Console.WriteLine("UpdateCursa request ...");
                UpdateCursaRequest addRezReq = (UpdateCursaRequest)request;
                //UserDTO udto = logReq.User;
                // User user = DTOUtils.getFromDTO(udto);
                Cursa cursa = addRezReq.cursa;
                try
                {
                    lock (server)
                    {
                        server.UpdateCursa(cursa);
                    }
                    return new OkResponse();
                }
                catch (FirmaTransportException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            formatter.Serialize(stream, response);
            stream.Flush();

        }

        public void CursaUpdated(Cursa cursa)
        {
            sendResponse(new CursaUpdatedResponse(cursa));
        }
    }
}
