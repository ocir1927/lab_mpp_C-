using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using model;
using networking;
using persistence.services;
using services;

namespace Server
{
    class StartServer
    {
        public static void Main(string[] args)
        {
            OperatoriServices operatoriServices = new OperatoriServices();
            ClientiServices clientiServices = new ClientiServices();
            CurseServices curseServices = new CurseServices();
            RezervariServices rezervariServices = new RezervariServices();


            IServer serviceImpl = new ServerImpl(operatoriServices,curseServices,rezervariServices,clientiServices);

            // IChatServer serviceImpl = new ChatServerImpl();
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55555, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();
        }
    }

    public class SerialChatServer : ConcurrentServer
    {
        private IServer server;
        private ClientObjectWorker worker;
        public SerialChatServer(string host, int port, IServer server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientObjectWorker(server, client);
            return new Thread(worker.run);
        }
    }
}
