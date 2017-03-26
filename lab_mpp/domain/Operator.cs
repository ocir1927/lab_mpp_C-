﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_mpp.domain
{
    class Operator
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
