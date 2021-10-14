using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    class IssueObj
    { 
    SqlConnection conn;
    SqlCommand cmd;
        SqlDataReader dr;
        string name;

    public IssueObj()
    {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
        cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;

    }

        public bool AddIssueIssue(int SID,string SName, int  BID, string BName,DateTime date)
        {
            try {
               
                string query = "insert into RETURNBOOK ( Stud_ID,Stud_Name, Book_ID, Book_Name,Date) values (   '" + SID + "','" + SName + "','" + BID + "', '" + BName + "', '" + date + "')";
                conn.Open();
                SqlDataAdapter sss = new SqlDataAdapter(query, conn);
                sss.SelectCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
 

   
    public bool Return(int SID)
    {
        try
        {
            cmd.CommandText = string.Format("delete from RETURNBOOK where Stud_ID={0}", SID);
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
    }
}