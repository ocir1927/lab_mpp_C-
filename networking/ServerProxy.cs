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
    public class ServerProxy : IServer
    {
        private string host;
        private int port;

        private IObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public ServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }

        public virtual void Login(Operator op, IObserver client)
        {
            initializeConnection();
            sendRequest(new LoginRequest(op));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
        }

        public List<Cursa> GetAllCurse()
        {
            initializeConnection();
            sendRequest(new GetCurseRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
            else
            {
                AllCurseResponse resp = (AllCurseResponse) response;
                return resp.Curse;
            }

        }

        public List<Rezervare> GetAllByCursa(int idCursa)
        {
            initializeConnection();
            sendRequest(new GetRezervariByCursaRequest(idCursa));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
            else
            {
                RezervariByCursaResponse resp = (RezervariByCursaResponse)response;
                return resp.Rezervari;
            }
        }

        public Client FindClient(int id)
        {
            initializeConnection();
            sendRequest(new GetClientByIdRequest(id));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
            else
            {
                ClientResponse resp = (ClientResponse)response;
                return resp.Client;
            }
        }

        public void AddRezervare(Rezervare rezervare)
        {
            initializeConnection();
            sendRequest(new AddRezervareRequest(rezervare));
            Response response = readResponse();
            if (response is OkResponse)
            {
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
        }

        public Client FindClient(string nume)
        {
            initializeConnection();
            sendRequest(new GetClientByNameRequest(nume));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
            else
            {
                ClientResponse resp = (ClientResponse)response;
                return resp.Client;
            }
        }

        public void AddClient(Client client)
        {
            initializeConnection();
            sendRequest(new AddClientRequest(client));
            Response response = readResponse();
            if (response is OkResponse)
            {
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }

        }

        public void UpdateCursa(Cursa cursa)
        {
            initializeConnection();
            sendRequest(new UpdateCursaRequest(cursa));
            Response response = readResponse();
            if (response is OkResponse)
            {
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new FirmaTransportException(err.Message);
            }
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
//                output.close();
                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new FirmaTransportException("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }


        private void handleUpdate(UpdateResponse update)
        {
            if (update is CursaUpdatedResponse)
            {

                CursaUpdatedResponse cursaUpdated = (CursaUpdatedResponse)update;
                Cursa cursa = cursaUpdated.Cursa;
                Console.WriteLine("Cursa Updated " + cursa);
                try
                {
                    client.CursaUpdated(cursa);
                }
                catch (FirmaTransportException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
          
        }
        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {

                        lock (responses)
                        {


                            responses.Enqueue((Response)response);

                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    
                }

            }
        }
    }
}
