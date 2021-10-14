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
    public partial class Admin : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;



        public Admin()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            InitializeComponent();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            DashBoard dss = new DashBoard();
            dss.Show();
            this.Hide();
            new Admin().Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Member stu = new Member();
            stu.Show();
            this.Hide();
            new Admin().Close();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.Show();
            this.Hide();
            new Admin().Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Issue iss = new Issue();
            iss.Show();
            this.Hide();
            new Admin().Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AboutUs abs = new AboutUs();
            abs.Show();
            this.Hide();
            new Admin().Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Admin().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Admin().Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aDMINSET.Admin' table. You can move, or remove it, as needed.
         //   this.adminTableAdapter.Fill(this.aDMINSET.Admin);
            AdminObj obj = new AdminObj();
            cmd.CommandText = string.Format("SELECT * FROM INFO WHERE Id = '{0}'", k);
            if (conn.State == ConnectionState.Closed)

                conn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                name = dr[1].ToString();
                ph = dr[2].ToString();
               

            }

            dr.Close();
            
            pictureBox5.ImageLocation =ph ;
            label7.Text = name;
            fill();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(comboBox1.Text);
                string Name = comboBox4.Text;
                string Email = textBox3.Text;
                int phone = int.Parse(textBox2.Text);
                string Password = textBox1.Text;
                string Photo = textBox4.Text;


                AdminObj ado = new AdminObj();

                if (ado.UpdateAdmin(ID, Name, Email, phone, Password, Photo))
                {
                    dialog dlog = new dialog();
                    dlog.Show();

                }
                else
                {
                    new Error("Problem While Updating ADMINISTRATOR Data Please Try Again").Show();
                }
            }
            catch
            {
                Error Er = new Error("Invalid Input");
                Er.Show();
            }
        }
            
            
        

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            string file=op.FileName.ToString();
            textBox4.Text = file;
            pictureBox3.ImageLocation = file;

        }

        public void fill()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

           
            string query = "select Admin_id from Admin";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlDataReader drr = sda.SelectCommand.ExecuteReader();
            while (drr.Read())
            {
                comboBox1.Items.Add(drr[0]);
            }
            conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int cmb = int.Parse(comboBox1.Text);
           string query = "select * from Admin where Admin_Id = '"+cmb+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            dr = sda.SelectCommand.ExecuteReader();
            
            while (dr.Read())
                {

                    textBox4.Text = dr[5].ToString();
                    comboBox4.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                   textBox2.Text= dr[3].ToString();
                    pictureBox3.ImageLocation = dr[5].ToString();

                } conn.Close();
        }
            //else
            //{
            //    new Error("Problem While Loading ADMINISTRATOR Data Please Try Again").Show();
              
            //}


        

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Admin_Btn_Click(object sender, EventArgs e)

        {
            try {
                int ID = int.Parse(comboBox1.Text);
                AdminObj ado = new AdminObj();
                {

                    if (ado.DeleteAdmin(ID))
                    {
                        new Admin().Show();

                    }
                    else
                    {
                        new Error("Problem While Deleting ADMINISTRATOR Data Please Try Again").Show();

                    }
                }
            }
            catch
            {
                Error Er = new Error("Invalid Input");
                Er.Show();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
            new Admin().Close();
        }
    }

       
    }


