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
    public partial class Issue : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        int count;
        int count2;
        int avil;
        string name;
        public Issue()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            InitializeComponent();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Issue().Close();
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lMS_DBDataSet.RETURNBOOK' table. You can move, or remove it, as needed.
            this.rETURNBOOKTableAdapter.Fill(this.lMS_DBDataSet.RETURNBOOK);
            // TODO: This line of code loads data into the 'bOOK.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.bOOK.Book);
            fillstud();
            fill();
            comboBox1.Text = "Select";
            comboBox3.Text = "Select";

            try
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
            } catch (Exception ex)
            {
                Error er = new Error("SomeThing Went Wrong");
                er.Show();
            }
            finally
            {
                dr.Close();
                conn.Close();
                pictureBox7.ImageLocation = ph;
                UsrName.Text = name;

            }
           
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            DashBoard dss = new DashBoard();
            dss.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            book.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            Admin Adm = new Admin();
            Adm.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            AboutUs abs = new AboutUs();
            abs.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            Member stu = new Member();
            stu.Show();
            this.Hide();
            new Issue().Close();
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            try
            {
                int SID = int.Parse(comboBox1.Text);
                string SName = comboBox4.Text;
                int BID = int.Parse(comboBox3.Text);
                string BName = comboBox2.Text;
                DateTime date = bunifuDatepicker1.Value.Date;
                IssueObj io = new IssueObj();


                string q = "select * from Book where Book_Id='" + BID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = sda.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        avil = int.Parse(dr[5].ToString());
                    }

                    if (avil != 0)
                    {
                        if (io.AddIssueIssue(SID, SName, BID, BName, date) == true)
                        {
                            try
                            {

                                dr.Close();
                                conn.Close();

                                count2 = avil - 1;
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                string r = "UPDATE Book SET Avilable_Book='" + count2 + "' WHERE Book_Id='" + BID + "'";
                                SqlDataAdapter sdaa = new SqlDataAdapter(r, conn);
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                sdaa.SelectCommand.ExecuteNonQuery();
                                conn.Close();
                              new dialog().Show();

                            }
                            catch (Exception ex)
                            {
                                new Error().Show();
                            }


                           
                        }
                        else
                        {
                            Error er = new Error("Return A book You issued First");
                            er.Show();
                            er.Hide();
                        }
                    }
                    else
                    {
                        Error er = new Error("No '" + BName + "' Available for now");
                        er.Show();
                        er.Hide();
                    }
                }
                else
                {
                    Error er = new Error("Book doesn't Exist");
                    er.Show();
                    er.Hide();
                }

            }
            catch (Exception ex)
            {


                Error er = new Error("Please insert Valid Input");
                er.Show();
            }
            finally
            {
                dr.Close();
                conn.Close();
            }

        }
        private void Return_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int SID = int.Parse(comboBox1.Text);
                IssueObj Iobj = new IssueObj();


                if (Iobj.Return(SID))
                {
                    ReturnBook();


                    new dialog().Show();

                }
                else
                {
                    Error er = new Error("NO Record Found With This ID");
                    er.Show();
                }
            }
            catch
            {
                Error Er = new Error("Please insert value!!!");
                Er.Show();
            }
        }
        public void ReturnBook()
        {
            try
            {
                int BID = int.Parse(comboBox3.Text);
               string q="select * from Book where Book_Id='"+BID+"'";
                SqlDataAdapter sda = new SqlDataAdapter(q, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = sda.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                     count =int.Parse(dr[5].ToString());

                }

                dr.Close();
                conn.Close();
              
               count2 = count + 1;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
               string r= "UPDATE Book SET Avilable_Book='"+count2+"' WHERE Book_Id='"+BID+"'";
                SqlDataAdapter sdaa = new SqlDataAdapter(r, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                 sdaa.SelectCommand.ExecuteNonQuery();
                conn.Close();
                
               
            }
            catch (Exception ex)
            {
                new Error().Show();
            }
        }

      /*  public void IssueBook()
        {
            try
            {
                int BID = int.Parse(comboBox3.Text);
                string q = "select * from Book where Book_Id='" + BID + "'";
                SqlDataAdapter sda = new SqlDataAdapter(q, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = sda.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    count = int.Parse(dr[5].ToString());

                }

                dr.Close();
                conn.Close();

                count2 = count - 1;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string r = "UPDATE Book SET Avilable_Book='" + count2 + "' WHERE Book_Id='" + BID + "'";
                SqlDataAdapter sdaa = new SqlDataAdapter(r, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                sdaa.SelectCommand.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception ex)
            {
                new Error().Show();
            }
        }*/

        public void fillstud()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();


            string query = "select Stud_ID from RETURNBOOK";
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
            try {
                int cmb = int.Parse(comboBox1.Text);
                string query = "select * from RETURNBOOK where Stud_ID = '" + cmb + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
               
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = sda.SelectCommand.ExecuteReader();

                while (dr.Read())
                {
                    comboBox4.Text = dr[1].ToString();
                    comboBox3.Text = dr[2].ToString();
                    comboBox2.Text = dr[3].ToString();
                    label5.Text = dr[4].ToString();

                }
            }
            catch (Exception ex)
            {
                comboBox2.Text = dr[3].ToString();
                label5.Text = dr[4].ToString();
            }
            finally
            {
                dr.Close();
                conn.Close();

            }
           

        }

        public void fill()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();


            string query = "select Book_Id from Book";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlDataReader drr = sda.SelectCommand.ExecuteReader();
            while (drr.Read())
            {
                comboBox3.Items.Add(drr[0]);
            }
            drr.Close();
            conn.Close();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int cmb = int.Parse(comboBox3.Text);
            string query = "select Book_Name from Book where Book_Id = '" + cmb + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            dr = sda.SelectCommand.ExecuteReader();

            while (dr.Read())
            {

                comboBox2.Text = dr[0].ToString();
                

            }
            conn.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Issue mb = new Issue();
            mb.Show();
            this.Hide();
            new Issue().Close();
        }
    }
    }
    

