using System;

namespace model
{
    [Serializable]
    public class Client
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
