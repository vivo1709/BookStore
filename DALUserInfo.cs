using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace BookStoreLIB
{
    internal class DALUserInfo
    {
        public int Login(string username, string password)
        {
            var conn = new SqlConnection(UnitTestLoginPage.Properties.Settings.Default.DatabaseConnection);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select UserID from UserData where "
                    + "UserName = @UserName and Password = @Password ";
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                int userId = (int)cmd.ExecuteScalar();
                if (userId > 0) return userId;
                else return -1;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}