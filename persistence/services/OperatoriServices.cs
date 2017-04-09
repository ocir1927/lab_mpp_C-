using System.Linq;
using model;
using persistence.repository;

namespace persistence.services
{
    public class OperatoriServices:IOperatoriServices<Operator>
    {
        private OperatoriRepository operatoriRepository;

        public OperatoriServices()
        {
            operatoriRepository = new OperatoriRepository();
        }

        public Operator FindByUsername(string username)
        {
            return operatoriRepository.GetAll().FirstOrDefault(op => op.Username.Equals(username));
        }

        public Operator Login(string username, string password)
        {
            return operatoriRepository.FindBy(username, password);
        }

    }
}
