using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using model;
using persistence.services;
using services;

namespace Firmatransport
{
    public partial class MainView : Form, IObserver
    {
//        IClientiServices<Client> clientiServices;
//        CurseServices curseServices;
//        IOperatoriServices<Operator> operatoriServices;
//        IRezervariServices<Rezervare> rezervariServices;
        IServer Server;
        List<Cursa> ModelCurse;


        public MainView(IServer server)
        {
            InitializeComponent();
            Server = server;
            ModelCurse = GetAllCurse();
//            clientiServices=new ClientiServices();
//            curseServices=new CurseServices();
//            curseServices.AddObserver(this);
//            operatoriServices=new OperatoriServices();
//            rezervariServices=new RezervariServices();
        }


        private void MainView_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private List<Cursa> GetAllCurse()
        {
            return Server.GetAllCurse();
        }

        private void BindData()
        {
            SetItems(ModelCurse);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
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

        private List<Rezervare> GetAllByCursa(int idCursa)
        {
            return Server.GetAllByCursa(idCursa);
        }


        private void ShowClienti(int idCursa)
        {
            listViewClienti.Items.Clear();
            List<Client> modelClienti = new List<Client>();
            foreach (Rezervare rez in GetAllByCursa(idCursa))
            {
                for (int i = 0; i < rez.NrLocuri; i++)
                {
                    modelClienti.Add(Server.FindClient(rez.IdClient));
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
                ListViewItem item = new ListViewItem(j.ToString());
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
                ModelCurse.Where(cursa => cursa.Destinatie.ToLower().Contains(destinatie)
                                          && cursa.DateTime.ToString().ToLower().Contains(dateTime)).ToList();
            SetItems(curseFiltrare);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BindData();
            txtData.Text = "";
            txtDestinatie.Text = "";
        }

        private void btnRezervare_Click(object sender, EventArgs e)
        {
            string numeClient = txtNumeClient.Text;
            int nrLocuri = int.Parse(txtNrLocuri.Text);
            int idCursa;
            int idClient;
            Cursa cursa;
            if (listViewCurse.SelectedItems.Count == 1)
            {
                cursa = new Cursa()
                {
                    Id = Convert.ToInt32(listViewCurse.SelectedItems[0].SubItems[0].Text),
                    Destinatie = listViewCurse.SelectedItems[0].SubItems[1].Text,
                    DateTime = Convert.ToDateTime(listViewCurse.SelectedItems[0].SubItems[2].Text),
                    LocuriDisponibile = Convert.ToInt32(listViewCurse.SelectedItems[0].SubItems[3].Text),
                    Oficiu = 1
                };
                idCursa = Convert.ToInt32(listViewCurse.SelectedItems[0].SubItems[0].Text);
                if (Server.FindClient(numeClient) == null)
                {
                    Server.AddClient(new Client(numeClient));
                }
                idClient = Server.FindClient(numeClient).Id;
                Rezervare rezervare = new Rezervare(idCursa, idClient, nrLocuri);
                Server.AddRezervare(rezervare);
                cursa.LocuriDisponibile = cursa.LocuriDisponibile - nrLocuri;
                Server.UpdateCursa(cursa);
                ShowClienti(cursa.Id);
            }
        }


        public void CursaUpdated(Cursa cursa)
        {
            foreach (Cursa c in ModelCurse)
            {
                if (c.Id == cursa.Id)
                {
                    int index = ModelCurse.IndexOf(cursa);
                    ModelCurse[index] = c;
                    break;
                }
            }
        }
    }
}
