using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SocketServer_Gazza
{
    public partial class MainWindow : Window
    {
        Socket socket = null;
        DispatcherTimer dTimer = null;
        EndPoint remote_endpoint;


        public MainWindow()
        {
            InitializeComponent();

            //creazione della socket
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //assegna l'idirizzo alla variabile local address(indirizzo del server) ovver il 127.0.0.1
            IPAddress local_address = IPAddress.Parse("127.0.0.1");

            //come ednpoint prende il local address(127.0.0.) e gli assegna la porta 10000
            IPEndPoint local_endpoint = new IPEndPoint(local_address, 10000);
            socket.Bind(local_endpoint);

            socket.Blocking = false;
            socket.EnableBroadcast = true;

            //il dispatcher time è uguale a quello presentato nel client
            dTimer = new DispatcherTimer();

            dTimer.Tick += new EventHandler(aggiornamento_dTimer);
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dTimer.Start();
        }


        //Qui si applica lo stesso ragionamento per il metodo di aggiornamento timer del client ma da parte del server
        private void aggiornamento_dTimer(object sender, EventArgs e)
        {
            int nBytes = 0;

            if ((nBytes = socket.Available) > 0)
            {
                //ricezione dei caratteri in attesa
                byte[] buffer = new byte[nBytes];

                remote_endpoint = new IPEndPoint(IPAddress.Any, 0);

                nBytes = socket.ReceiveFrom(buffer, ref remote_endpoint);

                string from = ((IPEndPoint)remote_endpoint).Address.ToString();

                //converte un array di byte in stringa e lo aggiunge alla ListBox
                string messaggio = Encoding.UTF8.GetString(buffer, 0, nBytes);
                lst_Lista.Items.Add(from + ": " + messaggio);

            }
        }

        private void btn_Invio_Click(object sender, RoutedEventArgs e)
        {
            //converte il messaggio in interi
            byte[] messaggio = Encoding.UTF8.GetBytes(txtMessaggio.Text);

            //invioa il messaggio al remote endpoint che nel caso del server, è il nostro client
            socket.SendTo(messaggio, remote_endpoint);
        }     
    }
}
