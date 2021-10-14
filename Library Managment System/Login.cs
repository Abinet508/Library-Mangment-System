using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    public partial class Login : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;



        public Login()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AdminObj admin = new AdminObj();
            bool dr = admin.UserExist(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);

            if (dr==true)
                {
                Error er = new Error("Invalid user Name or Password");
                er.Hide();
                new Error().Close();
                this.Hide();
               admin.getname(bunifuMaterialTextbox1.Text);
                DashBoard db = new DashBoard();
                db.Show();
                new Login().Close();
            }
            else
            {
                Error er = new Error("Invalid user Name or Password");
                 er.Show();
            }
            
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp Up = new SignUp();
            Up.Show();
            this.Hide();
            new Login().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
