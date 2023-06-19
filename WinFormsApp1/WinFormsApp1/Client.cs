using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormsApp1
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private void button1_Click(object sender, EventArgs e)
        {
            string hostname = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostname);
            IPAddress[] addresses = ipEntry.AddressList;
            string serverIP = string.Empty;
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    serverIP = address.ToString();
                }
            }
            int serverPort = 5000;

            IPAddress broadcast = IPAddress.Parse("192.168.0.123");

            byte[] sendbuf = System.Text.Encoding.UTF8.GetBytes("Client:" + textBox1.Text);
            IPEndPoint ep = new IPEndPoint(broadcast, serverPort);
            richTextBox1.AppendText("Client: " + textBox1.Text + "\r\n");
            textBox1.Text = "";
            s.SendTo(sendbuf, ep);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void receive_message()
        {
            // Create a new UDP client to receive messages
            UdpClient udpClient = new UdpClient();

            // Bind the client to a random port
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 0));

            // Loop to receive messages and print them to the console
            while (true)
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                string receivedString = Encoding.UTF8.GetString(receivedData);
                richTextBox1.AppendText("Server: " + receivedString + "\n\r");
            }
        }
        private void Client_Load(object sender, EventArgs e)
        {
           
        }
    }
}