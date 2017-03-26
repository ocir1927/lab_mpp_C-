using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mpp.domain
{
    class Rezervare
    {
        public int Id { get; set; }
        public int IdCursa { get; set; }
        public int IdClient { get; set; }
        public int NrLocuri { get; set; }

        public Rezervare(int idCursa, int idClient, int nrLocuri)
        {
            Id = 0;
            IdCursa = idCursa;
            IdClient = idClient;
            NrLocuri = nrLocuri;
        }

        public override string ToString()
        {
            return Id + " " + IdCursa + " " + IdClient + " " + NrLocuri;
        }

        public Rezervare(int id, int idCursa, int idClient, int nrLocuri)
        {
            Id = id;
            IdCursa = idCursa;
            IdClient = idClient;
            NrLocuri = nrLocuri;
        }

        public Rezervare()
        {
        }
    }
}
