using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Library_Managment_System
{
    public partial class Error : Form
    {
        string j;
        public Error()
        {
            InitializeComponent();
        }
        public Error(string k)
        {
            j = k;
            InitializeComponent();
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

        }

        private void Error_Load(object sender, EventArgs e)
        {
           
            SoundPlayer simpleSound = new SoundPlayer (@"C:\Windows\media\Windows Critical Stop.wav");

            simpleSound.Play();
           

        bunifuCustomLabel1.Text = j;

           
        }
     
       
        }
    }

