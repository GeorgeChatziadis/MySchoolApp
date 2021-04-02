using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Interfaces;

namespace MySch.Services
{
    class StudentCourseService : IStudentCourse
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentCourses = new List<StudentCourse>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM StudentCourses", conn))
                    {
                        using (SqlDataReader coursesReader = cmd.ExecuteReader())
                        {
                            while (coursesReader.Read())
                            {
                                StudentCourse studentCourse = new StudentCourse()
                                {
                                    ID = (int)coursesReader["ID"],
                                    CourseId = (int)coursesReader["CourseID"],
                                    StudentId = (int)coursesReader["StudentID"]
                                };
                                studentCourses.Add(studentCourse);
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
            return studentCourses;
        }

        public void Create()
        {
            Console.WriteLine("Give Course ID");
            int CourseId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Give Student ID");
            int StudentId = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO StudentCourses(CourseID,StudentID) " +
                        "VALUES (@CourseID,@StudentID)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@CourseID", CourseId));
                        cmd.Parameters.Add(new SqlParameter("@StudentID", StudentId));
                        int rowsInserted = cmd.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            Console.WriteLine("Insertion Successful");
                            Console.WriteLine($"{rowsInserted} rows inserted Successfully");
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
        }
    }
}
