using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Managment_System
{
    public partial class dialog : Form
    {
        public dialog()
        {
            InitializeComponent();
        }

        private void dialog_Load(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\Windows Logon.wav");
            simpleSound.Play();
        }

       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            new dialog().Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
