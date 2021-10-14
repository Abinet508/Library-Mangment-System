using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashBoard dss = new DashBoard();
            dss.Show();
            this.Hide();
            new AboutUs().Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new AboutUs().Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
