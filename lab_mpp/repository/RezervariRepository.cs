using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.domain;
using MySql.Data.MySqlClient;

namespace lab_mpp.repository
{
    class RezervariRepository:IRepository<int,Rezervare>
    {
        readonly string _connectionString;

        public RezervariRepository()
        {
            _connectionString = 
                "server=localhost;user id=user_oficii;persistsecurityinfo=True;database=firmatransport;password=parola";
        }

        public void Save(Rezervare entity)
        {
            using (var connection=new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = "INSERT INTO rezervari VALUES(@id,@id_cursa,@id_client,@nr_locuri)";
                comm.Parameters.AddWithValue("@id", entity.Id);
                comm.Parameters.AddWithValue("@id_client", entity.IdClient);
                comm.Parameters.AddWithValue("@id_cursa", entity.IdCursa);
                comm.Parameters.AddWithValue("@nr_locuri", entity.NrLocuri);
                comm.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection=new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM rezervari WHERE id=@id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, Rezervare entity)
        {
            throw new NotImplementedException();
        }

        public Rezervare FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rezervare> GetAll()
        {
            List<Rezervare> rezervari=new List<Rezervare>();
            using (var connection=new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM rezervari";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Rezervare rezervare = new Rezervare()
                    {
                        Id = reader.GetInt32(0),
                        IdCursa = reader.GetInt32(1),
                        IdClient = reader.GetInt32(2),
                        NrLocuri = reader.GetInt32(3)
                    };
                    rezervari.Add(rezervare);
                }
            }
            return rezervari;
        }
    }
}
