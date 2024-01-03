using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Student_Task.Models;

namespace Student_Task.Data
{
    public class LoginDataAccessLayer
    {
        string connectionString = DatabaseContext.CString;

        public List<LoginModel>? GetAllAccounts()
        {
            List<LoginModel> accounts = new List<LoginModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM mst_Account";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accounts.Add(new LoginModel()
                        {
                            LoginId = reader["LoginId"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString(),
                            Role = reader["Role"].ToString()
                        });
                    }
                }
                else
                    return null;
            }

            return accounts;
        }

        public LoginModel? CheckLogin(string loginID, string passwordHash)
        {
            LoginModel loginUser = new LoginModel();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM mst_Account WHERE LoginId = '{loginID}' AND Password = '{passwordHash}' ";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        loginUser.LoginId = reader["LoginId"].ToString();
                        loginUser.UserName = reader["UserName"].ToString();
                        loginUser.Email = reader["Email"].ToString();
                        loginUser.Role = reader["Role"].ToString();
                    }
                }
                else
                {
                    return null;
                }

                conn.Close();

            }

            return loginUser;
        }
    }
}
