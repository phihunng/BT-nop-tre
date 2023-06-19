using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Server ServerForm = new Server();
            ServerForm.Show();
        }
    }
}
