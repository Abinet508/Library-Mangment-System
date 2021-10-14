using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Library_Managment_System
{
    public class AdminObj
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string ph;
        int k = 1;
        string name;



        public AdminObj()
        {
            string conn_string = @"Data Source=LAPTOP-OOS5DNMO;Initial Catalog=LMS_DB;Integrated Security=True";
            conn = new SqlConnection(conn_string);
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "Select * from Admin";
            //cmd.ExecuteReader();


        }
       
        public bool isAdminExist(int ID)
        {
            try {
                cmd.CommandText = string.Format("Select * from Admin WHERE Admin_Id = {0}", ID);
                if (conn.State == ConnectionState.Closed)
                
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr != null)
                    {
                    dr.Close();
                    conn.Close();
                    return true;
                    }

                    else
                    {
                        return false;
                    }
 
               
                
            }
            catch (Exception ex)

            {
                return false;
            }
    }


        public bool AddAdmin(int ID, string Name, string Email, int phone, string Password,string photo)
        {
            try
            {
                cmd.CommandText = string.Format("insert into Admin values({0},'{1}','{2}',{3},'{4}','{5}')", ID, Name, Email, phone, Password,photo);
                
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
        public bool UpdateAdmin(int ID, string Name, string Email, int phone, string Password, string Photo)
        {
            try
            {
                cmd.CommandText = string.Format("update Admin set Admin_Name='{0}', Admin_Email='{1}', Admin_Phone={2}, Admin_Password='{3}', Admin_Photo='{4}' where Admin_Id={5}", Name, Email, phone, Password, Photo,ID);
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
        public bool DeleteAdmin(int ID)
        {
            try
            {
                cmd.CommandText = string.Format("delete from Admin where Admin_Id={0}", ID);
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
        public SqlDataReader ShowAllAdmin()
        {
            dr.Close();
            conn.Close();
            return dr;
        }

        public void getname(string name)
        {
            try {

                cmd.CommandText = string.Format("Select * from Admin WHERE Admin_Name = '{0}'", name);
                if (conn.State == ConnectionState.Closed)

                    conn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ph = dr[5].ToString();

                }
                dr.Close();
                conn.Close();
                cmd.CommandText = string.Format("UPDATE INFO SET [Name]='{0}',[Photo]='{1}'  WHERE [Id]={2}", name, ph, k);
                if (conn.State == ConnectionState.Closed)

                    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                new Error(" ").Show();
            }

        }


        public bool UserExist(string Name,string pass)
        {
            try
            {
                cmd.CommandText = string.Format("Select * from Admin WHERE Admin_Name= '{0}' AND Admin_Password= '{1}'", Name, pass);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                        conn.Close();
                        return true;
                }

                return false;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GETNAME()
        {
            cmd.CommandText = string.Format("Select * from INFO WHERE Id = '{0}'", k);
            if (conn.State == ConnectionState.Closed)

                conn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())


                name = dr[1].ToString();
            dr.Close();
            return name;
            
        }
        public string GETPHOTO()
        {
            cmd.CommandText = string.Format("Select * from INFO WHERE Id = '{0}'", k);
            if (conn.State == ConnectionState.Closed)

                conn.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())


                ph = dr[2].ToString();



            dr.Close();
            return ph;


        }

      public SqlDataReader searchbyid(int ID)
        {
            cmd.CommandText = string.Format("Select * from Admin WHERE Admin_Id = '{0}'", ID);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            dr = cmd.ExecuteReader();

           
            return dr;
           


        }
    }
}
