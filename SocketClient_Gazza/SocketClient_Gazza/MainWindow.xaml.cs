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


namespace SocketClient_Gazza
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //dichiaro le variabili socket e dispatcher time a livello globale
        Socket socket = null;
        DispatcherTimer dTimer = null;


        public MainWindow()
        {
            InitializeComponent();

            //creazione della socket
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
          
            socket.Blocking = false;
            socket.EnableBroadcast = true;

            //crea la varibile dTimer
            dTimer = new DispatcherTimer();

            //il dispatcherTime è un timer che aggiorna elementi che gli passiamo noi(in questo caso il metodo aggiornamento_timer)
            dTimer.Tick += new EventHandler(aggiornamento_dTimer);
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            dTimer.Start();
        }

        private void aggiornamento_dTimer(object sender, EventArgs e)
        {
            int nBytes = 0;

            //la lunghezza della socket la confrotnta con n la variabile nBytes e la pone uguale a 0
            if ((nBytes = socket.Available) > 0)
            {
                //ricezione dei caratteri in attesa
                byte[] buffer = new byte[nBytes];

                //crea l'endpoint con l'indirizzo specificato e il numero di porta
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                //associa il numero di bytes(la socket) nel buffer di dati e memorizza l'endpoint
                nBytes = socket.ReceiveFrom(buffer, ref remoteEndPoint);

                //converte l'endpoint di rete in un indirizzo ip + il numero di porta
                string from = ((IPEndPoint)remoteEndPoint).Address.ToString();

                //converte un array di byte in stringa e lo aggiunge alla ListBox
                string messaggio = Encoding.UTF8.GetString(buffer, 0, nBytes);
                lst_Lista.Items.Add(from + ": " + messaggio);

            }
        }

        private void btn_Invio_Click(object sender, RoutedEventArgs e)
        {
            //local address prende quello che scrivo dentro alla textBox IpLocal(indirizzo locale 192.168.1.10)
            IPAddress local_address = IPAddress.Parse(txt_IpLocal.Text);
            IPEndPoint local_endpoint = new IPEndPoint(local_address, 12000);
            lbl_LocalIp.Content = local_endpoint.ToString();

            //al remote address assegna l'indirizzo del server, ovvero il 127.0.0.1
            IPAddress remote_address = IPAddress.Parse(txt_Inserisci.Text);

            IPEndPoint remote_endpoint = new IPEndPoint(remote_address, 10000);

            //stabilisce la connessione al remote endpoint
            socket.Connect(remote_endpoint);

            byte[] messaggio = Encoding.UTF8.GetBytes(txtMessaggio.Text);

            //invia il messaggio all'endpoint specificato
            socket.SendTo(messaggio, remote_endpoint);
        }    
    }
}
