using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Library_Managment_System
{
    public partial class Member : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;
        public Member()
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
            Admin Adm = new Admin();
            Adm.Show();
            this.Hide();
            new Member().Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.Show();
            this.Hide();
            new Member().Close();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Issue iss = new Issue();
            iss.Show();
            this.Hide();
            new Member().Close();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            DashBoard dss = new DashBoard();
            dss.Show();
            this.Hide();
            new Member().Close();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            AboutUs abs = new AboutUs();
            abs.Show();
            this.Hide();
            new Member().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Member().Close();
        }

        private void Member_Load(object sender, EventArgs e)
        {
            fill();
            // TODO: This line of code loads data into the 'lMS_DBDataSet5.Member' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'lMS_DBDataSet4.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.lMS_DBDataSet4.Member);
            // TODO: This line of code loads data into the 'lMS_DBDataSet2.Member' table. You can move, or remove it, as needed.
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
            pictureBox7.ImageLocation = ph;
            UsrName.Text = name;
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            try {
                int MID = int.Parse(comboBox1.Text);
                string MName = comboBox4.Text;
                string MLName = textBox3.Text;
                int Phone = int.Parse(textBox2.Text);
                string Email = textBox4.Text;
                int Payment = int.Parse(textBox1.Text);
                DateTime date = bunifuDatepicker1.Value.Date;

                MemberObj Mobj = new MemberObj();
                {

                    if (Mobj.AddMember(MID, MName, MLName, Phone, Email, Payment, date))
                    {
                        new dialog().Show();
                    }
                    else
                    {
                        Error Er = new Error("Problem while Saving!!!");
                        Er.Show();
                    }
                }
            }
            catch
            {
                Error Er = new Error("Null Value found!!!");
                Er.Show();
            }
        }

        private void Delete_Member_Btn_Click(object sender, EventArgs e)
        {
            try {
                int MID = int.Parse(comboBox1.Text);
                MemberObj Mobj = new MemberObj();
                {

                    if (Mobj.DeleteMember(MID))
                    {
                        dialog dlog = new dialog();
                        dlog.Show();

                    }
                    else
                    {
                        MessageBox.Show("Problem while deleting data");
                    }
                }
            }
            catch
            {
                Error Er = new Error("Invalid Input");
                Er.Show();
            }
        }


        private void Update_Member_Btn_Click(object sender, EventArgs e)
        {
            try {

                int MID = int.Parse(comboBox1.Text);
                string MName = comboBox4.Text;
                string MLName = textBox3.Text;
                int Phone = int.Parse(textBox2.Text);
                string Email = textBox4.Text;
                int Payment = int.Parse(textBox1.Text);
                DateTime Date = bunifuDatepicker1.Value.Date;

                MemberObj Mobj = new MemberObj();
                {

                    if (Mobj.UpdateMember(MID, MName, MLName, Phone, Email, Payment, Date))
                    {
                        dialog dlog = new dialog();
                        dlog.Show();

                    }
                    else
                    {

                        new Error("Error Occured While Updating Please Try Again!!").Show();

                    }
                }
            }
            catch
            {
                Error Er = new Error("Invalid Input");
                Er.Show();
            }
        }
        public void fill()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();


            string query = "select Member_Id from Member";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlDataReader drr = sda.SelectCommand.ExecuteReader();
            while (drr.Read())
            {
                comboBox1.Items.Add(drr[0]);
            }
            conn.Close();
        }
        public void searchbyid()
        {
            try { int ID = int.Parse(comboBox1.Text);
                string q = "SELECT * FROM Member WHERE Member_Id='" + ID + "'";
                SqlDataAdapter sdd = new SqlDataAdapter(q, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = sdd.SelectCommand.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {


                        comboBox4.Text = dr[1].ToString();
                        textBox3.Text = dr[2].ToString();
                        textBox2.Text = dr[3].ToString();
                        textBox4.Text = dr[4].ToString();
                        textBox1.Text = dr[5].ToString();
                        label6.Text = dr[6].ToString();

                    }
                    dr.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Problem while Loading the data");
                }
            }catch(Exception ex)
            {
                new Error().Show();
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            searchbyid();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Member mb = new Member();
            mb.Show();
            this.Hide();
            new Member().Close();
        }
    }
}

