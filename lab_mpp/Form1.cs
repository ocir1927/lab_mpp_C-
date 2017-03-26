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
            // TODO: This line of code loads data into the 'firmatransportDataSet.clienti_curse' table. You can move, or remove it, as needed.
            CurseRepository curseRepository=new CurseRepository();
            dataGridView1.DataSource=curseRepository.GetAll();     

        }
    }
}
