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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                Login l1 = new Login();
                this.Hide();
                this.Close();
            }
            
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
    }
    }

