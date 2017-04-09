using System;

namespace model
{
    [Serializable]
    public class Cursa
    {
        public int Id { get; set; }
        public string Destinatie { get; set; }
        public DateTime DateTime { get; set; }
        public int LocuriDisponibile { get; set; }
        public int Oficiu { get; set; }

        public Cursa()
        {
        }

        public Cursa(int id, string destinatie, DateTime dateTime, int locuriDisponibile, int oficiu)
        {
            Id = id;
            Destinatie = destinatie;
            DateTime = dateTime;
            LocuriDisponibile = locuriDisponibile;
            Oficiu = oficiu;
        }

        public Cursa(string destinatie, DateTime dateTime, int locuriDisponibile, int oficiu)
        {
            Id = 0;
            Destinatie = destinatie;
            DateTime = dateTime;
            LocuriDisponibile = locuriDisponibile;
            Oficiu = oficiu;
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Destinatie + " " + DateTime.ToString() + " " + LocuriDisponibile.ToString() +
                   " " + Oficiu.ToString();
        }
    }
}
