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
    public partial class DashBoard : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;



        public DashBoard()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            InitializeComponent();
           
        }
       
        //public DashBoard(string name )
        //{
        //    this.name = name;
           
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Admin Adm = new Admin();
            Adm.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Member Stu = new Member();
            Stu.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Issue iss = new Issue();
            iss.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AboutUs abs = new AboutUs();
            abs.Show();
            this.Hide();
            new DashBoard().Close();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            cmd.CommandText = string.Format("Select * from INFO WHERE Id = '{0}'", k);
            if (conn.State == ConnectionState.Closed)

                conn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ph = dr[2].ToString();
                name = dr[1].ToString();

            }

            dr.Close();
            conn.Close();
            pictureBox7.ImageLocation = ph;
            UsrName.Text = name;
            if (true)
            {
                cmd.CommandText = string.Format("Select Count(Admin_Id) from Admin");
                if (conn.State == ConnectionState.Closed)

                    conn.Open();
                label1.Text = cmd.ExecuteScalar().ToString();

                conn.Close();
               
            }
            if (true)
            {
                cmd.CommandText = string.Format("Select Count(Book_Id) from Book");
                if (conn.State == ConnectionState.Closed)

                    conn.Open();
                
                label4.Text= cmd.ExecuteScalar().ToString();
            }
            if (true)
            {
                cmd.CommandText = string.Format("Select Count(Member_Id) from Member");
                if (conn.State == ConnectionState.Closed)

                    conn.Open();

                label3.Text = cmd.ExecuteScalar().ToString();
            }
            if (true)
            {
                cmd.CommandText = string.Format("Select Count(Stud_ID) from RETURNBOOK");
                if (conn.State == ConnectionState.Closed)

                    conn.Open();

                label2.Text = cmd.ExecuteScalar().ToString();
            }


        }

        private void iNFOBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void UsrName_Click(object sender, EventArgs e)
        {

        }
    }
}
