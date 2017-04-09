using System.Collections.Generic;
using System.Linq;
using model;
using persistence.repository;

namespace persistence.services
{
    public class ClientiServices:IClientiServices<Client>
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
