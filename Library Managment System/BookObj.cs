using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    class BookObj
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        int count;
        int count2;

        string name, author, publisher, date;
    
        public BookObj()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

        }
        public bool AddBook(int ID, string Name, string Author, string Publisher, DateTime Date,int count)
        {
            try
            {
                cmd.CommandText = string.Format("insert into Book values( {0},'{1}','{2}','{3}','{4}',{5})", ID, Name, Author, Publisher, Date,count);
                if (conn.State == ConnectionState.Closed)
                
                    conn.Open();
                    cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
            }
        }
        public bool UpdateBook(int ID, string Name, string Author, string Publisher, DateTime Date, int count)
        {
            try
            {
                cmd.CommandText = string.Format("UPDATE Book SET Book_Name='{0}',Book_Author ='{1}', Book_Publisher='{2}', Date='{3}',Avilable_Book={4} WHERE Book_Id={5}", Name, Author, Publisher, Date, count, ID);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteBook(int ID)
        {
            try
            {
                cmd.CommandText = string.Format("select * from Book where Book_Id={0}", ID);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
               dr= cmd.ExecuteReader();
                while (dr.Read())
                {
                    name = dr[1].ToString();
                    author = dr[2].ToString();
                    publisher = dr[3].ToString();
                    date = dr[4].ToString();
                    
                    count = int.Parse(dr[5].ToString());

                }
                dr.Close();
                conn.Close();
                if (count == 1)
                {
                    cmd.CommandText = string.Format("delete from Book where Book_Id={0}", ID);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    count2 = count - 1;
                    cmd.CommandText = string.Format("UPDATE Book SET Book_Name='{0}',Book_Author ='{1}', Book_Publisher='{2}', Date='{3}',Avilable_Book={4} WHERE Book_Id={5}", name, author, publisher, date, count2, ID);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SqlDataReader ShowAllBook()
        {
            dr.Close();
            return dr;
            
        }
        public SqlDataReader searchbyid(int ID)
        {
            cmd.CommandText = string.Format("SELECT * FROM Book WHERE Book_Id = {0}", ID);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            dr = cmd.ExecuteReader();

           
            return dr;

        }

    }
}
