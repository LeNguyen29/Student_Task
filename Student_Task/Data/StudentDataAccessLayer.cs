using Microsoft.Data.SqlClient;
using Student_Task.Models;
using System.Data;
using System.Net;

namespace Student_Task.Data
{
    public class StudentDataAccessLayer
    {
        string connectionString = DatabaseContext.CString;

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> studentList = new List<StudentModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM StudentsInfo";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentModel student = new StudentModel
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        FullName = reader["FullName"].ToString(),
                        ClassLevel = reader["ClassLevel"].ToString(),
                        Status = reader["Status"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Address = reader["Address"].ToString()
                    };

                    studentList.Add(student);
                }

                conn.Close();
            }

            return studentList;
        }

        public void AddStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FullName", student.FullName);
                cmd.Parameters.AddWithValue("@ClassLevel", student.ClassLevel);
                cmd.Parameters.AddWithValue("@Status", student.Status);
                cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", student.ID);
                cmd.Parameters.AddWithValue("@FullName", student.FullName);
                cmd.Parameters.AddWithValue("@ClassLevel", student.ClassLevel);
                cmd.Parameters.AddWithValue("@Status", student.Status);
                cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public StudentModel GetStudentData(int? id)
        {
            StudentModel student = new StudentModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM StudentsInfo WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    student.ID = Convert.ToInt32(reader["ID"]);
                    student.FullName = reader["FullName"].ToString();
                    student.ClassLevel = reader["ClassLevel"].ToString();
                    student.Status = reader["Status"].ToString();
                    student.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                    student.Address = reader["Address"].ToString();
                }
            }
            return student;
        }

        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"DELETE FROM StudentsInfo WHERE ID= {id}";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
