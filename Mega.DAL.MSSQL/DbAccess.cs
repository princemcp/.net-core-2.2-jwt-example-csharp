using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Mega.DAL
{
    public class DbAccess
    {
        public void GetData(string authorID)
        {
            SqlConnection conn = new SqlConnection("ConnectString");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            //ClsAuthor TheAuthor = new ClsAuthor();
            try
            {
                cmd.CommandText = "Select * from Authors where au_id = @auid";
                cmd.Parameters.Add("@auid", SqlDbType.Char);
                cmd.Parameters[0].Value = authorID;
                cmd.Connection = conn;
                cmd.Connection.Open();

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    //Get Function
                    //TheAuthor.Auid = GetSafeDbString(dr, "au_id");
                    //TheAuthor.Aulname = GetSafeDbString(dr, "au_lname");
                    //TheAuthor.Aufname = GetSafeDbString(dr, "au_fname");
                    //TheAuthor.Phone = GetSafeDbString(dr, "phone");
                    //TheAuthor.Address = GetSafeDbString(dr, "address");
                    //TheAuthor.City = GetSafeDbString(dr, "city");
                    //TheAuthor.State = GetSafeDbString(dr, "state");
                    //TheAuthor.Zip = GetSafeDbString(dr, "zip");
                    //TheAuthor.Contract = GetSafeDbBool(dr, "contract");
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return;// TheAuthor;
        }

    }
}
