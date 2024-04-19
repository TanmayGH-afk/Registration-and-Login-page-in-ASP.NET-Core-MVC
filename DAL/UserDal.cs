using RegistrationForm.Models;
using System.Data.SqlClient;

namespace RegistrationForm.DAL
{
    public class UserDal
    {
        string Connection = "Data Source=LAPTOP-Q6P25RT4\\SQLEXPRESS;Initial Catalog=TestEmployees;Integrated Security=True";

        public int UserInsert(UserRegistration Reg)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                string sqlQuery = "INSERT INTO NewEmployee(UserName, EmailId, Password, MaritalStatus, Gender) VALUES (@UserName, @EmailId, @Password, @MaritalStatus, @Gender)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, con))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", Reg.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailId", Reg.Emaild);
                    sqlCommand.Parameters.AddWithValue("@Password", Reg.Password);
                    sqlCommand.Parameters.AddWithValue("@MaritalStatus", Reg.MaritalStatus);
                    sqlCommand.Parameters.AddWithValue("@Gender", Reg.Gender);

                    con.Open();
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }


        public int UserValid(string email, string password)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(Connection))
            {
                string sqlQuery = "SELECT COUNT(*) FROM NewEmployee WHERE EmailId = @EmailId AND Password = @Password";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, con))
                {
                    sqlCommand.Parameters.AddWithValue("@EmailId", email);
                    sqlCommand.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    // ExecuteScalar returns the first column of the first row in the result set, or a null reference if the result set is empty
                    rowsAffected = (int)sqlCommand.ExecuteScalar();
                }
            }
            return rowsAffected;
        }

    }
}
