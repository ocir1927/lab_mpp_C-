using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace lab_mpp.repository
{
    class CurseRepository:IRepository<int,Cursa>
    {
        readonly String _connectionString;

        public CurseRepository()
        {
            _connectionString =
                "server=localhost;user id=user_oficii;persistsecurityinfo=True;database=firmatransport;password=parola";
        }

        public void Save(Cursa c)
        {

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO curse VALUES(@id,@destinatie, @datetime,@locuri,@oficiu)";
                comm.Parameters.AddWithValue("@id", c.Id);
                comm.Parameters.AddWithValue("@destinatie", c.Destinatie);
                comm.Parameters.AddWithValue("@datetime", c.DateTime);
                comm.Parameters.AddWithValue("@locuri", c.LocuriDisponibile);
                comm.Parameters.AddWithValue("@oficiu", c.Oficiu);
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(int id, Cursa cursa)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "UPDATE curse SET destinatie=@destinatie, data_ora=@datetime,"
                                      + "locuri_disponibile=@locuri,oficiu=@oficiu WHERE idcursa=@idcursa";
                command.Parameters.AddWithValue("@idcursa", id);
                command.Parameters.AddWithValue("@destinatie", cursa.Destinatie);
                command.Parameters.AddWithValue("@datetime", cursa.DateTime);
                command.Parameters.AddWithValue("@locuri", cursa.LocuriDisponibile);
                command.Parameters.AddWithValue("@oficiu", cursa.Oficiu);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }


        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM curse WHERE idcursa=@idcursa";
                command.Parameters.AddWithValue("@idcursa", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Cursa> GetAll()
        {
            List<Cursa> curse = new List<Cursa>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM curse";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cursa cursa = new Cursa()
                    {
                        Id = reader.GetInt32(0),
                        Destinatie = reader.GetString(1),
                        DateTime = reader.GetDateTime(2),
                        LocuriDisponibile = reader.GetInt32(3),
                        Oficiu = reader.GetInt32(4)

                    };
                    curse.Add(cursa);
                }
            }
            return curse;
        }

        public Cursa FindOne(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM curse WHERE idcursa=@idcursa";
                command.Parameters.AddWithValue("@idcursa", id);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cursa cursa = new Cursa()
                    {
                        Id = reader.GetInt32(0),
                        Destinatie = reader.GetString(1),
                        DateTime = reader.GetDateTime(2),
                        LocuriDisponibile = reader.GetInt32(3),
                        Oficiu = reader.GetInt32(4)
                    };
                    return cursa;
                }
            }
            return null;

        }
    }

   
}
