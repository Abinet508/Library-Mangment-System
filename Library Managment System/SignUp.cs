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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new SignUp().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try {
                int ID = int.Parse(bunifuMaterialTextbox7.Text);
                string Name = bunifuMaterialTextbox1.Text;
                string Email = bunifuMaterialTextbox4.Text;
                int phone = Int32.Parse(bunifuMaterialTextbox5.Text);
                string Password = bunifuMaterialTextbox2.Text;
                string Photo = pictureBox2.ImageLocation.ToString();

                AdminObj ado = new AdminObj();
                
                    if (ado.AddAdmin(ID, Name, Email, phone, Password, Photo))
                    {
                        dialog dlog = new dialog();
                        dlog.Show();

                    }
                    else
                    {
                        new Error("Problem while Saving Data Please Try Again").Show();

                    }
                }
            
            catch
            {
                Error Er = new Error("Please Insert the valid data!!!");
                Er.Show();
            }

            }
       
        public void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            string k =op.FileName.ToString();
         pictureBox2.ImageLocation =k ;
            
           
            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            AdminObj Ao = new AdminObj();
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
