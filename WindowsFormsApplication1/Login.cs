using System;
using System.Windows.Forms;
using model;
using services;

namespace Firmatransport
{
    public partial class Login : Form
    {
        IServer server;
        public Login(IServer server)
        {
            InitializeComponent();
            this.server = server;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                MainView main = new MainView(server);
                server.Login(new Operator(username, password, ""), main);
                Hide();
                main.Show();

            }
            catch (FirmaTransportException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
