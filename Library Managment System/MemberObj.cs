using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    class MemberObj
    {     
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader dr;

            public MemberObj()
            {
                string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
                conn = new SqlConnection(conn_string);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

            }
            public bool AddMember(int ID, string Name, string LName, int Phone, string Email, int Pay, DateTime Date)
            {
                try
                {
                    cmd.CommandText = string.Format("INSERT INTO Member VALUES({0},'{1}','{2}',{3},'{4}',{5},'{6}')", ID, Name, LName, Phone, Email, Pay, Date);
                    if (conn.State == ConnectionState.Closed)
                    
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            public bool UpdateMember(int ID, string Name, string LName, int Phone, string Email, int Pay, DateTime Date)
            {
                try
                {
                    cmd.CommandText = string.Format("UPDATE Member SET Member_Name='{0}',Member_LName ='{1}', Member_Phone={2}, Member_Email='{3}', Member_Payment={4}, Date='{5}' WHERE Member_Id={6}", Name, LName, Phone, Email, Pay, Date, ID);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
       
        public bool DeleteMember(int ID)
            {
                try
                {
                    cmd.CommandText = string.Format("delete from Member where Member_Id={0}", ID);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
           

        }
    }


