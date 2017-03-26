using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_mpp.domain;
using MySql.Data.MySqlClient;

namespace lab_mpp.repository
{
    class OperatoriRepository:IRepository<Int32,Operator>
    {
        private readonly string _connectionString;

        public OperatoriRepository()
        {
            _connectionString =
                "server=localhost;user id=user_oficii;persistsecurityinfo=True;database=firmatransport;password=parola";

        }

        public void Save(Operator entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Operator entity)
        {
            throw new NotImplementedException();
        }

        public Operator FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public List<Operator> GetAll()
        {
            List<Operator> operatori = new List<Operator>();

            using (var connection=new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command=new MySqlCommand();
                command.CommandText = "SELECT * FROM operatori";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operator op = new Operator()
                    {
                        Username = reader.GetString(0),
                        Password = reader.GetString(1),
                        Email =reader.GetString(2)
                    };
                    operatori.Add(op);
                }
            }
            return operatori;
        }
    }
}
