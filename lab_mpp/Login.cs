using System;
using System.Windows.Forms;

namespace lab_mpp
{
    public partial class Login : Form
    {
        OperatoriServices operatoriServices;
        public Login()
        {
            InitializeComponent();
            operatoriServices=new OperatoriServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Operator op = operatoriServices.FindByUsername(username);

            if (op == null)
            {
                MessageBox.Show("Nu exista acest operator");
            }
            else if (password.Equals(op.Password))
            {
                MainView formMainView=new MainView();
                formMainView.Show();
                Hide();
            }
        }
    }
}
