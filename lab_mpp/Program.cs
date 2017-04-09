using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_mpp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

//            DateTime dateTime=new DateTime(2017,3,20,10,30,0);

//            CurseRepository curseRepository=new CurseRepository();
//            Cursa c=new Cursa(10,"Tirgu Mures",dateTime,12,1);
//            curseRepository.Add(c);
//            curseRepository.Update(10,c);
//            curseRepository.Delete(10);
/*            foreach (var cursa in curseRepository.GetAll())
            {
                Console.WriteLine(cursa);
            }*/
//            Console.WriteLine(curseRepository.FindOne(1));
//            Client client=new Client("Pop Andrei",321);
//            ClientiRepository clientiRepository=new ClientiRepository();
//            clientiRepository.Add(client);  
           /* foreach (var client1 in clientiRepository.GetAllByCursa(1))
            {
                Console.WriteLine(client1);
            }*/
                  
            Application.Run(new Login());
        }
    }
}
