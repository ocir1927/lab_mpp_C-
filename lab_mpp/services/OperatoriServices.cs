using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.domain;
using lab_mpp.repository;

namespace lab_mpp.services
{
    class OperatoriServices
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

    }
}
