using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using model;

namespace persistence.repository
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
                MySqlCommand command = connection.CreateCommand();
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

        public Operator FindBy(string username, string password)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * from firmatransport.operatori where username=@username and password=@password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operator op = new Operator()
                    {
                        Username = reader.GetString(0),
                        Password = reader.GetString(1),
                        Email = reader.GetString(2)
                    };
                    return op;
                }
            }
            return null;
        }
    }
}
