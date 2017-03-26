using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.repository;

namespace lab_mpp.services
{
    class ClientiServices
    {
        private ClientiRepository clientiRepository;

        public ClientiServices()
        {
            clientiRepository=new ClientiRepository();
        }

        public List<Client> GetAll()
        {
            return clientiRepository.GetAll();
        }

        public Client FindOne(int idClient)
        {
            return GetAll().FirstOrDefault(client => client.Id == idClient);
        }

        public Client FindByName(string name)
        {
            return GetAll().FirstOrDefault(client => client.Nume.Equals(name));
        }

        public void Add(Client c)
        {
            clientiRepository.Save(c);
        }

    }
}
