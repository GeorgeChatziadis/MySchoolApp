using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySch.Entities;
using MySch.Interfaces;
using MySch.ViewModels;

namespace MySch.Services
{
    class CourseService : ICourse
    {
        private readonly string connectionString = @"Data Source=DESKTOP-ATVD7K2\SQLEXPRESS;Initial Catalog=MySchool;Integrated Security=True";

        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", conn))
                    {
                        using (SqlDataReader coursesReader = cmd.ExecuteReader())
                        {
                            while (coursesReader.Read())
                            {
                                Course course = new Course()
                                {
                                    ID = (int)coursesReader["id"],
                                    Title = (string)coursesReader["Title"],
                                    Stream = (string)coursesReader["Stream"],
                                    Type = (string)coursesReader["Type"],
                                    Start = (DateTime)coursesReader["Start"],
                                    End = (DateTime)coursesReader["End"],
                                };
                                courses.Add(course);
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
            return courses;
        }

        public void Create()
        {
            Console.WriteLine("Give a title");
            string Title = Console.ReadLine();
            Console.WriteLine("Give a stream");
            string Stream = Console.ReadLine();
            Console.WriteLine("Give me the type of the course.");
            string Type = Console.ReadLine();
            Console.WriteLine("Give a starting date");
            DateTime Start = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Give an ending date");
            DateTime End = Convert.ToDateTime(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string queryString = "INSERT INTO Courses(Title,Stream,Type,Start,End) " +
                        "VALUES (@Title,@Stream,@Type,@Start,@End)";

                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Title", Title));
                        cmd.Parameters.Add(new SqlParameter("@Stream", Stream));
                        cmd.Parameters.Add(new SqlParameter("@Type", Type));
                        cmd.Parameters.Add(new SqlParameter("@Start", Start));
                        cmd.Parameters.Add(new SqlParameter("@End", End));
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
