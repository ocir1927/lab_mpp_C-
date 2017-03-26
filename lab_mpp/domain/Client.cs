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

        public Client(int id, string nume)
        {
            Id = id;
            Nume = nume;
        }

        public Client(string nume)
        {
            Id = 0;
            Nume = nume;
        }

        public Client()
        {
        }

        public override string ToString()
        {
            return Id + " " + Nume;
        }
    }
}
