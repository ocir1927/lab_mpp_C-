using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lab_mpp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
/*
            String connectionString =
               "server=localhost;user id=user_oficii;persistsecurityinfo=True;database=firmatransport;password=parola";
//            var connection = new MySqlConnection(connectionString);

            Console.WriteLine("s-a facut conexiunea cu serverul");

            String select = "SELECT * FROM firmatransport.curse";
           // MySqlCommand cmd = new MySqlCommand(select, connection);
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(select, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("idcursa:{0} destinatie:{1}", reader[0] , reader[1]);
                    }
                }
            }
        }
*/
        }
    }
}
