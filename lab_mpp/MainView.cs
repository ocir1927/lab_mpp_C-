using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_mpp.domain;
using lab_mpp.repository;
using lab_mpp.services;
using MySql.Data.MySqlClient;

namespace lab_mpp
{
    public partial class MainView : Form
    {
        ClientiServices clientiServices;
        CurseServices curseServices;
        OperatoriServices operatoriServices;
        RezervariServices rezervariServices;
        public MainView()
        {
            InitializeComponent();
            clientiServices=new ClientiServices();
            curseServices=new CurseServices();
            operatoriServices=new OperatoriServices();
            rezervariServices=new RezervariServices();
        }


        private void MainView_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            List<Cursa> curse = curseServices.GetAll();
            SetItems(curse);
        }

        private void SetItems(List<Cursa> curse)
        {
            listViewCurse.Items.Clear();
            foreach (var cursa in curse)
            {
                string[] row =
                {
                    cursa.Id.ToString(), cursa.Destinatie, cursa.DateTime.ToString(),
                    cursa.LocuriDisponibile.ToString()
                };
                ListViewItem item = new ListViewItem(cursa.Id.ToString());
                //                listViewCurse.Items.Add(cursa.Id.ToString());
                //                listViewCurse.Items.Add(cursa.Id.ToString());
                item.SubItems.Add(cursa.Destinatie);
                item.SubItems.Add(cursa.DateTime.ToString());
                item.SubItems.Add(cursa.LocuriDisponibile.ToString());
                listViewCurse.Items.Add(item);

            }
        }

        private void ShowClienti(int idCursa)
        {
            listViewClienti.Items.Clear();
            List<Client> modelClienti = new List<Client>();
            foreach (Rezervare rez in rezervariServices.GetAllByCursa(idCursa))
            {
                for (int i = 0; i < rez.NrLocuri; i++)
                {
                    modelClienti.Add(clientiServices.FindOne(rez.IdClient));
                }
            }
            for (int i = modelClienti.Count(); i < 18; i++)
            {
                modelClienti.Add(new Client("- - -"));
            }
            int j = 0;

            foreach (var client in modelClienti)
            {
                j++;
                ListViewItem item=new ListViewItem(j.ToString());
                item.SubItems.Add(client.Nume);
                listViewClienti.Items.Add(item);

            }

        }

        private void listViewCurse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCurse.SelectedItems.Count == 1)
            {
                int idCursa = Int32.Parse(listViewCurse.SelectedItems[0].SubItems[0].Text);
                if (idCursa != 0)
                {
                    ShowClienti(idCursa);
                }
            }
        }

        private void btnCauta_Click(object sender, EventArgs e)
        {
            string destinatie = txtDestinatie.Text.ToLower();
            string dateTime = txtData.Text;
            List<Cursa> curseFiltrare =
                curseServices.GetAll().Where(cursa => cursa.Destinatie.ToLower().Contains(destinatie) 
                && cursa.DateTime.ToString().ToLower().Contains(dateTime)).ToList();
            SetItems(curseFiltrare);
        }
    }
}
