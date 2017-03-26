using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace lab_mpp.repository
{
    class ClientiRepository:IRepository<Int32,Client>
    {
        readonly string _connectionString;

        public ClientiRepository()
        {
            _connectionString =
                "server=localhost;user id=user_oficii;persistsecurityinfo=True;database=firmatransport;password=parola";
        }

        public void Save(Client client)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO clienti VALUES(@id,@nume)";
                comm.Parameters.AddWithValue("@id", client.Id);
                comm.Parameters.AddWithValue("@nume", client.Nume);
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Client entity)
        {
            throw new NotImplementedException();
        }

        public Client FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAll()
        {
            List<Client> clienti = new List<Client>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM clienti";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client()
                    {
                        Id = reader.GetInt32(0),
                        Nume = reader.GetString(1),

                    };
                    clienti.Add(client);
                }
            }
            return clienti;
        }

    }
}
