using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;

namespace MySch.Services
{
    class StudentAssignmentService
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<StudentAssignment> GetAll()
        {
            List<StudentAssignment> studentAssignments = new List<StudentAssignment>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM StudentAssignments", conn))
                    {
                        using (SqlDataReader assignmentsReader = cmd.ExecuteReader())
                        {
                            while (assignmentsReader.Read())
                            {
                                StudentAssignment studentAssignment = new StudentAssignment()
                                {
                                    ID = (int)assignmentsReader["ID"],
                                    StudentId = (int)assignmentsReader["StudentID"],
                                    AssignmentId = (int)assignmentsReader["AssignmentID"]
                                };
                                studentAssignments.Add(studentAssignment);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"SqlException {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"General exception {e.Message}");
                }
            }
            return studentAssignments;
        }

        
    }
}
