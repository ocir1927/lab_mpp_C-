using System;

namespace model
{
    [Serializable]
    public class Operator
    { 
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Username + " " + Password + " " + Email;
        }

        public Operator()
        {
        }

        public Operator(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
