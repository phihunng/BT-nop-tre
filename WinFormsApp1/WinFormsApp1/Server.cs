using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(initialize);
            thread1.Start();
        }
        int listenPort = 5000;
        IPEndPoint clientEndPoint;
        IPAddress getClient;
        void initialize()
        {
            // Specify the IP address and port number the server will listen on
            UdpClient listener = new UdpClient(listenPort);
            // Create a UDP socket to listen for incoming messages

            while (true)
            {
                // Wait for a message to arrive
                clientEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
                IPAddress getClient = IPAddress.Any;
                byte[] data = listener.Receive(ref clientEndPoint);

                // Convert the message data to a string
                richTextBox1.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.AppendText(System.Text.Encoding.UTF8.GetString(data) + "\r\n");
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
