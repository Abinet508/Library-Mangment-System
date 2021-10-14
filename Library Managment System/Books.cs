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
    public partial class Books : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;

        public Books()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            InitializeComponent();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            DashBoard dss = new DashBoard();
            dss.Show();
            this.Hide();
            new Books().Close();
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            Admin Adm = new Admin();
            Adm.Show();
            this.Hide();
            new Books().Close();
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            Member stu = new Member();
            stu.Show();
            this.Hide();
            new Books().Close();
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            Issue iss = new Issue();
            iss.Show();
            this.Hide();
            new Books().Close();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            AboutUs abs = new AboutUs();
            abs.Show();
            this.Hide();
            new Books().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Books().Close();
        }

        private void Books_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bOOKID.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.bOOKID.Book);
            // TODO: This line of code loads data into the 'bOOKSET.Book' table. You can move, or remove it, as needed.
           
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
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            try {
                int BID = int.Parse(comboBox1.Text);
                string BName = comboBox4.Text;
                string Author = textBox1.Text;
                string Publisher = textBox2.Text;
                DateTime Date = bunifuDatepicker1.Value.Date;
                int avil = int.Parse(Avi_Books.Text);

                BookObj Bobj = new BookObj();
                {

                    if (Bobj.AddBook(BID, BName, Author, Publisher, Date, avil))
                    {
                        new dialog().Show();

                    }
                    else
                    {
                        new Error("Problem while saving Data!!!").Show();
                    }
                }
            }
            catch
            {
                Error Er = new Error("Null Value found!!!");
                Er.Show();
            }
            }

        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            int BID = int.Parse(comboBox1.Text);
            BookObj Bobj = new BookObj();
            {

                if (Bobj.DeleteBook(BID))
                {
                    new dialog().Show();

                }
                else
                {
                    new Error("Problem While Deleting Data!!!").Show();
                  
                }
            }
        }

        private void Update_Book_Btn_Click(object sender, EventArgs e)
        {
            try {
                int BID = int.Parse(comboBox1.Text);
                string BName = comboBox4.Text;
                string Author = textBox1.Text;
                string Publisher = textBox2.Text;
                DateTime Date = bunifuDatepicker1.Value.Date;
                int Count = int.Parse(Avi_Books.Text);

                BookObj Bobj = new BookObj();
                {

                    if (Bobj.UpdateBook(BID, BName, Author, Publisher, Date, Count))
                    {
                        dialog dlog = new dialog();
                        dlog.Show();

                    }
                    else
                    {
                        new Error("Problem While Updating data!!!").Show();
                    }
                }
            }
            catch
            {
                Error Er = new Error("Invalid Value found!!!");
                Er.Show();
            }
            }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void Avi_Books_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            BookObj obj= new BookObj();
            int id = int.Parse(comboBox1.Text);
            dr = obj.searchbyid(id);
            if (dr.HasRows)
            {
                while (dr.Read())
                {


                    comboBox4.Text = dr[1].ToString();
                    textBox1.Text = dr[2].ToString();
                    textBox2.Text = dr[3].ToString();
                    label5.Text = dr[4].ToString();
                    Avi_Books.Text = dr[5].ToString();
                   

                }
                dr.Close();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Problem while Loading the data");
            }

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Books mb = new Books();
            mb.Show();
            this.Hide();
            new Books().Close();
        }

        private void Insert_Book_Btn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
    }

