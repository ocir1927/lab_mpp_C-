using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mpp
{
    class Client
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int IdCursa { get; set; }

        public Client(int id, string nume, int idCursa)
        {
            Id = id;
            Nume = nume;
            IdCursa = idCursa;
        }

        public Client(string nume, int idCursa)
        {
            Nume = nume;
            IdCursa = idCursa;
        }

        public Client()
        {
        }

        public override string ToString()
        {
            return Id + " " + Nume + " " + IdCursa;
        }
    }
}
